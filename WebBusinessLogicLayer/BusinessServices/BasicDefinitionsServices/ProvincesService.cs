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
    public class ProvincesServices : IDisposable
    {
        private ProvincesComponent provincesComponent;
        //========================================================================================
        public ProvincesServices()
        {
            this.provincesComponent = new ProvincesComponent();
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