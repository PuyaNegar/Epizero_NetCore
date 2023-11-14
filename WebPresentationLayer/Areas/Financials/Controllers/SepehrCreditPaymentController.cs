using System; 
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Common.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    public class SepehrCreditPaymentController : Controller, IDisposable
    {
        //=============================================================================
        private InvoiceService invoiceService;
        private CreditPaymentService creditPaymentService;
        private HttpClientComponent httpClientComponent;
        //=============================================================================
        public SepehrCreditPaymentController()
        {
            this.invoiceService = new InvoiceService();
            this.creditPaymentService = new CreditPaymentService();
            this.httpClientComponent = new HttpClientComponent();
        }
        //=============================================================================
        [Authorize]
        [HttpPost]
        [ModelValidatorAsync]
        public async Task<IActionResult> GetBankPaymentUrl([FromBody] CreditPaymentMethodViewModel viewModel)
        {
            try
            {
                if (viewModel.TotalAmount < 1000)
                    throw new Exception("مبلغ وارده نبایستی کمتر از 1000 تومان باشد");
                var TotalPayment = viewModel.TotalAmount;
                var InvoiceNo = string.Empty;
                var result = invoiceService.MakeCreditInvoice(GetCurrentUserId(), TotalPayment, ref InvoiceNo);
                if (result.IsSuccess)
                {
                    string accessToken = await GeneratePaymentUrl(TotalPayment, InvoiceNo);
                    return Ok(new SysResult<PaymentRedirectViewModel>() { IsSuccess = true, Value = new PaymentRedirectViewModel() { PaymentUrl = AppConfigProvider.GetApplicationUrl() + "/SepehrPaymentViewer/" + accessToken } });
                }
                return BadRequest(new SysResult() { IsSuccess = false, Message = SystemCommonMessage.InputDataIsIncorrect });
            }
            catch (Exception ex)
            {
                return BadRequest(new SysResult() { IsSuccess = false, Message = ex.Message });
            }
        }
        //===========================================================================================
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> CallBackPayment( )
        {
            try
            { 
                var Refrence = Request.Query["RefrenceId"].ToString().DecriptWithDESAlgoritm().Split('~');
                var StudentUserId = Convert.ToInt32(Refrence[0]);
                var InvoiceNo = Refrence[1];
                int AmountPayable = Convert.ToInt32(Refrence[2]);
                //*************************************************** Verify
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
                    return CreditOpration(response.ReturnId, StudentUserId, InvoiceNo);
                else
                {
                    creditPaymentService.FailurePayment(InvoiceNo);
                    return View("~/Views/Payment/ErrorPayment.cshtml");
                }
            }
            catch (Exception ex)
            {
                return View("~/Views/Payment/ErrorPayment.cshtml");
            }
        }

        //==============================================================================
        private IActionResult CreditOpration(string SaleReferenceId, int UserId, string InvoiceNo)
        {
            var result = creditPaymentService.SucceedPayment(PaymentGateway.Sepehr, InvoiceNo, UserId, SaleReferenceId);
            if (!result.IsSuccess)
                return View("~/Views/Payment/ErrorPayment.cshtml");
            FinalCreditOpration(SaleReferenceId.ToString(), InvoiceNo);
            return View("~/Views/Payment/SuccessPayment.cshtml");
        }
        //==============================================================================
        async Task<string> GeneratePaymentUrl(int AmountPayable, string InvoiceNo)
        {
            var user = GetUserInfo(GetCurrentUserId());
            var callbackUrl = AppConfigProvider.GetApplicationUrl() + "/Financials/SepehrCreditPayment/CallBackPayment?RefrenceId=" + string.Format("{0}~{1}~{2}", CurrentContext.GetCurrentUserId(this).Value, InvoiceNo, AmountPayable).EncriptWithDESAlgoritm();
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
        LoginedUsersViewModel GetUserInfo(int userId)
        {
            using (var usersService = new UsersService())
            {
                var users = usersService.Find(userId).Value;
                return users;
            }
        }
        //==============================================================================
        void FinalCreditOpration(string referenceId, string InvoiceNo)
        { 
            ViewBag.ReferenceId = referenceId;
            ViewBag.InvoiveNo = InvoiceNo;
            ViewBag.DateTime = DateTime.UtcNow.ToLocalDateTimeLongFormatString();
        }
        //==============================================================================
        int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=============================================================================== Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            invoiceService?.Dispose();
            creditPaymentService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}