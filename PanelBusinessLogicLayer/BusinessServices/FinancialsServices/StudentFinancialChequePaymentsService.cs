using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using Common.Extentions;
using System.Linq;
using System.Collections.Generic;
using PanelViewModels.BaseViewModels;
using DataModels.FinancialsModels;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinancialChequePaymentsService : IDisposable
    {
        private StudentFinancialChequePaymentsComponent studentChequesComponent;
        //========================================================================================
        public StudentFinancialChequePaymentsService()
        {
            studentChequesComponent = new StudentFinancialChequePaymentsComponent();
        }
        //========================================================================================
        public SysResult<List<StudentFinancialChequePaymentsViewModel>> Read(int studentUserId)
        {
            var result = studentChequesComponent.Read(studentUserId).Select(c => new StudentFinancialChequePaymentsViewModel()
            {
                AmountPaid = c.StudentFinancialPayment.AmountPaid,
                BankName = c.PaidCheque.Bank.Name,
                ChequeNo = c.PaidCheque.ChequesNo,
                DueDate = c.PaidCheque.DueDate.ToLocalDateTime().ToDateShortFormatString(),
                IssueDate = c.PaidCheque.IssueDate.ToLocalDateTime().ToDateShortFormatString(),
            }).ToList();
            return new SysResult<List<StudentFinancialChequePaymentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //========================================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        {
            studentChequesComponent.Delete(viewModel.Id.Value);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================================
        public SysResult Add(StudentFinancialChequePaymentsViewModel viewModel, int currentUserId)
        {
            var studentChequesModel = new StudentChequesModel()
            {
                PaidChequeId = viewModel.PaidChequeId , 
                ModDateTime = DateTime.UtcNow,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
            };
            var studentFinancialPaymentsModel = new StudentFinancialPaymentsModel()
            {
                Description = viewModel.Description,
                RegDateTime = DateTime.UtcNow,
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId, 
                CourseMeetingStudentId = viewModel.CourseMeetingStudentId,
                StudentUserId = viewModel.StudentUserId,
                AmountPaid = viewModel.AmountPaid,
                StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.Cheque,
            };
            studentChequesComponent.Add(studentChequesModel, studentFinancialPaymentsModel);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=======================================================
        public SysResult Find(int studentFinancialPaymentId)
        {
            var result = studentChequesComponent.Find(studentFinancialPaymentId);
            var viewModel = new StudentFinancialChequePaymentsViewModel()
            {
                ChequesStatusTypeId =  result.PaidCheque.ChequesStatusTypeId,
                StudentFinancialPaymentId = result.StudentFinancialPaymentId,
                AmountPaid = result.StudentFinancialPayment.AmountPaid,
                BankName = result.PaidCheque.Bank.Name,
                ChequeNo = result.PaidCheque.ChequesNo,
                Description = result.StudentFinancialPayment.Description,
                DueDate = result.PaidCheque.DueDate.ToLocalDateTime().ToDateShortFormatString(),
                IssueDate = result.PaidCheque.IssueDate.ToLocalDateTime().ToDateShortFormatString(),
                StudentUserId = result.StudentFinancialPayment.StudentUserId,
                CourseMeetingStudentId = result.StudentFinancialPayment.CourseMeetingStudentId == null ? 0 : result.StudentFinancialPayment.CourseMeetingStudentId.Value,
                CourseName = result.StudentFinancialPayment.CourseMeetingStudentId == null ? "ثبت نشده" : result.StudentFinancialPayment.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? result.StudentFinancialPayment.CourseMeetingStudent.Course.Name : result.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Name + " (" + result.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        } 
        //========================================================================================
        #region DisposeObject
        public void Dispose()
        {
            studentChequesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
