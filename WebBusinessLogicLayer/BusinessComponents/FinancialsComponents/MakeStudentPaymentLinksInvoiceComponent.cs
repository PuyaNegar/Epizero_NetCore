using Common.Enums;
using Common.Extentions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class MakeStudentPaymentLinksInvoiceComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentPaymentLinksModel> studentPaymentLinksRepository;
        //=========================================================================================
        public MakeStudentPaymentLinksInvoiceComponent()
        {
            mainDBContext = new MainDBContext();
            studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>(mainDBContext);
        }
        //=========================================================================================
        public void Operation(int studentUserId, bool UseCredit,  ref string InvoiceNo, ref int FinalAmountPayable , ref string studentPaymentLinkIds)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                { 
                    GetStudentPaymentLinks(studentUserId, UseCredit , out studentPaymentLinkIds, out FinalAmountPayable);
                    var InvoiceModel = new InvoicesModel() { InvoiceNo = string.Empty };
                    if (FinalAmountPayable > 0)
                        InvoiceModel = MakeInvoice(studentUserId, FinalAmountPayable);
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
        void GetStudentPaymentLinks(int studentUserId, bool UseCredit ,  out string studentPaymentLinkIds, out int FinalAmountPayable)
        {
            var result = studentPaymentLinksRepository.Where(c => !c.IsPaid && c.CourseMeetingStudent.StudentUserId == studentUserId).ToList();
            FinalAmountPayable = result.Sum(c => c.AmountPayable);
            studentPaymentLinkIds = string.Join(",", result.Select(c => c.Id));

            int WalletBalance = 0;
            if (UseCredit)
                using (var studentUserFinincesComponent = new StudentUserFinincesComponent())
                {
                    WalletBalance = studentUserFinincesComponent.GetBalance(studentUserId);
                }
            FinalAmountPayable = FinalAmountPayable - WalletBalance; 
        } 
        //=========================================================================================
        private InvoicesModel MakeInvoice(int studentUserId, int TotalPayment)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
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
        }
 
        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //===================================================================================
    }
}
