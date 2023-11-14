using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using Common.Objects;
using PanelViewModels.TrainingManagementViewModels;

namespace BusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class FieldsService : IDisposable
    {
        private FieldsComponent fieldsComponent;
        //===============================================================================
        public FieldsService()
        {
            fieldsComponent = new FieldsComponent();
        }
        //===============================================================================
        public SysResult<List<FieldsViewModel>> Read()
        {
            var result = fieldsComponent.Read().Select(c => new FieldsViewModel()
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return new SysResult<List<FieldsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult<FieldsViewModel> Find(int id)
        {
            var result = fieldsComponent.Find(id);
            var model = new FieldsViewModel()
            {
                Id = result.Id,
                Name = result.Name

            };
            return new SysResult<FieldsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = fieldsComponent.Read().OrderBy(c => c.Id).Select(c => new ComboBoxItems()
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
            fieldsComponent?.Dispose();
        }
        #endregion
    }
}
