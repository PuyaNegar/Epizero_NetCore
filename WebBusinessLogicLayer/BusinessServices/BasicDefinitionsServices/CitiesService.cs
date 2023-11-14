using Common.Extentions;
using Common.Objects;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.SystemsComponents;
using WebViewModels.BasicDefinitionsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
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
        public SysResult ReadByProvince(int provinceId)
        {
            var result = citiesComponent.ReadByProvince(provinceId);
            var viewModel = result.Select(c => new CitiesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
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
