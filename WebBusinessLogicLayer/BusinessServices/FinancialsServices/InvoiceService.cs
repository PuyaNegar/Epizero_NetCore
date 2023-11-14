using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class InvoiceService : IDisposable
    {
        public SysResult MakeOrderInvoice(int studentUserId, bool UseCredit, bool UseScore , int OrderId, ref string InvoiceNo, ref int FinalAmountPayable)
        {
            try
            {
                using (var makeInvoiceProcessComponent = new MakeOrderInvoiceComponent())
                {
                    makeInvoiceProcessComponent.Operation(studentUserId, UseCredit, UseScore,  OrderId, ref InvoiceNo, ref FinalAmountPayable);
                    return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
                }
            }
            catch (Exception m)
            {
                return new SysResult() { IsSuccess = false, Message = m.Message };
            }
        }

        //=====================================================================================================
        public SysResult MakeStudentPaymentLinksInvoice(int studentUserId, bool UseCredit, ref string InvoiceNo, ref int FinalAmountPayable , ref string studentPaymentLinkIds)
        {
            try
            {
                using (var makeInvoiceProcessComponent = new MakeStudentPaymentLinksInvoiceComponent())
                {
                    makeInvoiceProcessComponent.Operation(studentUserId, UseCredit ,    ref InvoiceNo, ref FinalAmountPayable  , ref  studentPaymentLinkIds );
                    return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
                }
            }
            catch (Exception m)
            {
                return new SysResult() { IsSuccess = false, Message = m.Message };
            }
        }
        //=====================================================================================================
        public SysResult MakeCreditInvoice(int CustomerId, int TotalPayment, ref string InvoiceNo)
        {
            try
            {
                using (var makeCreditInvoiceComponent = new MakeCreditInvoiceComponent())
                {
                    makeCreditInvoiceComponent.Operation(CustomerId, TotalPayment, ref InvoiceNo);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception m)
            {
                return new SysResult() { IsSuccess = false, Message = m.Message };
            }
        }
        //===================================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
