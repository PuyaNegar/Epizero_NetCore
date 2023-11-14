using Common.Enums;
using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class DescriptiveQuestionsService : IDisposable
    {
        private DescriptiveQuestionsComponent descriptiveQuestionsComponent;
        public DescriptiveQuestionsService()
        {
            this.descriptiveQuestionsComponent = new DescriptiveQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int LessonId)
        {
            var result = descriptiveQuestionsComponent.Read(LessonId).Select(c => new DescriptiveQuestionsViewModel()
            {
                Id = c.Id,
                LessonTopicName = c.Question.LessonTopic.Name,
                QuestionTypeName = c.Question.QuestionType.Name,
                ResponseTime = c.Question.ResponseTime,
                QuestionContext_Html = c.Question.QuestionContext_Html
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(DescriptiveQuestionsViewModel request, int currentUserId)
        {
            var model = new DescriptiveQuestionsModel()
            {
                QuestionAnswerContext = request.QuestionAnswerContext, 
                QuestionAnswerContext_Html = request.QuestionAnswerContext_Html,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                Question = new QuestionsModel()
                {
                    DifficultyLevelTypeId = (int)request.DifficultyLevelType,
                    QuestionContext = request.QuestionContext,
                    QuestionContext_Html = request.QuestionContext_Html,
                    QuestionTypeId = (int)QuestionType.DescriptiveQuestions,
                    LessonTopicId = request.LessonTopicId,
                    ResponseTime = request.ResponseTime,
                    Source = request.Source,
                    LessonId= request.LessonId,
                    QuestionMakerUserId = currentUserId,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                },
            };
            descriptiveQuestionsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(DescriptiveQuestionsViewModel request, int currentUserId)
        {
            var model = new DescriptiveQuestionsModel()
            {
                Id = request.Id,
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow,
                QuestionAnswerContext = request.QuestionAnswerContext,
                QuestionAnswerContext_Html = request.QuestionAnswerContext_Html , 
                Question = new QuestionsModel()
                {
                    DifficultyLevelTypeId = (int)request.DifficultyLevelType, 
                    QuestionContext = request.QuestionContext,
                    QuestionContext_Html = request.QuestionContext_Html,
                    QuestionTypeId = (int)QuestionType.DescriptiveQuestions,
                    LessonTopicId = request.LessonTopicId,
                    ResponseTime = request.ResponseTime,
                    Source = request.Source,
                    LessonId = request.LessonId,
                    QuestionMakerUserId = currentUserId,
                    ModUserId = currentUserId,
                    ModDateTime = DateTime.UtcNow,
                },
            };
            descriptiveQuestionsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<DescriptiveQuestionsViewModel> Find(int id/*, int currentUserId*/)
        {
            var result = descriptiveQuestionsComponent.Find(id/*, currentUserId*/);
            var model = new DescriptiveQuestionsViewModel()
            {
                Id = result.Id,
                QuestionAnswerContext = result.QuestionAnswerContext,
                ResponseTime = result.Question.ResponseTime,
                QuestionContext = result.Question.QuestionContext,
                DifficultyLevelType = (DifficultyLevelType)result.Question.DifficultyLevelTypeId,
                DifficultyLevelTypeName = result.Question.DifficultyLevelType.Name,
                LessonTopicId = result.Question.LessonTopicId,
                LessonTopicName = result.Question.LessonTopic == null ? "ثبت نشده" : result.Question.Lesson.Name +  "-"  + result.Question.LessonTopic.Name ,
                Source = result.Question.Source,
                QuestionMakerUserId = result.Question.QuestionMakerUserId,
                QuestionTypeId = result.Question.QuestionTypeId,
                QuestionId = result.QuestionId,
                QuestionTypeName = result.Question.QuestionType.Name,
                LessonId = result.Question.LessonId
            };
            return new SysResult<DescriptiveQuestionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int id /*, int currentUserId*/)
        {
            descriptiveQuestionsComponent.Delete(id  /*, currentUserId*/);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
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
            descriptiveQuestionsComponent?.Dispose();
        }
        #endregion
    }
}
