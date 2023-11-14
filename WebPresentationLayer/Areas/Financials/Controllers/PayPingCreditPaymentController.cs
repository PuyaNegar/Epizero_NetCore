using System;
using System.Net;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.FinancialsViewModels;
using WebViewModels.IdentitiesViewModels; 

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    public class PayPingCreditPaymentController : Controller, IDisposable
    {
        //=============================================================================
        private InvoiceService invoiceService;
        private CreditPaymentService creditPaymentService;
        //=============================================================================
        public PayPingCreditPaymentController()
        {
            this.invoiceService = new InvoiceService();
            this.creditPaymentService = new CreditPaymentService();
        }
        //=============================================================================
        [Authorize]
        [HttpPost]
        [ModelValidatorAsync]
        public async Task<IActionResult> GetBankPaymentUrl([FromBody] CreditPaymentMethodViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
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
                        string url = GeneratePaymentUrl(TotalPayment, InvoiceNo);
                        return Ok(new SysResult<PaymentRedirectViewModel>() { IsSuccess = true, Value = new PaymentRedirectViewModel() { PaymentUrl = url } });
                    }
                    return BadRequest(new SysResult() { IsSuccess = false, Message = SystemCommonMessage.InputDataIsIncorrect });
                }
                catch (Exception ex)
                {
                    return BadRequest(new SysResult() { IsSuccess = false, Message = ex.Message });
                }
            });
        }
        //===========================================================================================
        [Route("[area]/[controller]/[action]")]
        public async Task<IActionResult> CallBackPayment([FromForm] PaypingPaymentResponseViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                try
                {
                    
                    var Refrence = Request.Query["RefrenceId"].ToString().DecriptWithDESAlgoritm().Split('~');
                    var StudentUserId = Convert.ToInt32(Refrence[0]);
                    var InvoiceNo = Refrence[1];
                    int AmountPayable = Convert.ToInt32(Refrence[2]);
                    //*************************************************** Verify
                    var isVerifiedTransaction = SendVerifyRequest(viewModel, AmountPayable);
                    if (isVerifiedTransaction)
                        return CreditOpration(viewModel.refid, StudentUserId, InvoiceNo);
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
            });
        }

        //==============================================================================
        private IActionResult CreditOpration(string SaleReferenceId, int UserId, string InvoiceNo)
        {
            var result = creditPaymentService.SucceedPayment(PaymentGateway.PayPing, InvoiceNo, UserId, SaleReferenceId);
            if (!result.IsSuccess)
                return View("~/Views/Payment/ErrorPayment.cshtml");
            FinalCreditOpration(SaleReferenceId.ToString(), InvoiceNo);
            return View("~/Views/Payment/SuccessPayment.cshtml");
        }
        //==============================================================================
        string GeneratePaymentUrl(int AmountPayable, string InvoiceNo)
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
                    returnUrl = AppConfigProvider.GetApplicationUrl() + "/Financials/PayPingCreditPayment/CallBackPayment?RefrenceId=" + string.Format("{0}~{1}~{2}", GetCurrentUserId(), InvoiceNo, AmountPayable).EncriptWithDESAlgoritm(),
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
        LoginedUsersViewModel GetUserInfo(int userId)
        {
            using (var usersService = new UsersService())
            {
                var users = usersService.Find(userId).Value;
                return users;
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