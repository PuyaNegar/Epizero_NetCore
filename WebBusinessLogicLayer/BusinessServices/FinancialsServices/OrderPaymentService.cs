using Common.Enums;
using Common.Extentions;
using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class OrderPaymentService : IDisposable
    {
        //=====================================================================================
        public SysResult ChargeCredit(PaymentGateway paymentGateway, string InvoiceNo, string TrackingNo, int CustomerId)
        {
            try
            {
                using (var creditPaymentComponent = new CreditPaymentComponent())
                {
                    creditPaymentComponent.OnSuccessPayment(paymentGateway, InvoiceNo, CustomerId, TrackingNo);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }
      
        //=====================================================================================
        public SysResult ComplateOrder(int orderId, int CustomerId, ref string InvoiceNo)
        {
            try
            {
                using (var orderSuccessPaymentComponent = new OrderSuccessPaymentComponent())
                {
                    orderSuccessPaymentComponent.Opration(  orderId,   CustomerId, ref   InvoiceNo);
                 }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }


        //=====================================================================================
        public SysResult FailurePayment(string InvoiceId)
        {
            try
            {
                using (var OrderErrorPaymentComponent = new OrderErrorPaymentComponent())
                {
                    OrderErrorPaymentComponent.Opration(InvoiceId);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }
        //=====================================================================================================
        public void SendSmsToOperatores()
        {
            //using (var sendSmsService = new SendSmsService())
            //{
            //    var date = DateTime.UtcNow.ToLocalDateTime();
            //    sendSmsService.SendToOperators(date.ToDateShortFormatString() + "-" + date.Hour + ":" + date.Minute, "OrderAlarm");
            //}
        }
        //=====================================================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        //=====================================================================================================
    }
}
