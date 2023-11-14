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
   public class OnlineExamPromoSectionsService : IDisposable
    {
        private OnlineExamPromoSectionsComponent  OnlineExamPromoSectionGroupsComponent;
        public OnlineExamPromoSectionsService()
        {
            OnlineExamPromoSectionGroupsComponent = new OnlineExamPromoSectionsComponent();
        }
        //==============================================================================
        public SysResult Read()
        {
            var result = OnlineExamPromoSectionGroupsComponent.Read();
            var viewModel = result.Select(c => new OnlineExamPromoSectionsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Inx = c.Inx,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(OnlineExamPromoSectionsViewModel viewModel, int CurrentUserId)
        {
            OnlineExamPromoSectionsModel model = new OnlineExamPromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Inx = viewModel.Inx,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId
            };
            OnlineExamPromoSectionGroupsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<OnlineExamPromoSectionsViewModel> Find(int Id)
        {
            var result = OnlineExamPromoSectionGroupsComponent.Find(Id);
            var viewModel = new OnlineExamPromoSectionsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Inx = result.Inx,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<OnlineExamPromoSectionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Update(OnlineExamPromoSectionsViewModel viewModel, int UserId)
        {
            OnlineExamPromoSectionsModel model = new OnlineExamPromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                IsActive = viewModel.IsActive.ToBoolean(),
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            OnlineExamPromoSectionGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            OnlineExamPromoSectionGroupsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = OnlineExamPromoSectionGroupsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
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
            OnlineExamPromoSectionGroupsComponent?.Dispose();
        }
        #endregion
    }
}
