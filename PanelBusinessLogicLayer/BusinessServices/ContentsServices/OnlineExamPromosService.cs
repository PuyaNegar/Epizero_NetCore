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
    public class OnlineExamPromosService : IDisposable
    {
        private OnlineExamPromosComponent OnlineExamPromoSectionsComponent;
        public OnlineExamPromosService()
        {
            OnlineExamPromoSectionsComponent = new OnlineExamPromosComponent();
        }
        //==============================================================================
        public SysResult ReadByPromoSection(int PromoSectionsId)
        {
            var result = OnlineExamPromoSectionsComponent.ReadByPromoSection(PromoSectionsId);
            var viewModel = result.Select(c => new OnlineExamPromosViewModel()
            {
                Id = c.Id,
                Inx = c.Inx,
                TeacherFullName = c.Course.TeacherUser.FirstName + " " + c.Course.TeacherUser.LastName,
                CourseName = c.Course.Name,
                OnlineExamPromoSectionGroupName = c.OnlineExamPromoSection.Title
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(OnlineExamPromosViewModel viewModel, int CurrentUserId)
        {
            if (string.IsNullOrEmpty(viewModel.CourseIds))
                throw new CustomException("لیست دوره ها نبایستی خالی فرستاده شود");
            var models = new List<OnlineExamPromosModel>();
            foreach (var CourseId in viewModel.CourseIds.Split(',').Select(Int32.Parse).ToList())
            {
                models.Add(new OnlineExamPromosModel()
                {
                    Inx = viewModel.Inx,
                    CourseId = CourseId,
                    OnlineExamPromoSectionId = viewModel.OnlineExamPromoSectionGroupId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = CurrentUserId
                });
            }
            OnlineExamPromoSectionsComponent.Add(viewModel.OnlineExamPromoSectionGroupId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<OnlineExamPromosViewModel> Find(int Id)
        {
            var result = OnlineExamPromoSectionsComponent.Find(Id);
            var viewModel = new OnlineExamPromosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                CourseId = result.CourseId,
                CourseName = result.Course.CourseTypes.Name + " - " + result.Course.Name,
                OnlineExamPromoSectionGroupId = result.OnlineExamPromoSectionId
            };
            return new SysResult<OnlineExamPromosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(OnlineExamPromosViewModel viewModel, int UserId)
        {
            OnlineExamPromosModel model = new OnlineExamPromosModel()
            {
                Id = viewModel.Id,
                CourseId = viewModel.CourseId,
                OnlineExamPromoSectionId = viewModel.OnlineExamPromoSectionGroupId,
                Inx = viewModel.Inx,
                ModUserId = UserId
            };
            //**********************************************
            OnlineExamPromoSectionsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            OnlineExamPromoSectionsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }


        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            OnlineExamPromoSectionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
