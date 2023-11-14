using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OrdersComponents; 
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class OnlineRegistrationFinancialExportService : IDisposable
    {
        private OnlineRegistrationFinancialExportComponent onlineRegistrationFinancialExportComponent;
        //===============================================================================
        public OnlineRegistrationFinancialExportService()
        {
            onlineRegistrationFinancialExportComponent = new  OnlineRegistrationFinancialExportComponent();
        }
        //===============================================================================
        public SysResult<ExcelExportViewModel> ExcelExport(List<int> courseIds)
        {
            var result = onlineRegistrationFinancialExportComponent.ExcelExport(courseIds);
            return new SysResult<ExcelExportViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public void Dispose()
        {
            onlineRegistrationFinancialExportComponent?.Dispose();
            GC.SuppressFinalize(this); 
        }
        //===============================================================================
    }
}
