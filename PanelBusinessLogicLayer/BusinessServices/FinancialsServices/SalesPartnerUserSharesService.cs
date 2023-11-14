using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelBusinessLogicLayer.BusinessComponents.OrdersComponents;
using PanelViewModels.FinancialsViewModels;
using PanelViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class SalesPartnerUserSharesService : IDisposable
    {
        private SalesPartnerUserSharesComponent salesPartnerUserSharesComponent;
        private FinalizedOrdersComponent finalizedOrdersComponent;
        //========================================
        public SalesPartnerUserSharesService()
        {
            salesPartnerUserSharesComponent = new SalesPartnerUserSharesComponent();
            finalizedOrdersComponent = new FinalizedOrdersComponent();
        }
        //========================================
        public SysResult Read(int salesPartnerUserId)
        {
            if (salesPartnerUserId == 0)
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = new List<SalesPartnerUserSharesViewModel>() };
            var result = salesPartnerUserSharesComponent.Read(salesPartnerUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=========================================
        public SysResult<FinalizedOrdersViewModel> Find(int OrderId)
        {
            var result = finalizedOrdersComponent.FindWithCalculations(OrderId);
            result.OrderDetails = result.OrderDetails.Where(c => c.DiscountCodeAmount > 0).ToList();
            return new SysResult<FinalizedOrdersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //========================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            salesPartnerUserSharesComponent?.Dispose();
            finalizedOrdersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
