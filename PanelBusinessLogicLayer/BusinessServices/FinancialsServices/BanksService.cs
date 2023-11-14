using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class BanksService : IDisposable
    {
        private BanksComponent banksComponent;
        //================================================
        public BanksService()
        {
            banksComponent = new BanksComponent();
        }
        //================================================

        public SysResult Add(BanksViewModel request, int CurrentUserId)
        {
            var model = new BanksModel()
            {
                Name = request.Name,
                ModUserId = CurrentUserId,
                RegDateTime = DateTime.UtcNow,
            };
            banksComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };

        }
        //===============================================================================
        public SysResult Read()
        {
            var result = banksComponent.Read().Select(c => new BanksViewModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(BanksViewModel request, int CurrentUserId)
        {
            var model = new BanksModel()
            {
                Id = request.Id,
                Name = request.Name,
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow
            };
            banksComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited  };
        }
        //===============================================================================
        public SysResult<BanksViewModel> Find(int Id)
        {
            var result = banksComponent.Find(Id);
            var model = new BanksViewModel()
            {
                Id = result.Id,
                Name = result.Name
            };
            return new SysResult<BanksViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new BanksModel()
            {
                Id = c.Id.Value,
            }).ToList();
            banksComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        } 
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = banksComponent.Read().OrderBy(c => c.Id).Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
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
            banksComponent?.Dispose();
        }
        #endregion
    }
}
