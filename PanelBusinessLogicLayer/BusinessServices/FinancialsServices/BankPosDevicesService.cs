using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class BankPosDevicesService : IDisposable
    {
        private BankPosDevicesComponent bankPosDevicesComponent;
        //================================================
        public BankPosDevicesService()
        {
            bankPosDevicesComponent = new BankPosDevicesComponent();
        }
        //================================================

        public SysResult Add(BankPosDevicesViewModel request, int CurrentUserId)
        {
            var model = new BankPosDevicesModel()
            {
                BankId = request.BankId,
                AccountNo = request.AccountNo,
                Description = request.Description,
                ModUserId = CurrentUserId,
                RegDateTime = DateTime.UtcNow,
            };
            bankPosDevicesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };

        }
        //===============================================================================
        public SysResult Read()
        {
            var result = bankPosDevicesComponent.Read().Select(c => new BankPosDevicesViewModel()
            {
                Id = c.Id,
                BankName = c.Bank.Name,
                AccountNo = c.AccountNo,
                Description = c.Description
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(BankPosDevicesViewModel request, int CurrentUserId)
        {
            var model = new BankPosDevicesModel()
            {
                Id = request.Id,
                BankId = request.BankId,
                AccountNo = request.AccountNo,
                Description = request.Description,
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow
            };
            bankPosDevicesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult<BankPosDevicesViewModel> Find(int Id)
        {
            var result = bankPosDevicesComponent.Find(Id);
            var model = new BankPosDevicesViewModel()
            {
                Id = result.Id,
                BankId = result.BankId,
                AccountNo = result.AccountNo,
                Description = result.Description
            };
            return new SysResult<BankPosDevicesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new BankPosDevicesModel()
            {
                Id = c.Id.Value,
            }).ToList();
            bankPosDevicesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = bankPosDevicesComponent.Read().OrderBy(c => c.Id).Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Bank.Name + "(" + c.AccountNo + ")"
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
            bankPosDevicesComponent?.Dispose();
        }
        #endregion
    }
}
