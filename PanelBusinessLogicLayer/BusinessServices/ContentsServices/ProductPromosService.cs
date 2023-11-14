using Common.Functions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
   public class ProductPromosService : IDisposable
    {
        private ProductPromosComponent productPromoSectionsComponent;
        public ProductPromosService()
        {
            productPromoSectionsComponent = new ProductPromosComponent();
        }
        //==============================================================================
        //=================================================================================
        public SysResult ReadByPromoSection(int PromoSectionsId)
        {
            var result = productPromoSectionsComponent.ReadByPromoSection(PromoSectionsId);
            var viewModel = result.Select(c => new ProductPromosViewModel()
            {
                Id = c.Id,
                Inx = c.Inx,
                ProductName = c.Product.Name,
                ProductPromoSectionGroupName = c.ProductPromoSection.Title
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(ProductPromosViewModel viewModel, int CurrentUserId)
        {
            if (string.IsNullOrEmpty(viewModel.ProductIds))
                throw new CustomException("لیست دوره ها نبایستی خالی فرستاده شود");
            var models = new List<ProductPromosModel>();
            foreach (var ProductId in viewModel.ProductIds.Split(',').Select(Int32.Parse).ToList())
            {
                models.Add(new ProductPromosModel()
                {
                    Inx = viewModel.Inx,
                    ProductId = ProductId,
                    ProductPromoSectionId = viewModel.ProductPromoSectionGroupId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = CurrentUserId
                });
            }
            productPromoSectionsComponent.Add(viewModel.ProductPromoSectionGroupId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<ProductPromosViewModel> Find(int Id)
        {
            var result = productPromoSectionsComponent.Find(Id);
            var viewModel = new ProductPromosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                ProductId = result.ProductId,
                ProductName = result.Product.ProductType.Name + " - " + result.Product.Name,
                ProductPromoSectionGroupId = result.ProductPromoSectionId
            };
            return new SysResult<ProductPromosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(ProductPromosViewModel viewModel, int UserId)
        {
            ProductPromosModel model = new ProductPromosModel()
            {
                Id = viewModel.Id,
                ProductId = viewModel.ProductId,
                ProductPromoSectionId = viewModel.ProductPromoSectionGroupId,
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            //**********************************************
            productPromoSectionsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            productPromoSectionsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            productPromoSectionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
 
    }
}
