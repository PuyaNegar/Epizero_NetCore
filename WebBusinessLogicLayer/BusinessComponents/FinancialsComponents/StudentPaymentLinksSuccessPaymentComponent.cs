using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using System.Linq;
using Common.Extentions;
using DataModels.FinancialsModels;
using System.Collections.Generic;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentPaymentLinksSuccessPaymentComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentPaymentLinksModel> studentPaymentLinksRepository;
        public StudentPaymentLinksSuccessPaymentComponent()
        {
            mainDBContext = new MainDBContext();
            studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>(mainDBContext);
        }
        //====================================================================================================
        public void Opration(List<int> studentPaymentLinkIds, int studentUserId, ref string InvoiceNo)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var TotalPayment = studentPaymentLinksRepository.Where(c => studentPaymentLinkIds.Contains(c.Id)).Sum(c => c.AmountPayable);
                    var invoice = CreateInvoice(studentUserId, TotalPayment);
                    FinalizeStudentPaymentLinks(studentPaymentLinkIds, invoice);
                    CreateFininceTransaction(invoice);
                    AddStudentFinancialPayments(studentPaymentLinkIds, studentUserId, invoice.InvoiceNo);
                    transaction.Commit();
                    InvoiceNo = invoice.InvoiceNo;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=======================================================================================================
        InvoicesModel CreateInvoice(int userId, int TotalPayment)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceTypeId = (int)InvoiceType.StudentPaymentLink,
                    InvoiceStatusTypeId = (int)InvoiceStatusType.SuccessPayment,
                    InvoiceNo = userId.InvoiceNo(),
                    TotalPrice = TotalPayment,
                    StudentUserId = userId,
                };
                invoicesRepository.Add(model);
                invoicesRepository.SaveChanges();
                return model;
            }
        }
        //=======================================================================================================
        void FinalizeStudentPaymentLinks(List<int> studentPaymentLinkIds, InvoicesModel Invoices)
        {
            using (var studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>(mainDBContext))
            {
                var studentPaymentLinks = studentPaymentLinksRepository.Where(c => studentPaymentLinkIds.Contains(c.Id)).ToList();
                foreach (var studentPaymentLink in studentPaymentLinks)
                {
                    studentPaymentLink.IsPaid = true;
                    studentPaymentLink.PaymentDateTime = DateTime.UtcNow;
                    studentPaymentLink.InvoiceId = Invoices.Id; 
                    studentPaymentLinksRepository.Update(studentPaymentLink);
                }
                studentPaymentLinksRepository.SaveChanges();
            } 
        }
        //====================================================================================
        void CreateFininceTransaction(InvoicesModel invoicesModel)
        {
            using (var studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext))
            {
                studentUserFinincesComponent.Withdraw(null, invoicesModel.Id, invoicesModel.StudentUserId, invoicesModel.TotalPrice);
            }
        }
        //====================================================================================
        void AddStudentFinancialPayments(List<int> studentPaymentLinkIds, int studentUserId, string InvoiceNo)
        {
            using (var studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext))
            {
                var studentPaymentLinks = studentPaymentLinksRepository.Where(c => studentPaymentLinkIds.Contains(c.Id), c=>c.CourseMeetingStudent.Course).ToList();
                foreach (var studentPaymentLink in studentPaymentLinks)
                {
                    studentFinancialPaymentsRepository.Add(new StudentFinancialPaymentsModel()
                    {
                        StudentUserId = studentUserId,
                        StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.PaymentLink,
                        RegDateTime = DateTime.UtcNow,
                        ModUserId = studentUserId, 
                        CourseMeetingStudentId = studentPaymentLink.CourseMeetingStudentId,
                        AmountPaid = studentPaymentLink.AmountPayable,
                        Description = "تسویه لینک پرداخت دوره # به شماره صورتحساب".Replace("#" , studentPaymentLink.CourseMeetingStudent.Course.Name) + InvoiceNo,
                    });
                }
                studentFinancialPaymentsRepository.SaveChanges();
            }
        }
        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            studentPaymentLinksRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
        //===================================================================================
    }
}
