using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents;
using PanelViewModels.TeacherFinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices
{
    public class TeacherMultiCoursesShareService : IDisposable
    {
        private TeacherMultiCoursesShareComponent teacherMultiCoursesShareComponent;
        //======================================================
        public TeacherMultiCoursesShareService()
        {
            teacherMultiCoursesShareComponent = new TeacherMultiCoursesShareComponent(); 
        }
        //======================================================
        public SysResult<TeacherMultiCoursesShareViewModel> Calculate(int teacherUserId )
        {
            var result = teacherMultiCoursesShareComponent.Calculate(teacherUserId);
            return new SysResult<TeacherMultiCoursesShareViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result }; 
        }
        //======================================================
        public void Dispose()
        {
            teacherMultiCoursesShareComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
