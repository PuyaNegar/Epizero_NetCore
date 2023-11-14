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
    public class SuggestionTeachersService : IDisposable
    {
        private SuggestionTeachersComponent suggestionTeachersComponent;
        //=================================================================================
        public SuggestionTeachersService()
        {
            this.suggestionTeachersComponent = new SuggestionTeachersComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = suggestionTeachersComponent.Read();
            var viewModel = result.Select(c => new SuggestionTeachersViewModel()
            {
                Id = c.Id,
                TeacherUserName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                Inx = c.Inx,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(SuggestionTeachersViewModel viewModel, int CurrentUserId)
        {

            var model = new SuggestionTeachersModel()
            {
                Id = viewModel.Id,
                TeacherUserId = viewModel.TeacherUserId,
                Inx = viewModel.Inx,
                IsActive = viewModel.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            suggestionTeachersComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<SuggestionTeachersViewModel> Find(int Id)
        {
            var result = suggestionTeachersComponent.Find(Id);
            var viewModel = new SuggestionTeachersViewModel()
            {
                Id = result.Id,
                Inx = result.Inx,
                TeacherUserId = result.TeacherUserId,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<SuggestionTeachersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(SuggestionTeachersViewModel viewModel, int UserId)
        {
 
            var model = new SuggestionTeachersModel()
            {
                Id = viewModel.Id,
                Inx = viewModel.Inx,
                TeacherUserId = viewModel.TeacherUserId,
                ModUserId = UserId,
                IsActive = viewModel.IsActive.ToBoolean(),
            };
            suggestionTeachersComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new SuggestionTeachersModel()
            {
                Id = a.Id.Value,
            }).ToList();
            suggestionTeachersComponent.Delete(model);
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
            suggestionTeachersComponent?.Dispose();
        }
        #endregion
    }
}
