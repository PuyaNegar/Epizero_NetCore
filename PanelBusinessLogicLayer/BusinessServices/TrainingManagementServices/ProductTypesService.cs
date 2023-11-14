using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class ProductTypesService : IDisposable
    {
        private ProductTypesComponent productTypesComponent;
        public ProductTypesService()
        {
            this.productTypesComponent = new ProductTypesComponent();
        }
        //===================================================================
        public SysResult Read()
        {

            var result = productTypesComponent.Read();
            //**********************************************  عملیات نگاشت
            var viewModel = result.Select(c => new ProductTypesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            });
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(ProductTypesViewModel viewModel, int UserId)
        {

            //**********************************************  عملیات نگاشت
            ProductTypesModel model = new ProductTypesModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                RegDateTime = DateTime.UtcNow,
                ModUserId = UserId
            };
            //**********************************************
            productTypesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };

        }
        //=================================================================================
        public SysResult<ProductTypesViewModel> Find(int Id)
        {

            var result = productTypesComponent.Find(Id);
            //**********************************************  عملیات نگاشت
            var viewModel = new ProductTypesViewModel()
            {
                Id = result.Id,
                Name = result.Name
            };
            //**********************************************
            return new SysResult<ProductTypesViewModel>() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };


        }
        //=================================================================================
        public SysResult Update(ProductTypesViewModel viewModel, int UserId)
        {

            //**********************************************  عملیات نگاشت
            ProductTypesModel model = new ProductTypesModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                ModUserId = UserId
            };
            //**********************************************
            productTypesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };


        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> productTypesViewModel)
        {

            //**********************************************  عملیات نگاشت
            List<ProductTypesModel> model = productTypesViewModel.Select(a => new ProductTypesModel()
            {
                Id = a.Id.Value,
            }).ToList();
            productTypesComponent.Delete(model);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = "عملیات حذف با موفقیت انجام شد" };

        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {

            var result = productTypesComponent.Read();
            //**********************************************  عملیات نگاشت
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).ToList();
            //**********************************************
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };

        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            productTypesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
