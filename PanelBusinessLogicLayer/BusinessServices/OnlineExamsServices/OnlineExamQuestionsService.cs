using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamViewModels;
using System;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamQuestionsService : IDisposable
    {

        private OnlineExamQuestionsComponent onlineExamQuestionsComponent;
        public OnlineExamQuestionsService()
        {
            this.onlineExamQuestionsComponent = new OnlineExamQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int OnlineExamId, bool IncludeMultipleOptions)
        {
            var result = onlineExamQuestionsComponent.Read(OnlineExamId, IncludeMultipleOptions);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(int questionsId, int onlineExamId, int currentUserId)
        {
            onlineExamQuestionsComponent.Add(questionsId, onlineExamId, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Find(int Id)
        {
            var result = onlineExamQuestionsComponent.Find(Id);
            var model = new OnlineExamQuestionsViewModel()
            {
                Id = result.Id,
                QuestionContext = result.QuestionContext,
                IsTextQuestionContext = result.IsTextQuestionContext,
                DifficultyLevelTypeName = result.DifficultyLevelType.Name,
                OnlineExamId = result.OnlineExamId,
                Inx = result.Inx,
                QuestionType = (QuestionType)result.QuestionTypeId,
                MultipleOptions = (QuestionType)result.QuestionTypeId == QuestionType.MultipleChoiceQuestions ? new MultipleOptionsViewModel()
                {
                    IsTextOption1 = result.OnlineExamMultipleChoiceQuestion.IsTextOption1,
                    IsTextOption2 = result.OnlineExamMultipleChoiceQuestion.IsTextOption2,
                    IsTextOption3 = result.OnlineExamMultipleChoiceQuestion.IsTextOption3,
                    IsTextOption4 = result.OnlineExamMultipleChoiceQuestion.IsTextOption4,
                    Option1 = result.OnlineExamMultipleChoiceQuestion.Option1,
                    Option2 = result.OnlineExamMultipleChoiceQuestion.Option2,
                    Option3 = result.OnlineExamMultipleChoiceQuestion.Option3,
                    Option4 = result.OnlineExamMultipleChoiceQuestion.Option4,
                    //CorrectOption = result.OnlineExamMultipleChoiceQuestion.CorrectOption,
                } : null,
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int OnlineExamQuestionId, int onlineExamId, int currentUserId)
        {
            onlineExamQuestionsComponent.Delete(OnlineExamQuestionId, onlineExamId, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult FindOnlineExamQuestion(int onlineExamQuestionId)
        {
            var result = onlineExamQuestionsComponent.FindOnlineExamQuestion(onlineExamQuestionId);
            var viewModel = new OnlineExamQuestionCorrectOptionsViewModel()
            {
                CorrectOption = result.CorrectOption,
                OnlineExamQuestionId = result.Id,
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult UpdateQuestionCorrectOption(OnlineExamQuestionCorrectOptionsViewModel viewModel, int currentUserId)
        {
            onlineExamQuestionsComponent.UpdateQuestionCorrectOption(viewModel.OnlineExamQuestionId, viewModel.CorrectOption, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamQuestionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
