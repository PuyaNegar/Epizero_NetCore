using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class TeacherResumesService : IDisposable
    {
        private TeacherResumesComponent teacherResumesComponent;
        //=================================================================================
        public TeacherResumesService()
        {
            this.teacherResumesComponent = new  TeacherResumesComponent();
        }
        //=================================================================================
        public SysResult Read(int teacherUserId )
        {
            var result = teacherResumesComponent.Read(teacherUserId);
            var viewModel = result.Select(c => new TeacherResumesViewModel()
            {
                Id = c.Id,
                Title = c.Title , 
                TeacherUserName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                Inx = c.Inx, 
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(TeacherResumesViewModel viewModel, int CurrentUserId)
        {

            var model = new TeacherResumesModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title , 
                TeacherUserId = viewModel.TeacherUserId,
                Inx = viewModel.Inx,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            teacherResumesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<TeacherResumesViewModel> Find(int Id)
        {
            var result = teacherResumesComponent.Find(Id);
            var viewModel = new TeacherResumesViewModel()
            {
                Id = result.Id,
                Title = result.Title , 
                Inx = result.Inx,
                TeacherUserId = result.TeacherUserId,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<TeacherResumesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(TeacherResumesViewModel viewModel, int UserId)
        {
 
            var model = new TeacherResumesModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Inx = viewModel.Inx,
                TeacherUserId = viewModel.TeacherUserId,
                ModUserId = UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            teacherResumesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new TeacherResumesModel()
            {
                Id = a.Id.Value,
            }).ToList();
            teacherResumesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherResumesComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
