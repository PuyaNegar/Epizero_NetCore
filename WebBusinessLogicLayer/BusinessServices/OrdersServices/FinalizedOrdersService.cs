using Common.Objects; 
using System;
using WebBusinessLogicLayer.BusinessComponents.OrdersComponents;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.OrdersServices
{
   public class FinalizedOrdersService : IDisposable
    {
        private FinalizedOrdersComponent finalizedOrdersComponent;
        //===================================================================
        public FinalizedOrdersService()
        {
            this.finalizedOrdersComponent = new FinalizedOrdersComponent();
        }
        //===================================================================
        public SysResult Read(int studentUserId )
        {
            var result = finalizedOrdersComponent.Read(studentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //=========================================================================================
        public SysResult<FinalizedOrdersViewModel> Find(int OrderId , int studentUserId )
        { 
            var viewModel = finalizedOrdersComponent.FindWithCalculations(OrderId , studentUserId );
            return new SysResult<FinalizedOrdersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            finalizedOrdersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
