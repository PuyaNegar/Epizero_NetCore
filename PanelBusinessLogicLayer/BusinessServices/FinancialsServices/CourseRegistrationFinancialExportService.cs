using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelBusinessLogicLayer.BusinessComponents.OrdersComponents; 
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class CourseRegistrationFinancialExportService : IDisposable
    {
        private CourseRegistrationFinancialExportComponent offlineRegistrationFinancialExportComponent;
        //===============================================================================
        public CourseRegistrationFinancialExportService()
        {
            offlineRegistrationFinancialExportComponent = new  CourseRegistrationFinancialExportComponent();
        }
        //===============================================================================
        public SysResult<ExcelExportViewModel> ExcelExport(List<int> courseIds)
        {
            var result = offlineRegistrationFinancialExportComponent.ExcelExport(courseIds);
            return new SysResult<ExcelExportViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public void Dispose()
        { 
            offlineRegistrationFinancialExportComponent?.Dispose();
            GC.SuppressFinalize(this); 
        }
        //===============================================================================
    }
}
