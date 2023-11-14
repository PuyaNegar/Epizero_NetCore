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
    public class CoursePromosService : IDisposable
    {
        private CoursePromosComponent coursePromoSectionsComponent;
        public CoursePromosService()
        {
            coursePromoSectionsComponent = new CoursePromosComponent();
        }
        //==============================================================================
        public SysResult ReadByPromoSection(int PromoSectionsId)
        {
            var result = coursePromoSectionsComponent.ReadByPromoSection(PromoSectionsId);
            var viewModel = result.Select(c => new CoursePromosViewModel()
            {
                Id = c.Id,
                Inx = c.Inx,
                TeacherFullName = c.Course.TeacherUser.FirstName + " " + c.Course.TeacherUser.LastName,
                CourseName = c.Course.Name,
                CoursePromoSectionGroupName = c.CoursePromoSection.Title
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(CoursePromosViewModel viewModel, int CurrentUserId)
        {
            if (string.IsNullOrEmpty(viewModel.CourseIds))
                throw new CustomException("لیست دوره ها نبایستی خالی فرستاده شود");
            var models = new List<CoursePromosModel>();
            foreach (var CourseId in viewModel.CourseIds.Split(',').Select(Int32.Parse).ToList())
            {
                models.Add(new CoursePromosModel()
                {
                    Inx = viewModel.Inx,
                    CourseId = CourseId,
                    CoursePromoSectionId = viewModel.CoursePromoSectionGroupId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = CurrentUserId
                });
            }
            coursePromoSectionsComponent.Add(viewModel.CoursePromoSectionGroupId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<CoursePromosViewModel> Find(int Id)
        {
            var result = coursePromoSectionsComponent.Find(Id);
            var viewModel = new CoursePromosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                CourseId = result.CourseId,
                CourseName = result.Course.CourseTypes.Name + " - " + result.Course.Name,
                CoursePromoSectionGroupId = result.CoursePromoSectionId
            };
            return new SysResult<CoursePromosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(CoursePromosViewModel viewModel, int UserId)
        {
            CoursePromosModel model = new CoursePromosModel()
            {
                Id = viewModel.Id,
                CourseId = viewModel.CourseId,
                CoursePromoSectionId = viewModel.CoursePromoSectionGroupId,
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            //**********************************************
            coursePromoSectionsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            coursePromoSectionsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }


        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            coursePromoSectionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
