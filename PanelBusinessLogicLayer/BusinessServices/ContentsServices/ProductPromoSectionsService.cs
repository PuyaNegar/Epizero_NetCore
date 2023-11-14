using Common.Extentions;
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
   public class ProductPromoSectionsService : IDisposable
    {
        private ProductPromoSectionsComponent productPromoSectionsGroupsComponent;
        public ProductPromoSectionsService()
        {
            productPromoSectionsGroupsComponent = new ProductPromoSectionsComponent();
        }
        //==============================================================================
        public SysResult Read()
        {
            var result = productPromoSectionsGroupsComponent.Read();
            var viewModel = result.Select(c => new ProductPromoSectionsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Inx = c.Inx,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(ProductPromoSectionsViewModel viewModel, int CurrentUserId)
        {
            ProductPromoSectionsModel model = new ProductPromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Inx = viewModel.Inx,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId
            };
            productPromoSectionsGroupsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<ProductPromoSectionsViewModel> Find(int Id)
        {
            var result = productPromoSectionsGroupsComponent.Find(Id);
            var viewModel = new ProductPromoSectionsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Inx = result.Inx,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<ProductPromoSectionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Update(ProductPromoSectionsViewModel viewModel, int UserId)
        {
            ProductPromoSectionsModel model = new ProductPromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                IsActive = viewModel.IsActive.ToBoolean(),
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            productPromoSectionsGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            productPromoSectionsGroupsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = productPromoSectionsGroupsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        //===================================================================Disposing
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
            productPromoSectionsGroupsComponent?.Dispose();
        }
        #endregion
    }
}
