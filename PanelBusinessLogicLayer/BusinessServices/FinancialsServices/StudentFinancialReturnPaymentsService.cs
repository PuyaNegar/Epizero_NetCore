using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using Common.Extentions;
using PanelViewModels.BaseViewModels;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinancialReturnPaymentsService : IDisposable
    {
        private StudentFinancialReturnPaymentsComponent studentFinancialReturnPaymentsComponent;
        public StudentFinancialReturnPaymentsService()
        {
            studentFinancialReturnPaymentsComponent = new StudentFinancialReturnPaymentsComponent();
        }
        //=============================================
        public SysResult Add(StudentFinancialReturnPaymentsViewModel viewModel, int currentUserId)
        {
            var model = new StudentFinancialReturnPaymentsModel()
            {
                Description = viewModel.Description,
                ModUserId = currentUserId,
                CourseMeetingStudentId = viewModel.CourseMeetingStudentId , 
                StudentUserId = viewModel.StudentUserId,
                ReturnPaymentTypeId = viewModel.ReturnPaymentTypeId,
                ReturnAmount = viewModel.ReturnAmount,
                RegDateTime = DateTime.UtcNow,
                ModDateTime = DateTime.UtcNow,
            };
            studentFinancialReturnPaymentsComponent.Add(model , (PaymentType) viewModel.PaymentTypeId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Find(int Id)
        {
            var result = studentFinancialReturnPaymentsComponent.Find(Id);
            var viewModel = new StudentFinancialReturnPaymentsViewModel()
            {
                Id = result.Id,
                Description = result.Description,
                AmountPaidDateTime = result.RegDateTime.ToLocalDateTimeShortFormatString(),
                StudentUserId = result.StudentUserId,
                ReturnAmount = result.ReturnAmount,
                CourseMeetingStudentId = result.CourseMeetingStudentId == null ? 0 : result.CourseMeetingStudentId.Value, 
                CourseName = result.CourseMeetingStudentId == null ?  "ثبت نشده" : result.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? result.CourseMeetingStudent.Course.Name : result.CourseMeetingStudent.CourseMeeting.Name + " (" + result.CourseMeetingStudent.CourseMeeting.Course.Name + ") ", 
                RegDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                ReturnPaymentTypeId = result.ReturnPaymentTypeId,
                StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully , Value = viewModel };
        }
        //===============================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        {
            var model = new StudentFinancialReturnPaymentsModel()
            {
                Id = viewModel.Id.Value,
            };
            studentFinancialReturnPaymentsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialReturnPaymentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
