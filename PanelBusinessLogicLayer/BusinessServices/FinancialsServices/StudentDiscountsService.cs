using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices 
{
    public class StudentDiscountsService : IDisposable
    {
        private StudentDiscountsComponent studentDiscountsComponent;
        //=======================================================
        public StudentDiscountsService()
        {
            studentDiscountsComponent = new StudentDiscountsComponent();
        }
        //=======================================================
        public SysResult Update (int studentFinancialDebtId , StudentDiscountsViewModel viewModel , int currentUserId )
        {
            studentDiscountsComponent.Update(studentFinancialDebtId , viewModel,  currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        } 
        //=======================================================
        public void Dispose()
        {
            studentDiscountsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
