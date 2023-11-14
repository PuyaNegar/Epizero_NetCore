using Common.Objects;
using DataModels.BasicDefinitionsModels;
using PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class BaseInfosService : IDisposable
    {
        private BaseInfosComponent baseInfosComponent;
        //=================================================================================
        public BaseInfosService()
        {
            this.baseInfosComponent = new BaseInfosComponent();
        }
        //================================================================================= 
        public SysResult Read()
        {
            var result = baseInfosComponent.Read().Select(c => new BaseInfosViewModel()
            {
                Id = c.Id,
                EpizeroCoinPrice = c.EpizeroCoinPrice,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================================================= 
        public SysResult<BaseInfosViewModel> Find()
        {
            var result = baseInfosComponent.Find();
            var viewModel = new BaseInfosViewModel()
            {
                Id = result.Id,
                EpizeroCoinPrice = result.EpizeroCoinPrice,
            };
            return new SysResult<BaseInfosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(BaseInfosViewModel viewModel, int currentUserId)
        {
            var model = new BaseInfosModel()
            {
                Id = viewModel.Id,
                EpizeroCoinPrice = viewModel.EpizeroCoinPrice,
            };
            baseInfosComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
        }
        //========================================================================================Disposing
        #region DisposeObjects
        public void Dispose()
        {
            baseInfosComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
