using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialReturnPaymentsComponent : IDisposable
    {
        MainDBContext mainDBContext;
        private Repository<StudentFinancialReturnPaymentsModel> studentReturnPaymentsRepository;
        private StudentUserFinincesComponent studentUserFinincesComponent;
        StudentUserScoresComponent studentUserScoresComponent; 
        //=================================================================
        public StudentFinancialReturnPaymentsComponent()
        {
            mainDBContext = new MainDBContext();
            studentReturnPaymentsRepository = new Repository<StudentFinancialReturnPaymentsModel>(mainDBContext);
            studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext);
            studentUserScoresComponent = new StudentUserScoresComponent(mainDBContext);
        }
        //=================================================================
        public List<StudentFinancialReturnPaymentsViewModel> Read(int studentUserId)
        {
            var result = studentReturnPaymentsRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentUser, c => c.ReturnPaymentType, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting.Course, c => c.ModUser).Select(c => new StudentFinancialReturnPaymentsViewModel()
            {
                Id = c.Id,
                StudentUserId = c.StudentUserId,
                ReturnAmount = c.ReturnAmount,
                AmountPaidDateTime = c.RegDateTime.ToDateShortFormatString(),
                ReturnPaymentTypeId = c.ReturnPaymentTypeId,
                Description = c.Description,
                CourseName = c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                ReturnPaymentTypeName = c.ReturnPaymentType.Name,
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
            }).ToList();
            return result;
        }
        //=================================================================
        public void Add(StudentFinancialReturnPaymentsModel model, PaymentType paymentType)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    if (model.ReturnPaymentTypeId != (int)ReturnPaymentType.Cash)
                        paymentType = PaymentType.Normal;
                    studentReturnPaymentsRepository.Add(model);
                    studentReturnPaymentsRepository.SaveChanges();
                    if (paymentType == PaymentType.Credit)
                        studentUserFinincesComponent.Deposit(null, CreateInvoice(model.StudentUserId, model.ReturnAmount).Id, model.StudentUserId, model.ReturnAmount);
                    if (paymentType == PaymentType.EpizeroCoin)
                        studentUserScoresComponent.IncreaseScoreByPrice(model.StudentUserId, model.ReturnAmount, UserScoreType.IncreaseCreditsDueStudentFinancialReturnPayment  ,  model.Description, model.ModUserId );
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=================================================================
        public StudentFinancialReturnPaymentsModel Find(int Id)
        {
            var result = studentReturnPaymentsRepository.SingleOrDefault(c => c.Id == Id, c => c.StudentUser, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting.Course);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //================================================================= 
        public void Delete(StudentFinancialReturnPaymentsModel model)
        {
            studentReturnPaymentsRepository.Delete(c => c.Id == model.Id);
            studentReturnPaymentsRepository.SaveChanges();
        }
        //=================================================================
        InvoicesModel CreateInvoice(int userId, int TotalPayment)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceTypeId = (int)InvoiceType.IncreaseCreditsDueStudentFinancialReturnPayment,
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
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentReturnPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
