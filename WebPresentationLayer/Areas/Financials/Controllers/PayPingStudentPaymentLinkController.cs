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

namespace WebPresentationLayer.Areas.Orders.Controllers
{
    [Area("Financials")]
    public class PayPingStudentPaymentLinkController : Controller, IDisposable
    {
        private InvoiceService invoiceService;
        private StudentPaymentLinksService studentPaymentLinksService;
        //=============================================================================
        public PayPingStudentPaymentLinkController()
        {
            invoiceService = new InvoiceService();
            studentPaymentLinksService = new   StudentPaymentLinksService();
        }
        //============================================================================= 
        [ApiService]
        [AjaxAuthorize]
        [ModelValidatorAsync]
        [HttpPost]
        public async Task<IActionResult> GetBankPaymentUrl([FromBody] OrderPaymentMethodViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
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
                        string url = GeneratePaymentUrl(AmountPayable, invoiceNo, studentPaymentLinkIds);
                        return Ok(new SysResult<PaymentRedirectViewModel>() { IsSuccess = true, Value = new PaymentRedirectViewModel() { PaymentUrl = url } });
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
            });
        }
        //==============================================================================
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> CallbackPayment([FromForm] PaypingPaymentResponseViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
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
                    var isVerifiedTransaction = SendVerifyRequest(viewModel, amountPayable);
                    if (isVerifiedTransaction)
                    {
                        return OrderOperation(viewModel.refid ,  StudentUserId, InvoiceNo  , studentPaymentLinkIds);
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
            }); 
        } 
        //==============================================================================
        IActionResult OrderOperation(string bankReference, int studentUserId, string InvoiceNo , string studentPaymentLinkIds)
        {
            //********* ChargeCredit
            var result = studentPaymentLinksService.ChargeCredit(PaymentGateway.PayPing, InvoiceNo, bankReference.ToString(), studentUserId);
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
        string GeneratePaymentUrl(int AmountPayable, string InvoiceNo, string studentPaymentLinkIds)
        {
            var user = GetUserInfo(GetCurrentUserId());
            using (var webClient = new WebClient())
            {
                webClient.Headers[HttpRequestHeader.Authorization] = "bearer " + AppConfigProvider.GetPayPingToken();
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                var viewModel = new PaypingPaymentRequestViewModel()
                {
                    payerName = user.FirstName + " " + user.LastName,
                    amount = AmountPayable,
                    payerIdentity = "شماره صورتحساب " + InvoiceNo,
                    returnUrl = AppConfigProvider.GetApplicationUrl() + "/Financials/PayPingStudentPaymentLink/CallBackPayment?RefrenceId=" + string.Format("{0}~{1}~{2}~{3}", GetCurrentUserId(), InvoiceNo, studentPaymentLinkIds, AmountPayable).EncriptWithDESAlgoritm(),
                    description = "شماره موبایل " + user.UserName,
                    clientRefId = "",
                };
                var data = JsonConvert.SerializeObject(viewModel);
                var response = webClient.UploadString("https://api.payping.ir/v2/pay", "Post", data);
                dynamic b = JsonConvert.DeserializeObject(response);
                return "https://api.payping.ir/v2/pay/gotoipg/" + b.code;
            }
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
        bool SendVerifyRequest(PaypingPaymentResponseViewModel viewModel, int amountPayable)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers[HttpRequestHeader.Authorization] = "bearer " + AppConfigProvider.GetPayPingToken();
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    var data = new PaypingPaymentVerifyRequestViewModel()
                    {
                        amount = amountPayable,
                        refId = viewModel.refid
                    };
                    var response = webClient.UploadString("https://api.payping.ir/v2/pay/verify", "Post", JsonConvert.SerializeObject(data));
                }
                return true;
            }
            catch
            {
                return false;
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
