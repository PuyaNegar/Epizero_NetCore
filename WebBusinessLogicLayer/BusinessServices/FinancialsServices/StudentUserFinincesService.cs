using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents; 
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentUserFinincesService : IDisposable
    {
        private StudentUserFinincesComponent studentUserFinincesComponent;
        //==================================================================================
        public StudentUserFinincesService()
        {
            this.studentUserFinincesComponent = new  StudentUserFinincesComponent();
        }
        //==================================================================================
        public SysResult<BalanceViewModel> GetBalance(int studentUserId)
        {
            var result = studentUserFinincesComponent.GetBalance(studentUserId);
            var viewModel = new BalanceViewModel();
            viewModel.Balance = result != 0 ? result : 0;
            return new SysResult<BalanceViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //==================================================================================
        public SysResult<TransactionsResponseViewModel> Read(int Page, int Count, int CustomerId)
        {
            Page = Page > 0 ? Page - 1 : 0;
            var result = studentUserFinincesComponent.Read(Page, Count, CustomerId);
            return new SysResult<TransactionsResponseViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //==================================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentUserFinincesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
