using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using System.Linq;
using DataModels.FinancialsModels;
using Common.Objects;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentPaymentLinksErrorPaymentComponent : IDisposable
    {
        MainDBContext mainDBContext;
        Repository<InvoicesModel> invoicesRepository;

        //====================================================================================================
        public StudentPaymentLinksErrorPaymentComponent()
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
                    var invoiceModel = invoicesRepository.Where(c => c.InvoiceNo == InvoiceNo && c.Order == null).SingleOrDefault();
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
