using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OrdersComponents;
using PanelViewModels.OrderViewModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessServices.OrdersServices
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
        public SysResult Read()
        {
            var result = finalizedOrdersComponent.Read();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }

        //=========================================================================================
        public SysResult<FinalizedOrdersViewModel> Find(int OrderId)
        {

            var viewModel = finalizedOrdersComponent.FindWithCalculations(OrderId);
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
