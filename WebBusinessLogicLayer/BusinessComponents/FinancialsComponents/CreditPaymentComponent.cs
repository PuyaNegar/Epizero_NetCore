using Common.Enums;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class CreditPaymentComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<InvoicesModel> invoicesRepository;
        private StudentUserFinincesComponent studentUserFinincesComponent;
        //===================================================================================
        public CreditPaymentComponent()
        {
            mainDBContext = new MainDBContext();
            this.invoicesRepository = new Repository<InvoicesModel>(mainDBContext);
            this.studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext);
        }
        //===================================================================================
        public void OnErrorPayment(string InvoiceNo)
        {
            int InvoiceId = 0;
            int TotalPrice = 0;
            UpdateInvoiceState(InvoiceNo, InvoiceStatusType.UnSuccessPayment, ref InvoiceId, ref TotalPrice);
        }
        //===================================================================================
        public void OnSuccessPayment(PaymentGateway paymentGateway, string InvoiceNo, int CustomerId, string TrackingNo)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    int InvoiceId = 0;
                    int TotalPrice = 0;
                    UpdateInvoiceState(InvoiceNo, InvoiceStatusType.SuccessPayment, ref InvoiceId, ref TotalPrice);
                    studentUserFinincesComponent.Deposit(InvoiceId, CustomerId, TotalPrice);
                    MakePayment(paymentGateway, InvoiceId, CustomerId, TrackingNo, TotalPrice);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(SystemCommonMessage.DataWasNotRecordedDueToAnError);
                }
            }
        }
        //===================================================================================
        private void UpdateInvoiceState(string InvoiceNo, InvoiceStatusType invoiceStatusType, ref int InvoiceId, ref int TotalPrice)
        {
            var invoiceModel = invoicesRepository.Where(c => c.InvoiceNo == InvoiceNo && c.InvoiceStatusTypeId == (int)InvoiceStatusType.SendToGateWay).SingleOrDefault();
            if (invoiceModel == null)
                throw new Exception(SystemCommonMessage.InvoiceNotFound);
            invoiceModel.InvoiceStatusTypeId = (int)invoiceStatusType;
            invoiceModel.InvoiceStatusDateTime = DateTime.UtcNow;
            invoicesRepository.Update(invoiceModel);
            invoicesRepository.SaveChanges();
            InvoiceId = invoiceModel.Id;
            TotalPrice = invoiceModel.TotalPrice;
        }
        //===================================================================================
        private void MakePayment(PaymentGateway paymentGateway, int InvoiceId, int CustomerId, string TrackingNo, int Amount)
        {
            using (var paymentsRepository = new Repository<PaymentsModel>(mainDBContext))
            {
                var model = new PaymentsModel()
                {
                    InvoiceId = InvoiceId,
                    Amount = Amount,
                    PaymentDateTime = DateTime.UtcNow,
                    TrackingNo = TrackingNo,
                    PaymentGatewayId = (int)paymentGateway,
                };
                paymentsRepository.Add(model);
                paymentsRepository.SaveChanges();
            }

        }
        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            invoicesRepository?.Dispose();
            studentUserFinincesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
