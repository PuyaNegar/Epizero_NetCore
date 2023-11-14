using Common.Enums;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class CreditPaymentService : IDisposable
    {
        //=====================================================================================
        public SysResult FailurePayment(string InvoiceNo)
        {
            try
            {
                using (var creditPaymentComponent = new CreditPaymentComponent())
                {
                    creditPaymentComponent.OnErrorPayment(InvoiceNo);
                    return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
                }
            }
            catch (Exception m)
            {
                return new SysResult() { IsSuccess = false, Message = m.Message };
            }
        }
        //===================================================================
        public SysResult SucceedPayment(PaymentGateway paymentGateway, string InvoiceNo, int CustomerId, string TrackingNo)
        {
            try
            {
                using (var creditPaymentComponent = new CreditPaymentComponent())
                {
                    creditPaymentComponent.OnSuccessPayment(paymentGateway, InvoiceNo, CustomerId, TrackingNo);
                    return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
                }
            }
            catch (Exception m)
            {
                return new SysResult() { IsSuccess = false, Message = m.Message };
            }
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
