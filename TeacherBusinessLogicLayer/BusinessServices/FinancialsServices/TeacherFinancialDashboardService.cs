using Common.Objects;
using System; 
using TeacherBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using TeacherViewModels.FinancialsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.FinancialsServices
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
