using Common.Extentions;
using Common.Objects;
using DataModels.BasicDefinitionsModels;
using PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class SmsOptionsService : IDisposable
    {
        private SmsOptionsComponent sMSOptionsComponent;
        //========================================================================================
        public SmsOptionsService()
        {
            this.sMSOptionsComponent = new SmsOptionsComponent();
        }
        //========================================================================================
        public SysResult Read()
        {
            var result = sMSOptionsComponent.Read();
            var viewModel = result.Select(c => new SmsOptionsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Price = c.Price,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult<SmsOptionsViewModel> Find(int Id)
        {
            var result = sMSOptionsComponent.Find(Id);
            var viewModel = new SmsOptionsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Price = result.Price,
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                IsActive = result.IsActive.ToActiveStatus()
            };
            return new SysResult<SmsOptionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult Update(SmsOptionsViewModel viewModel, int CurrentUserId)
        {
            var model = new SmsOptionsModel()
            {
                Id = viewModel.Id,
                Price = viewModel.Price,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            sMSOptionsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }

        //========================================================================================Disposing
        #region DisposeObjects
        public void Dispose()
        {
            sMSOptionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
