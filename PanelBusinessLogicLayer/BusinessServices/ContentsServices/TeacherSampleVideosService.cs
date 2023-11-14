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
  public  class TeacherSampleVideosService : IDisposable
    {
        private TeacherSampleVideosComponent teacherSampleVideosComponent;
        //=================================================================================
        public TeacherSampleVideosService()
        {
            this.teacherSampleVideosComponent = new TeacherSampleVideosComponent();
        }
        //=================================================================================
        public SysResult Read(int TeacherId)
        {
            var result = teacherSampleVideosComponent.Read(TeacherId);
            var viewModel = result.Select(c => new TeacherSampleVideosViewModel()
            {
                Id = c.Id,
                TeacherName = c.Teacher.FirstName + " " + c.Teacher.LastName,
                Inx = c.Inx,
                Title = c.Title,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(TeacherSampleVideosViewModel viewModel, int CurrentUserId)
        {

            var model = new TeacherSampleVideosModel()
            {
                Id = viewModel.Id,
                TeacherId = viewModel.TeacherId,
                Inx = viewModel.Inx,
                Title = viewModel.Title,
                Link = viewModel.Link,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            teacherSampleVideosComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<TeacherSampleVideosViewModel> Find(int Id)
        {
            var result = teacherSampleVideosComponent.Find(Id);
            var viewModel = new TeacherSampleVideosViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                Link = result.Link,
                Title = result.Title,
                TeacherId = result.TeacherId,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<TeacherSampleVideosViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(TeacherSampleVideosViewModel viewModel, int UserId)
        {

            var model = new TeacherSampleVideosModel()
            {
                Id = viewModel.Id,
                Inx = viewModel.Inx,
                Link = viewModel.Link,
                Title = viewModel.Title,
                TeacherId = viewModel.TeacherId,
                ModUserId = UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            teacherSampleVideosComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new TeacherSampleVideosModel()
            {
                Id = a.Id.Value,
            }).ToList();
            teacherSampleVideosComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
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
            teacherSampleVideosComponent?.Dispose();
        }
        #endregion
    }
}
