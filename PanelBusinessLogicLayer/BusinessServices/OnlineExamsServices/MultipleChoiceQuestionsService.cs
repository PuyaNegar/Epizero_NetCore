using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class MultipleChoiceQuestionsService : IDisposable
    {
        private MultipleChoiceQuestionsComponent multipleChoiceQuestionsComponent;
        public MultipleChoiceQuestionsService()
        {
            this.multipleChoiceQuestionsComponent = new MultipleChoiceQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int lessonId)
        {
            var result = multipleChoiceQuestionsComponent.Read(lessonId).Select(c => new MultipleChoiceQuestionsViewModel()
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
        public SysResult Add(MultipleChoiceQuestionsViewModel request, int currentUserId)
        {
            var model = new MultipleChoiceQuestionsModel()
            {
                Option1 = request.Option1,
                Option2 = request.Option2,
                Option3 = request.Option3,
                Option4 = request.Option4,
                IsTextOption1 = request.IsTextOption1.ToBoolean(),
                IsTextOption2 = request.IsTextOption2.ToBoolean(),
                IsTextOption3 = request.IsTextOption3.ToBoolean(),
                IsTextOption4 = request.IsTextOption4.ToBoolean(),
                DescriptiveAnswer = request.DescriptiveAnswer,
                DescriptiveAnswer_Html = request.DescriptiveAnswer_Html,
                Option1_Html = request.Option1_Html,
                Option2_Html = request.Option2_Html,
                Option3_Html = request.Option3_Html,
                Option4_Html = request.Option4_Html,
                CorrectOption = request.CorrectOption,
                Question = new QuestionsModel()
                {
                    QuestionContext = request.QuestionContext,
                    IsTextQuestionContext = request.IsTextQuestionContext.ToBoolean(),
                    QuestionContext_Html = request.QuestionContext_Html,
                    QuestionTypeId = (int)QuestionType.MultipleChoiceQuestions,
                    LessonTopicId = request.LessonTopicId,
                    ResponseTime = request.ResponseTime,
                    Source = request.Source,
                    LessonId = request.LessonId,
                    DifficultyLevelTypeId = (int)request.DifficultyLevelType,
                    QuestionMakerUserId = currentUserId,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                },
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
            };
            multipleChoiceQuestionsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(MultipleChoiceQuestionsViewModel request, int currentUserId)
        {
            var model = new MultipleChoiceQuestionsModel()
            {
                Id = request.Id,
                Option1 = request.Option1,
                Option2 = request.Option2,
                Option3 = request.Option3,
                Option4 = request.Option4,
                IsTextOption1 = request.IsTextOption1.ToBoolean(),
                IsTextOption2 = request.IsTextOption2.ToBoolean(),
                IsTextOption3 = request.IsTextOption3.ToBoolean(),
                IsTextOption4 = request.IsTextOption4.ToBoolean(),
                DescriptiveAnswer = request.DescriptiveAnswer,
                DescriptiveAnswer_Html = request.DescriptiveAnswer,
                Option1_Html = request.Option1_Html,
                Option2_Html = request.Option2_Html,
                Option3_Html = request.Option3_Html,
                Option4_Html = request.Option4_Html,
                CorrectOption = request.CorrectOption,  
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow , 
                Question = new QuestionsModel()
                {
                    QuestionContext = request.QuestionContext,
                    IsTextQuestionContext = request.IsTextQuestionContext.ToBoolean(),
                    QuestionContext_Html = request.QuestionContext_Html,
                    QuestionTypeId = (int)QuestionType.MultipleChoiceQuestions,
                    LessonTopicId = request.LessonTopicId,
                    ResponseTime = request.ResponseTime,
                    DifficultyLevelTypeId =(int) request.DifficultyLevelType,
                    Source = request.Source,
                    LessonId = request.LessonId,
                    QuestionMakerUserId = currentUserId,
                    ModUserId = currentUserId,
                    ModDateTime = DateTime.UtcNow,
                }, 
            };
            multipleChoiceQuestionsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<MultipleChoiceQuestionsViewModel> Find(int id /*, int currentUserId*/ )
        {
            var result = multipleChoiceQuestionsComponent.Find(id /*, currentUserId*/ );
            var model = new MultipleChoiceQuestionsViewModel()
            {
                Id = result.Id,
                Option1 = result.Option1,
                Option2 = result.Option2,
                Option3 = result.Option3,
                Option4 = result.Option4,
                IsTextOption1 = result.IsTextOption1.ToActiveStatus(),
                IsTextOption2 = result.IsTextOption2.ToActiveStatus(),
                IsTextOption3 = result.IsTextOption3.ToActiveStatus(),
                IsTextOption4 = result.IsTextOption4.ToActiveStatus(),
                DescriptiveAnswer = result.DescriptiveAnswer,
                DescriptiveAnswer_Html = result.DescriptiveAnswer_Html,
                Option1_Html = result.Option1_Html,
                Option2_Html = result.Option2_Html,
                Option3_Html = result.Option3_Html,
                Option4_Html = result.Option4_Html,
                CorrectOption = result.CorrectOption,
                DifficultyLevelType = (DifficultyLevelType)result.Question.DifficultyLevelTypeId,
                DifficultyLevelTypeName = result.Question.DifficultyLevelType.Name,
                ResponseTime = result.Question.ResponseTime,
                QuestionContext = result.Question.QuestionContext,
                IsTextQuestionContext = result.Question.IsTextQuestionContext.ToActiveStatus(),
                QuestionContext_Html = result.Question.QuestionContext_Html,
                LessonTopicId = result.Question.LessonTopicId,
                LessonTopicName = result.Question.LessonTopic == null ? "ثبت نشده" :  result.Question.Lesson.Name + "-" + result.Question.LessonTopic.Name,
                Source = result.Question.Source,
                LessonId = result.Question.LessonId,
                LessonName = result.Question.Lesson.Level.LevelGroup.Name + "-" + result.Question.Lesson.Level.Name + "-" + result.Question.Lesson.Name,
                QuestionMakerUserId = result.Question.QuestionMakerUserId,
                QuestionTypeId = result.Question.QuestionTypeId,
                QuestionTypeName = result.Question.QuestionType.Name,
            };
            return new SysResult<MultipleChoiceQuestionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int id /*, int currentUser*/)
        {
            multipleChoiceQuestionsComponent.Delete(id /*, currentUser*/ );
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
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
            multipleChoiceQuestionsComponent?.Dispose();
    }
    #endregion
}
}
