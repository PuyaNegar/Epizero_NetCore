using Common.Extentions;
using Common.Objects;
using DataModels.BasicDefinitionsModels;
using PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents; 
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class ProvincesServices : IDisposable
    {
        private ProvincesComponent provincesComponent;
        //========================================================================================
        public ProvincesServices()
        {
            this.provincesComponent = new ProvincesComponent();
        }
        //========================================================================================
        public SysResult Add(ProvincesViewModel viewModel, int CurrentUserId)
        {
            ProvincesModel model = new ProvincesModel()
            {
                Name = viewModel.Name,
                CountryId = 1,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId
            };
            provincesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //========================================================================================
        public SysResult Read()
        {
            var result = provincesComponent.Read();
            var viewModel = result.Select(c => new ProvincesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult<ProvincesViewModel> Find(int Id)
        {
            var result = provincesComponent.Find(Id);
            var viewModel = new ProvincesViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                IsActive = result.IsActive.ToActiveStatus()
            };
            return new SysResult<ProvincesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult Update(ProvincesViewModel provincesViewModel, int CurrentUserId)
        {
            var model = new ProvincesModel()
            {
                Id = provincesViewModel.Id,
                Name = provincesViewModel.Name,
                CountryId = 1,
                IsActive = provincesViewModel.IsActive.ToBoolean(),
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow
            };
            provincesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //========================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            provincesComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
                var result = provincesComponent.Read();
                var viewModel = result.Select(c => new ComboBoxItems()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
                return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
       
        //========================================================================================Disposing
        #region DisposeObjects
        public void Dispose()
        {
            provincesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}