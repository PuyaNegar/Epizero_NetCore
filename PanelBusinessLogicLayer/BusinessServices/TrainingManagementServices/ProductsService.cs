using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class ProductsService : IDisposable
    {
        private ProductsComponent productsComponent;
        public ProductsService()
        {
            this.productsComponent = new ProductsComponent();
        }
        //===================================================================
        public SysResult Read()
        {

            var result = productsComponent.Read();
            //**********************************************  عملیات نگاشت
            var viewModel = result.Select(c => new ProductsViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                ProductTypeName = c.ProductType.Name,
                Price = c.Price,
                DiscountPrice = c.DiscountPrice

            });
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(ProductsViewModel viewModel, int UserId)
        {
            if (string.IsNullOrEmpty(viewModel.FilePath))
                throw new CustomException("فایل  نبایستی خالی باشد.");
            ProductsModel model = new ProductsModel()
            {
                Name = viewModel.Name,
                IsActive = viewModel.IsActive.ToBoolean(),
                Price = viewModel.Price,
                PicPath = viewModel.PicPath,
                DiscountPrice = viewModel.DiscountPrice,
                FilePath = viewModel.FilePath,
                ProductTypeId = viewModel.ProductTypeId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = UserId
            };
            //**********************************************
            productsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };

        }
        //=================================================================================
        public SysResult<ProductsViewModel> Find(int Id)
        {

            var result = productsComponent.Find(Id);
            var viewModel = new ProductsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                IsActive = result.IsActive.ToActiveStatus(),
                Price = result.Price,
                PicPath = result.PicPath,
                DiscountPrice = result.DiscountPrice,
                FilePath = result.FilePath,
                ProductTypeId = result.ProductTypeId,
            };
            //**********************************************
            return new SysResult<ProductsViewModel>() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };


        }
        //=================================================================================
        public SysResult Update(ProductsViewModel viewModel, int UserId)
        {
            if (string.IsNullOrEmpty(viewModel.FilePath))
                throw new CustomException("فایل  نبایستی خالی باشد.");
            //**********************************************  عملیات نگاشت
            ProductsModel model = new ProductsModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                IsActive = viewModel.IsActive.ToBoolean(),
                Price = viewModel.Price,
                PicPath = viewModel.PicPath,
                DiscountPrice = viewModel.DiscountPrice,
                FilePath = viewModel.FilePath,
                ProductTypeId = viewModel.ProductTypeId,
                ModUserId = UserId
            };
            //**********************************************
            productsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };


        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> productsViewModel)
        {

            //**********************************************  عملیات نگاشت
            List<ProductsModel> model = productsViewModel.Select(a => new ProductsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            productsComponent.Delete(model);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = "عملیات حذف با موفقیت انجام شد" };

        }
        //===============================================================================
        public SysResult<ProductsViewModel> FindDescription(int Id)
        {
            var result = productsComponent.FindDescription(Id);
            var viewModel = new ProductsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };
            return new SysResult<ProductsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================================
        public SysResult UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            productsComponent.UpdateDescription(Id, Description.CharacterAnalysis(), CurrentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            productsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
