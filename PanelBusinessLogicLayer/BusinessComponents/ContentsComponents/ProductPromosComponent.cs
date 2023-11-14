using Common.Extentions;
using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class ProductPromosComponent : IDisposable
    {
        private Repository<ProductPromosModel> productPromoSectionsRepository;
        public ProductPromosComponent()
        {
            this.productPromoSectionsRepository = new Repository<ProductPromosModel>();
        }
        //==============================================================================================
        public IQueryable<ProductPromosModel> Read()
        {
            var result = productPromoSectionsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IQueryable<ProductPromosModel> ReadByPromoSection(int ProductPromoSectionGroupId)
        {
            var result = productPromoSectionsRepository.Where(c => c.ProductPromoSectionId == ProductPromoSectionGroupId).Select(c => new ProductPromosModel()
            {
                Id = c.Id,
                Product = new  ProductsModel() { Name = c.Product.Name },
                ProductPromoSection = new ProductPromoSectionsModel() { Title = c.ProductPromoSection.Title },
                Inx = c.Inx,
            }).OrderBy(c => c.Inx);
            return result;
        }
        //==============================================================================================
        public void Add(int ProductPromoSectionGroupId, List<ProductPromosModel> models)
        {

            var ProductIds = models.Select(c => c.ProductId).ToList();
            var isCourseInClass = productPromoSectionsRepository.Where(c => c.ProductPromoSectionId == ProductPromoSectionGroupId && ProductIds.Contains(c.ProductId)).Any();
            if (isCourseInClass)
                throw new CustomException("برخی ازمحصولات انتخابی قبلا به این سکشن افزوده شده است");

            productPromoSectionsRepository.AddRange(models);
            productPromoSectionsRepository.SaveChanges();
        }
        //==============================================================================================
        public ProductPromosModel Find(int Id)
        {
            var result = productPromoSectionsRepository.Where(c => c.Id == Id, c => c.Product.ProductType).Select(c => new ProductPromosModel()
            {
                Id = c.Id,
                ProductId = c.ProductId,
                Inx = c.Inx,
                ProductPromoSectionId = c.ProductPromoSectionId,
                Product = new ProductsModel()
                {
                    Name = c.Product.Name,
                    ProductType = new ProductTypesModel()
                    {
                        Name = c.Product.ProductType.Name,
                    }
                }
            }).SingleOrDefault();
            return result;
        }
        //==============================================================================================
        public void Update(ProductPromosModel model)
        {
            //**********************************************
            var data = productPromoSectionsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("سکشن تبلیغاتی مورد نظر در سیستم موجود نمی‌باشد"); }
            var query = productPromoSectionsRepository.FirstOrDefault(c => c.Id != model.Id && c.ProductId == model.ProductId && c.ProductPromoSectionId == model.ProductPromoSectionId);
            if (query != null) { throw new Exception("محصول انتخاب شده در سکشن تبلیغاتی مورد نظر قبلاً ثبت شده است"); }
            //**********************************************

            data.Inx = model.Inx;
            data.ProductId = model.ProductId;
            data.ProductPromoSectionId = model.ProductPromoSectionId;
            data.ModDateTime = DateTime.UtcNow;
            productPromoSectionsRepository.Update(data);
            productPromoSectionsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            productPromoSectionsRepository.Delete(c=> Ids.Contains(c.Id));
            productPromoSectionsRepository.SaveChanges();
        }
 
        //=================================================================Disposing
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
            productPromoSectionsRepository?.Dispose();
        }
        #endregion
    }
}
