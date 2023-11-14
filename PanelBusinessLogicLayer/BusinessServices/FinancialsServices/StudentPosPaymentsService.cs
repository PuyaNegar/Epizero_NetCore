using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
   public class StudentPosPaymentsService : IDisposable
    {
        private StudentPosPaymentsComponent studentFinancialPaymentsComponent;
        //================================================  
        public StudentPosPaymentsService()
        {
            studentFinancialPaymentsComponent = new StudentPosPaymentsComponent();
        } 
        //================================================  
        public SysResult Find(int studentFinancialPaymentId)
        {
            var result = studentFinancialPaymentsComponent.Find(studentFinancialPaymentId);
            var viewModel = new StudentFinancialPosPaymentsViewModel()
            {
                AmountPaid = result.StudentFinancialPayment.AmountPaid,
                BankPosDeviceName = result.BankPosDevices.Bank.Name + " ( " + result.BankPosDevices.AccountNo + " ) ",
                TrackingNo = result.TrackingNo,
                RegDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                Description = result.StudentFinancialPayment.Description,
                StudentUserName = result.StudentFinancialPayment.StudentUser.FirstName + " " + result.StudentFinancialPayment.StudentUser.LastName , 
                CourseMeetingStudentId = result.StudentFinancialPayment.CourseMeetingStudentId == null ? 0 : result.StudentFinancialPayment.CourseMeetingStudentId.Value,
                CourseName = result.StudentFinancialPayment.CourseMeetingStudentId == null ? "ثبت نشده" : result.StudentFinancialPayment.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? result.StudentFinancialPayment.CourseMeetingStudent.Course.Name : result.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Name + " (" + result.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //================================================   
        public SysResult Add(StudentFinancialPosPaymentsViewModel viewModel, int currentUserId)
        {
            var posPaymentsModel = new StudentPosPaymentsModel()
            {
                BankPosDeviceId = viewModel.BankPosDeviceId,
                TrackingNo = viewModel.TrackingNo,
                RegDateTime = viewModel.RegDateTime.ToDate().ToUtcDateTime(),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
            };
            var studentFinancialPaymentsModel = new StudentFinancialPaymentsModel()
            {
                Description = viewModel.Description,
                RegDateTime = viewModel.RegDateTime.ToDate().ToUtcDateTime(),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                StudentUserId = viewModel.StudentUserId,
                CourseMeetingStudentId = viewModel.CourseMeetingStudentId,
                AmountPaid = viewModel.AmountPaid,
                StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.Pos,
            };
            studentFinancialPaymentsComponent.Add(posPaymentsModel, studentFinancialPaymentsModel);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //================================================   
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        {
            studentFinancialPaymentsComponent.Delete(viewModel.Id.Value);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================== 
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialPaymentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
