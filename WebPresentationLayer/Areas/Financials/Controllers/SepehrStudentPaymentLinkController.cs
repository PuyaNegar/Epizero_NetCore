using System;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels; 
using WebViewModels.IdentitiesViewModels;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using System.Linq;
using Common.Service;

namespace WebPresentationLayer.Areas.Orders.Controllers
{
    [Area("Financials")]
    public class SepehrStudentPaymentLinkController : Controller, IDisposable
    {
        private InvoiceService invoiceService;
        private StudentPaymentLinksService studentPaymentLinksService;
        private HttpClientComponent httpClientComponent;
        //=============================================================================
        public SepehrStudentPaymentLinkController()
        {
            invoiceService = new InvoiceService();
            studentPaymentLinksService = new   StudentPaymentLinksService();
            httpClientComponent = new HttpClientComponent();
        }
        //============================================================================= 
        [ApiService]
        [AjaxAuthorize]
        [ModelValidatorAsync]
        [HttpPost]
        public async Task<IActionResult> GetBankPaymentUrl([FromBody] OrderPaymentMethodViewModel request)
        { 
                try
                {
                    var AmountPayable = 0;
                    var invoiceNo = string.Empty;
                    string studentPaymentLinkIds = string.Empty;
                    var result = invoiceService.MakeStudentPaymentLinksInvoice(GetCurrentUserId(), request.UseCredit ,  ref invoiceNo, ref AmountPayable , ref   studentPaymentLinkIds);
                    if (result.IsSuccess == false)
                        return BadRequest(new SysResult() { IsSuccess = false, Message = result.Message });

                    if (AmountPayable > 0)
                    {
                        string accessToken = await GeneratePaymentUrl(AmountPayable, invoiceNo, studentPaymentLinkIds);
                        return Ok(new SysResult<PaymentRedirectViewModel>() { IsSuccess = true, Value = new PaymentRedirectViewModel() { PaymentUrl = AppConfigProvider.GetApplicationUrl() + "/SepehrPaymentViewer/" + accessToken } });
                    }
                    else
                    {
                        string url = ComplateOrderFromCredit(studentPaymentLinkIds);
                        return Ok(new SysResult<PaymentRedirectViewModel>() { IsSuccess = true, Value = new PaymentRedirectViewModel() { PaymentUrl = url } });
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(new SysResult() { IsSuccess = false, Message = ex.Message });
                } 
        }
        //==============================================================================
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> CallbackPayment( )
        { 
                var InvoiceNo = string.Empty;
                try
                {
                    ViewBag.InvoiceProcessType = InvoiceProcessType.Order;
                    var Refrence = Request.Query["RefrenceId"].ToString().DecriptWithDESAlgoritm().Split('~')  ;
                    var StudentUserId = Convert.ToInt32(Refrence[0]);
                    InvoiceNo = Refrence[1];
                    string studentPaymentLinkIds =  Refrence[2] ;
                    int amountPayable = Convert.ToInt32(Refrence[3]);
                    var model = new SepehrVerifyRequestDTOModel() { digitalreceipt = Request.Query["digitalreceipt"], Tid = Convert.ToInt64(AppConfigProvider.GetSepehr_MerchantId()) };
                    var data = await httpClientComponent.Send<SepehrVerifyResponseDTOModel>(new ApiRequestDTOModel()
                    {
                        ApiType = ApiType.POST,
                        Data = model,
                        Url = "https://sepehr.shaparak.ir:8081/V1/PeymentApi/Advice",
                        HttpRequestDataType = HttpRequestDataType.X_Form_Url_Encoded,
                    });
                    var response = data.responseResult;
                    if (response.Status.ToLower() == "ok")
                    {
                        return OrderOperation(response.ReturnId,  StudentUserId, InvoiceNo  , studentPaymentLinkIds);
                    }
                    else
                    {
                        studentPaymentLinksService.FailurePayment(InvoiceNo);
                        return View("~/Views/Payment/ErrorPayment.cshtml");
                    }
                }
                catch (Exception ex)
                {
                    return View("~/Views/Payment/ErrorPayment.cshtml");
                } 
        } 
        //==============================================================================
        IActionResult OrderOperation(string bankReference, int studentUserId, string InvoiceNo , string studentPaymentLinkIds)
        {
            //********* ChargeCredit
            var result = studentPaymentLinksService.ChargeCredit(PaymentGateway.Sepehr, InvoiceNo, bankReference.ToString(), studentUserId);
            if (!result.IsSuccess)
                return View("~/Views/Payment/ErrorPayment.cshtml");
            //********* تابع تکمیل سفارش
            int OrderId = 0;
            string _invoceNo = string.Empty;
            var orderComplateResult = studentPaymentLinksService.ComplatePayment(studentPaymentLinkIds  ,  studentUserId, ref _invoceNo);
            if (orderComplateResult.IsSuccess == false)
                throw new Exception(orderComplateResult.Message);
            //*********
            FinalOrderOpration(bankReference.ToString(), _invoceNo, OrderId);
           // orderPaymentService.SendSmsToOperatores();
            return View("~/Views/Payment/SuccessPayment.cshtml");
        }

        //==============================================================================
        async Task<string> GeneratePaymentUrl(int AmountPayable, string InvoiceNo, string studentPaymentLinkIds)
        {
            var user = GetUserInfo(GetCurrentUserId());
            var callbackUrl = AppConfigProvider.GetApplicationUrl() + "/Financials/SepehrStudentPaymentLink/CallBackPayment?RefrenceId=" + string.Format("{0}~{1}~{2}~{3}", GetCurrentUserId(), InvoiceNo, studentPaymentLinkIds, AmountPayable).EncriptWithDESAlgoritm();
            var model = new SepehrTokenCreateRequestDTOModel() { TerminalId = AppConfigProvider.GetSepehr_MerchantId(), InvoiceId = InvoiceNo, Amount = AmountPayable * 10, CallbackUrl = callbackUrl, Payload = string.Empty };
            var result = await httpClientComponent.Send<SepehrTokenCreateResponseDTOModel>(new ApiRequestDTOModel()
            {
                ApiType = ApiType.POST,
                Data = model,
                Url = "https://sepehr.shaparak.ir:8081/V1/PeymentApi/GetToken",
                HttpRequestDataType = HttpRequestDataType.X_Form_Url_Encoded,
            });
            var response = result.responseResult;
            if (response.Status == 0)
            {
                return response.Accesstoken;
            }
            else
                throw new Exception("خطا در ارتباط با بانک"); 
        }
        //==============================================================================
        void FinalOrderOpration(string referenceId, string InvoiceNo, int OrderId)
        {
            ViewBag.ReferenceId = referenceId;
            ViewBag.InvoiveNo = InvoiceNo;
            ViewBag.HashOrderId = OrderId.ToString().EncriptWithDESAlgoritm();
            ViewBag.DateTime = DateTime.UtcNow.ToLocalDateTimeLongFormatString();
        }
        //==============================================================================
        string ComplateOrderFromCredit(string studentPaymentLinkIds)
        {
            int OrderId = 0;
            string InvoiceNo = string.Empty;
            var url = string.Empty;
            var OrderResult = studentPaymentLinksService.ComplatePayment(studentPaymentLinkIds, GetCurrentUserId(), ref InvoiceNo);
            if (!OrderResult.IsSuccess)
                return url = AppConfigProvider.GetApplicationUrl() + "/Payment/ErrorOrderPayment?RefId=" + string.Format("{0}~{1}~{2}", "-", "-", "-").EncriptWithDESAlgoritm();
            else
            {
                //orderPaymentService.SendSmsToOperatores();
                return url = AppConfigProvider.GetApplicationUrl() + "/Payment/SuccessOrderPayment?RefId=" + string.Format("{0}~{1}~{2}", InvoiceNo, OrderId.ToString().EncriptWithDESAlgoritm(), "-").EncriptWithDESAlgoritm();
            }
        } 
        //==============================================================================
        int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //==============================================================================
        LoginedUsersViewModel GetUserInfo(int userId)
        {
            using (var usersService = new UsersService())
            {
                var users = usersService.Find(userId).Value;
                return users;
            }
        }
        //=============================================================================== Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            invoiceService?.Dispose();
            studentPaymentLinksService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
