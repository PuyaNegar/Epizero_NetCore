using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseMeetingDedicatedTeachersService : IDisposable
    {
        private CourseMeetingDedicatedTeachersComponent courseMeetingDedicatedTeachersComponent;
        //=====================================================
        public CourseMeetingDedicatedTeachersService()
        {
            courseMeetingDedicatedTeachersComponent = new CourseMeetingDedicatedTeachersComponent();
        }
        //=====================================================
        public SysResult AddOrUpdate(CourseMeetingDedicatedTeachersViewModel viewModel, int currentUserId)
        {
            var model = new CourseMeetingDedicatedTeachersModel()
            {
                ModDateTime = DateTime.UtcNow,
                CourseMeetingId = viewModel.CourseMeetingId,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                TeacherUserId = viewModel.TeacherUserId,
            };
            courseMeetingDedicatedTeachersComponent.AddOrUpdate(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=====================================================
        public SysResult Find(int courseMeetingId)
        {
            var result = courseMeetingDedicatedTeachersComponent.Find(courseMeetingId);
            var viewModel = new CourseMeetingDedicatedTeachersViewModel()
            {
                Id = result.Id,
                TeacherUserId = result.TeacherUserId,
                CourseMeetingId = result.CourseMeetingId,
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, Value = viewModel };
        } 
        //=====================================================
        public void Dispose()
        {
            courseMeetingDedicatedTeachersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
