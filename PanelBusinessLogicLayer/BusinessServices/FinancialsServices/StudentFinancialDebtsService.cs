using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinancialDebtsService : IDisposable
    {
        private StudentFinancialDebtsComponent studentFinancialDebtsComponent;
        //================================================
        public StudentFinancialDebtsService()
        {
            studentFinancialDebtsComponent = new StudentFinancialDebtsComponent();
        }
        //==================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel , int currentUserId)
        {
            var model = new StudentFinancialDebtsModel()
            {
                Id = viewModel.Id.Value,
            };
            studentFinancialDebtsComponent.Delete(model , currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            studentFinancialDebtsComponent?.Dispose();
        }
        #endregion
    }
}
