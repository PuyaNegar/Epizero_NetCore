using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentMultipleChoiceAnswersService : IDisposable
    {
        private StudentMultipleChoiceAnswersComponent studentMultipleChoiceAnswersComponent;
        public StudentMultipleChoiceAnswersService()
        {
            this.studentMultipleChoiceAnswersComponent = new StudentMultipleChoiceAnswersComponent();
        }
        //=====================================================================================
        public SysResult<List<StudentMultipeChoiceAnswerViewModel>> Read(int onlineExamId, int studentUserId)
        {
            var result = studentMultipleChoiceAnswersComponent.Read(onlineExamId, studentUserId).Select(c => new StudentMultipeChoiceAnswerViewModel()
            {
                OnlineExamId = onlineExamId,
                OnlineExamQuestionId = c.OnlineExamQuestionId,
                SelectedOption = c.MultipleChoiceQuestionAnswer.SelectedOption,
            }).ToList();
            return new SysResult<List<StudentMultipeChoiceAnswerViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public SysResult AddOrUpdate(int SelectedOption, int OnlineExamQuestionId, int onlineExamId, int currentUserId)
        {

            studentMultipleChoiceAnswersComponent.AddOrUpdate(SelectedOption, OnlineExamQuestionId, onlineExamId, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            studentMultipleChoiceAnswersComponent?.Dispose();
        }
        #endregion
    }
}
