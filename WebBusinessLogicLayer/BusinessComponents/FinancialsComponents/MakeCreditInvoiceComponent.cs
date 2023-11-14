using Common.Enums;
using Common.Extentions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class MakeCreditInvoiceComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<InvoicesModel> invoicesRepository;
        //=========================================================================================
        public MakeCreditInvoiceComponent()
        {
            mainDBContext = new MainDBContext();
            this.invoicesRepository = new Repository<InvoicesModel>(mainDBContext);
        }
        //=========================================================================================
        public void Operation(int UserId, int TotalPayment, ref string InvoiceNo)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    InvoicesModel InvoiceModel = new InvoicesModel() { InvoiceNo = string.Empty };
                    if (TotalPayment > 0)
                    {
                        InvoiceModel = MakeInvoice(UserId, TotalPayment);
                    }
                    transaction.Commit();
                    InvoiceNo = InvoiceModel.InvoiceNo;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=========================================================================================
        private InvoicesModel MakeInvoice(int studentUserId, int TotalPayment)
        {
            var model = new InvoicesModel()
            {
                IssuedDateTime = DateTime.UtcNow,
                InvoiceStatusDateTime = DateTime.UtcNow,
                InvoiceTypeId = (int)InvoiceType.ChargeCredit,
                InvoiceStatusTypeId = (int)InvoiceStatusType.SendToGateWay,
                InvoiceNo = studentUserId.InvoiceNo(),
                TotalPrice = TotalPayment,
                StudentUserId = studentUserId,
            };
            invoicesRepository.Add(model);
            invoicesRepository.SaveChanges();
            return model;
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
        //===================================================================================
    }
}
