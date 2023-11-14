using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
  public  class CalculateCourseMultiTeacherSharesService : IDisposable
    {
        private CalculateCourseMultiTeacherSharesComponent calculateCourseMultiTeacherSharesComponent;
        //===================================================
        public CalculateCourseMultiTeacherSharesService()
        {
            calculateCourseMultiTeacherSharesComponent = new CalculateCourseMultiTeacherSharesComponent(); 
        }
        //===================================================
        public SysResult<CalculateCourseMultiTeacherSharesViewModel> Calculate(int courseId)
        {
            var result = calculateCourseMultiTeacherSharesComponent.Calculate(courseId);
            return new SysResult<CalculateCourseMultiTeacherSharesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===================================================
        public void Dispose()
        {
            calculateCourseMultiTeacherSharesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        //===================================================
    }
}
