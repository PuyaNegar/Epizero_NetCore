using Common.Enums;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class OrderErrorPaymentComponent : IDisposable
    {
        MainDBContext mainDBContext;
        Repository<InvoicesModel> invoicesRepository;
      
        //====================================================================================================
        public OrderErrorPaymentComponent()
        {
            mainDBContext = new MainDBContext();
            this.invoicesRepository = new Repository<InvoicesModel>(mainDBContext); 
        }
        //====================================================================================================
        public void Opration(string InvoiceNo)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var invoiceModel = invoicesRepository.Where(c => c.InvoiceNo == InvoiceNo && c.Order.OrderStatusTypeId != (int)OrderStatusType.Finalized).SingleOrDefault();
                    if (invoiceModel == null)
                        throw new Exception(SystemCommonMessage.DataWasNotFound); 
                    UpdateInvoiceStatus(invoiceModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //===================================================================================
        private void UpdateInvoiceStatus(InvoicesModel invoiceModel)
        {
            invoiceModel.InvoiceStatusDateTime = DateTime.UtcNow;
            invoiceModel.InvoiceStatusTypeId = (int)InvoiceStatusType.UnSuccessPayment;
            invoicesRepository.Update(invoiceModel);
            invoicesRepository.SaveChanges();
        }
        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            invoicesRepository?.Dispose(); 
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
