using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents;
using PanelViewModels.TeacherFinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices
{
   public class TeacherFinancialDashboardService : IDisposable
    {
        private TeacherFinancialDashboardComponent teacherFinancialDashboardComponent;
        //============================================================================
        public TeacherFinancialDashboardService()
        {
            teacherFinancialDashboardComponent = new TeacherFinancialDashboardComponent(); 
        }
        //============================================================================
        public SysResult<TeacherFinancialDashboardViewModel> Read (int teacherUserId )
        {
           var result =  teacherFinancialDashboardComponent.Read(teacherUserId);
            return new SysResult<TeacherFinancialDashboardViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherFinancialDashboardComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
