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
    public class CitiesService : IDisposable
    {
        private CitiesComponent citiesComponent { get; set; }
        //========================================================================================
        public CitiesService()
        {
            this.citiesComponent = new CitiesComponent();
        }
        //========================================================================================
        public SysResult Add(CitiesViewModel viewModel, int CurrentUserId)
        {
            var model = new CitiesModel()
            {
                Name = viewModel.Name,
                IsActive = viewModel.IsActive.ToBoolean(),
                ProvinceId = viewModel.ProvinceId,
                ModUserId = CurrentUserId,
                RegDateTime = DateTime.UtcNow
            };
            citiesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //========================================================================================
        public SysResult<CitiesViewModel> Find(int Id)
        {
            var result = citiesComponent.Find(Id);
            var viewModel = new CitiesViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                IsActive = result.IsActive.ToActiveStatus(),
                ProvinceId = result.ProvinceId
            };
            return new SysResult<CitiesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult Update(CitiesViewModel viewModel, int CurrentUserId)
        {
            CitiesModel model = new CitiesModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                IsActive = viewModel.IsActive.ToBoolean(),
                ProvinceId = viewModel.ProvinceId,
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow
            };
            citiesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //========================================================================================
        public SysResult ReadByProvince(int provinceId)
        {
            var result = citiesComponent.ReadByProvince(provinceId);
            //**********************************************  عملیات نگاشت
            var viewModel = result.Select(c => new CitiesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
            });
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {

            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            citiesComponent.Delete(Ids);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int ProvinceId)
        {
                var result = citiesComponent.ReadByProvince(ProvinceId);
                var viewModel = result.Select(c => new ComboBoxItems()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
                return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
       
        //============================================================================================== Disposing 
        #region DisposeObject
        public void Dispose()
        {
            citiesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
