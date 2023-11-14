using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentUserMessagesService : IDisposable
    {
        private StudentUserMessagesComponent studentUserMessagesComponent;
        public StudentUserMessagesService()
        {
            studentUserMessagesComponent = new StudentUserMessagesComponent();
        }
        //===================================================================
        public SysResult Read(int studentUserId)
        {
            var result = studentUserMessagesComponent.Read(studentUserId);
            var viewModel = result.Select(c => new StudentUserMessagesViewModel()
            {
                Id = c.Id,
                IsAnswered = c.IsAnswered,
                AnsweredUserFullName = c.IsAnswered ? c.ModUser.FirstName + " " + c.ModUser.LastName : "در انتظار پاسخ",
                RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                AnsweredDateTime = c.AnsweredDateTime.HasValue ? c.AnsweredDateTime.Value.ToLocalDateTimeLongFormatString() : "ثبت نشده",
             AnsweredQuestionText = c.AnsweredQuestionText,
              QuestionText =c.QuestionText
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Add(StudentUserMessagesViewModel viewModel, int studentUserId)
        {
            StudentUserMessagesModel model = new StudentUserMessagesModel()
            {
                Id = viewModel.Id,
                QuestionText = viewModel.QuestionText,
                StudentUserId = studentUserId,
                IsAnswered = false,
                AnsweredDateTime = null,
                RegDateTime = DateTime.UtcNow,
                ModUserId = null
            };
            studentUserMessagesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
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
