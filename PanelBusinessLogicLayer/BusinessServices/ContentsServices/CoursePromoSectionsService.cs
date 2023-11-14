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
   public class CoursePromoSectionsService : IDisposable
    {
        private CoursePromoSectionsComponent  coursePromoSectionGroupsComponent;
        public CoursePromoSectionsService()
        {
            coursePromoSectionGroupsComponent = new CoursePromoSectionsComponent();
        }
        //==============================================================================
        public SysResult Read()
        {
            var result = coursePromoSectionGroupsComponent.Read();
            var viewModel = result.Select(c => new CoursePromoSectionsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Inx = c.Inx,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(CoursePromoSectionsViewModel viewModel, int CurrentUserId)
        {
            CoursePromoSectionsModel model = new CoursePromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Inx = viewModel.Inx,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId
            };
            coursePromoSectionGroupsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<CoursePromoSectionsViewModel> Find(int Id)
        {
            var result = coursePromoSectionGroupsComponent.Find(Id);
            var viewModel = new CoursePromoSectionsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Inx = result.Inx,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CoursePromoSectionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Update(CoursePromoSectionsViewModel viewModel, int UserId)
        {
            CoursePromoSectionsModel model = new CoursePromoSectionsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                IsActive = viewModel.IsActive.ToBoolean(),
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            coursePromoSectionGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            coursePromoSectionGroupsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = coursePromoSectionGroupsComponent.Read();
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
            coursePromoSectionGroupsComponent?.Dispose();
        }
        #endregion
    }
}
