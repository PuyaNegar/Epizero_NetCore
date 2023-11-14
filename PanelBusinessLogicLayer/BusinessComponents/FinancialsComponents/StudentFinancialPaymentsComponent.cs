using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Extentions;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialPaymentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentFinancialPaymentsModel> studentFinancialPaymentsRepository;
        StudentUserFinincesComponent studentUserFinincesComponent;
        StudentUserScoresComponent studentUserScoresComponent;
        //=============================================================
        public StudentFinancialPaymentsComponent()
        {
            mainDBContext = new MainDBContext();
            studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext);
            studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext);
            studentUserScoresComponent = new StudentUserScoresComponent(mainDBContext);
        }
        //=============================================================
        public List<StudentFinancialPaymentsViewModel> Read(int studentUserId)
        {
            var result = studentFinancialPaymentsRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentFinancialPaymentType, c => c.StudentUser, c => c.CourseMeetingStudent.CourseMeeting.Course, c => c.CourseMeetingStudent.Course, c => c.ModUser).ToList().Select(c => new StudentFinancialPaymentsViewModel()
            {
                Id = c.Id,
                RequestReferenceNumber = string.IsNullOrEmpty(c.RequestReferenceNumber) ? null : c.RequestReferenceNumber,
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                AmountPaid = c.AmountPaid,
                Description = c.Description,
                StudentFinancialPaymentTypeName = c.StudentFinancialPaymentType.Name,
                StudentFinancialPaymentTypeId = c.StudentFinancialPaymentTypeId,
                AmountPaidDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                CourseMeetingStudentId = c.CourseMeetingStudentId == null ? 0 : c.CourseMeetingStudentId.Value,
                CourseName = c.CourseMeetingStudentId == null ? "ثبت نشده" : c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
            }).ToList();
            return result;
        }
        //=============================================================
        public void Add(StudentFinancialPaymentsModel model, PaymentType paymentType)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    studentFinancialPaymentsRepository.Add(model);
                    studentFinancialPaymentsRepository.SaveChanges();

                    if (model.StudentFinancialPaymentTypeId != (int)StudentFinancialPaymentTypes.Cash)
                        paymentType = PaymentType.Normal;

                    if (paymentType == PaymentType.Credit)
                        studentUserFinincesComponent.Withdraw(null, CreateInvoice(model.StudentUserId, model.AmountPaid, InvoiceType.DecreaseCreditDueStudentFinancialPayment).Id, model.StudentUserId, model.AmountPaid);

                    if (paymentType == PaymentType.EpizeroCoin)
                        studentUserScoresComponent.DecreaseScoreByPrice(model.StudentUserId, model.AmountPaid, UserScoreType.DecreaseCreditDueStudentFinancialPayment, model.Description, model.ModUserId);


                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //==============================================================
        public void Delete(StudentFinancialPaymentsModel model)
        {
            studentFinancialPaymentsRepository.Delete(c => c.Id == model.Id);
            studentFinancialPaymentsRepository.SaveChanges();
        }
        //==============================================================
        InvoicesModel CreateInvoice(int userId, int TotalPayment, InvoiceType invoiceType)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceTypeId = (int)invoiceType,
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
        //=============================================================
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
