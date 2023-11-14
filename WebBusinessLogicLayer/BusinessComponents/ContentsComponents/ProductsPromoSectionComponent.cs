using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Functions;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentManagement
{
    public class ProductPromoSectionsComponent : IDisposable
    {
        private Repository<ProductPromosModel> productPromosRepository;
        //===========================================================
        public ProductPromoSectionsComponent()
        {
            this.productPromosRepository = new Repository<ProductPromosModel>();
        }
        //===========================================================
        public List<ProductPromoSectionsViewModel> Read()
        {
            var RootCdnPath = AppConfigProvider.CdnUrl();
            var result = productPromosRepository.Where(c => c.ProductPromoSection.IsActive && c.Product.IsActive, c => c.Product.ProductType, c => c.ProductPromoSection)
                .Select(c => new ProductPromosModel()
                {
                    Inx = c.Inx,
                    ProductPromoSection = new ProductPromoSectionsModel() { Id = c.ProductPromoSection.Id, Inx = c.ProductPromoSection.Inx, Title = c.ProductPromoSection.Title },
                    Product = new ProductsModel()
                    {
                        Id = c.Product.Id,
                        Name = c.Product.Name,
                        PicPath = string.IsNullOrEmpty(c.Product.PicPath) ? string.Empty : RootCdnPath + c.Product.PicPath,
                        DiscountPrice = c.Product.DiscountPrice,
                        Price = c.Product.Price,
                        ProductType = new ProductTypesModel() { Name = c.Product.ProductType.Name }
                    }
                }).ToList();
            return CreateSection(result);
        }
        //===========================================================
        private List<ProductPromoSectionsViewModel> CreateSection(List<ProductPromosModel> model)
        {
            var result = model.GroupBy(c => new
            {
                c.ProductPromoSection.Id,
                c.ProductPromoSection.Title,
                c.ProductPromoSection.Inx
            }).Select(c => new ProductPromoSectionsViewModel()
            {
                Id = c.Key.Id,
                Title = c.Key.Title,
                Inx = c.Key.Inx,
                ProductProms = c.OrderBy(d => d.Inx).Select(d => new ProductPromsViewModel()
                {
                    Id = d.Product.Id,
                    Name = d.Product.Name,
                    PicPath = d.Product.PicPath,
                    DiscountPrice = d.Product.DiscountPrice,
                    Price = d.Product.Price,
                    ProductTypeName = d.Product.ProductType.Name
                }).ToList()
            }).OrderBy(c => c.Inx).ToList();
            return result;
        }
        //=========================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            productPromosRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //============================================================
    }
}
