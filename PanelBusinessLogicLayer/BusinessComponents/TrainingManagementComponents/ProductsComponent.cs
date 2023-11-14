using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class ProductsComponent : IDisposable
    {
        private Repository<ProductsModel> productsRepository;
        //==============================================================================================
        public ProductsComponent()
        {
            this.productsRepository = new Repository<ProductsModel>();
        }
        //==============================================================================================
        public IQueryable<ProductsModel> Read()
        {
            var result = productsRepository.SelectAllAsQuerable(c => c.ProductType);
            return result;
        }
        //==============================================================================================
        public void Add(ProductsModel model)
        {
            var query = productsRepository.FirstOrDefault(c => c.Name == model.Name && c.ProductTypeId == model.ProductTypeId);
            if (query != null) { throw new Exception("این محصول در سیستم موجود می باشد"); }
            //**********************************************
            model.PicPath = FileComponentProvider.Save(FileFolder.Courses, model.PicPath);
            model.FilePath = FileComponentProvider.Save(FileFolder.Courses, model.FilePath);
            productsRepository.Add(model);
            productsRepository.SaveChanges();
        }
        //==============================================================================================
        public ProductsModel Find(int Id)
        {
            var result = productsRepository.SingleOrDefault(c => c.Id == Id, c => c.ProductType);
            return result;
        }
        //==============================================================================================
        public void Update(ProductsModel model)
        {
            //**********************************************
            var data = productsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این محصول در سیستم موجود نمی باشد"); }
            var query = productsRepository.FirstOrDefault(c => c.Id != model.Id && c.Name == model.Name && c.ProductTypeId == model.ProductTypeId);
            if (query != null) { throw new Exception("این محصول در سیستم موجود می باشد"); }
            //**********************************************
            data.Name = model.Name;
            data.IsActive = model.IsActive;
            data.Price = model.Price;
            data.PicPath = FileComponentProvider.Save(FileFolder.Products, model.PicPath);
            data.DiscountPrice = model.DiscountPrice;
            data.FilePath = FileComponentProvider.Save(FileFolder.Products, model.FilePath); ;
            data.ProductTypeId = model.ProductTypeId;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = DateTime.UtcNow;
            productsRepository.Update(data);
            productsRepository.SaveChanges();
        }
        //==============================================================================================
        public void Delete(List<ProductsModel> model)
        {
            productsRepository.DeleteRange(model);
            productsRepository.SaveChanges();
        }
        //============================================================
        public ProductsModel FindDescription(int Id)
        {
            var result = productsRepository.Where(c => c.Id == Id).Select(c => new ProductsModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).SingleOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //================================================================================
        public void UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            var data = productsRepository.SingleOrDefault(c => c.Id == Id);
            if (data == null)
                throw new Exception(SystemCommonMessage.DataWasNotFound);

            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = CurrentUserId;
            data.Description = Description;
            productsRepository.Update(data);
            productsRepository.SaveChanges();
        }
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            productsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
