using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents; 
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class IdentifierChargeSettingsService : IDisposable
    {
        private IdentifierChargeSettingsComponent identifierChargeSettingsComponent;
        //=================================================================================
        public IdentifierChargeSettingsService()
        {
            this.identifierChargeSettingsComponent = new IdentifierChargeSettingsComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = identifierChargeSettingsComponent.Read(); 
            var viewModel = result.Select(c => new IdentifierChargeSettingsViewModel()
            {
                Id = c.Id,
                IdentifierChargeAmount = c.IdentifierChargeAmount, 
                RegisteredUserChargeAmount = c.RegisteredUserChargeAmount,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال", 
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel }; 
        }
        //=================================================================================
        public SysResult<IdentifierChargeSettingsViewModel> Find()
        {
            var result = identifierChargeSettingsComponent.Find();
            var viewModel = new IdentifierChargeSettingsViewModel()
            {
                Id = result.Id,
                RegisteredUserChargeAmount = result.RegisteredUserChargeAmount,
                IdentifierChargeAmount = result.IdentifierChargeAmount,
                IsActive = result.IsActive.ToActiveStatus(), 
            };
            return new SysResult<IdentifierChargeSettingsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(IdentifierChargeSettingsViewModel viewModel, int currentUserId)
        {
            var model = new IdentifierChargeSettingsModel()
            {
                Id = viewModel.Id,
                IdentifierChargeAmount = viewModel.IdentifierChargeAmount,
                IsActive = viewModel.IsActive.ToBoolean(),
                ModDateTime = DateTime.UtcNow,
                RegisteredUserChargeAmount = viewModel.RegisteredUserChargeAmount,
                ModUserId = currentUserId, 
            };
            identifierChargeSettingsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited   };
        }
        //========================================================================================Disposing
        #region DisposeObjects
        public void Dispose()
        {
            identifierChargeSettingsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
