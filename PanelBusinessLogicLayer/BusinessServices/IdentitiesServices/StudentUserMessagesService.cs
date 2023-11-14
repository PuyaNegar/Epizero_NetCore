using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentUserMessagesService : IDisposable
    {
        private StudentUserMessagesComponent studentUserMessagesComponent;
        public StudentUserMessagesService()
        {
            studentUserMessagesComponent = new StudentUserMessagesComponent();
        }
        //===================================================================
        public SysResult Read()
        {
            var result = studentUserMessagesComponent.Read();
            var viewModel = result.Select(c => new StudentUserMessagesViewModel()
            {
                Id = c.Id,
                IsAnswered = c.IsAnswered,
                RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                AnsweredDateTime = c.AnsweredDateTime.HasValue ? c.AnsweredDateTime.Value.ToLocalDateTimeLongFormatString() : "ثبت نشده",
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }


        //=================================================================================
        public SysResult<StudentUserMessagesViewModel> Find(int Id)
        {
            var result = studentUserMessagesComponent.Find(Id);

            var viewModel = new StudentUserMessagesViewModel()
            {
                Id = result.Id,
                AnsweredDateTime = result.AnsweredDateTime.HasValue ? result.AnsweredDateTime.Value.ToLocalDateTime().ToLocalDateTimeLongFormatString() : "ثبت نشده",
                RegDateTime = result.RegDateTime.ToLocalDateTime().ToLocalDateTimeLongFormatString(),
                AnsweredQuestionText = result.AnsweredQuestionText,
                QuestionText = result.QuestionText,
                StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
            };
            return new SysResult<StudentUserMessagesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(StudentUserMessagesViewModel viewModel, int UserId)
        {
            StudentUserMessagesModel model = new StudentUserMessagesModel()
            {
                Id = viewModel.Id,
                AnsweredQuestionText = viewModel.AnsweredQuestionText,
                ModUserId = UserId
            };
            studentUserMessagesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> studentUserMessagesViewModel)
        {
            List<StudentUserMessagesModel> model = studentUserMessagesViewModel.Select(a => new StudentUserMessagesModel()
            {
                Id = a.Id.Value,
            }).ToList();
            studentUserMessagesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }

        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentUserMessagesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
