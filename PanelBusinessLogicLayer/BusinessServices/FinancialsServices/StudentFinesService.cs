using Common.Extentions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinesService : IDisposable
    {
        private StudentFinesComponent studentFinesComponent;
        //====================================
        public StudentFinesService()
        {
            studentFinesComponent = new StudentFinesComponent();
        }
        //====================================
        public SysResult Add(StudentFinesViewModel request, int currentUserId)
        {
            var model = new StudentFinesModel()
            {
                Amount = request.Amount,
                Description = request.Description,
                ModUserId = currentUserId,
                CourseMeetingStudentId = request.CourseMeetingStudentId, 
                StudentUserId = request.StudentUserId,
                RegDateTime = request.RegDateTime.ToDate().ToUtcDateTime(),
                ModDateTime = DateTime.UtcNow
            };
            studentFinesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //==================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel, int currentUserId)
        {
            var model = new StudentFinesModel()
            {
                Id = viewModel.Id.Value,
            };
            studentFinesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinesComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
