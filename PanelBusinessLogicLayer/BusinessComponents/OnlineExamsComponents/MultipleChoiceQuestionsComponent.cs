using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
   public class MultipleChoiceQuestionsComponent : IDisposable
    {
        private Repository<MultipleChoiceQuestionsModel> multipleChoiceQuestionsRepository;
        public MultipleChoiceQuestionsComponent()
        {
            this.multipleChoiceQuestionsRepository = new Repository<MultipleChoiceQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<MultipleChoiceQuestionsModel> Read(int lessonId)
        {
                return multipleChoiceQuestionsRepository.Where(c => c.Question.LessonId == lessonId);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(MultipleChoiceQuestionsModel model)
        {
            multipleChoiceQuestionsRepository.Add(model);
            multipleChoiceQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public MultipleChoiceQuestionsModel Find(int Id  )
        {
            var result = multipleChoiceQuestionsRepository.SingleOrDefault(c => c.Id == Id,c => c.Question.Lesson.Level.LevelGroup,c=>c.Question.Lesson, c => c.Question.QuestionType , c=> c.Question.DifficultyLevelType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            //if (result.Question.QuestionMakerUserId != currentUserId)
            //    throw new CustomException("شما مجوز ویرایش سوال را ندارید");

            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(MultipleChoiceQuestionsModel model, int currentUserId)
        {
            var result = multipleChoiceQuestionsRepository.SingleOrDefault(c => c.Id == model.Id , c=>c.Question);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            //if (result.Question.QuestionMakerUserId != currentUserId)
            //    throw new CustomException("شما مجوز ویرایش سوال را ندارید");

            result.Option1 = model.Option1;
            result.Option2 = model.Option2;
            result.Option3 = model.Option3;
            result.Option4 = model.Option4;
            result.IsTextOption1 = model.IsTextOption1;
            result.IsTextOption2 = model.IsTextOption2;
            result.IsTextOption3 = model.IsTextOption3;
            result.IsTextOption4 = model.IsTextOption4;
            result.DescriptiveAnswer = model.DescriptiveAnswer;
            result.DescriptiveAnswer_Html = model.DescriptiveAnswer_Html;
            result.Option1_Html = model.Option1_Html;
            result.Option2_Html = model.Option2_Html;
            result.Option3_Html = model.Option3_Html;
            result.Option4_Html = model.Option4_Html;
            result.CorrectOption = model.CorrectOption;
            result.Question.IsTextQuestionContext = model.Question.IsTextQuestionContext;
            result.Question.QuestionContext = model.Question.QuestionContext;
            result.Question.QuestionContext_Html = model.Question.QuestionContext_Html;
            result.Question.Source = model.Question.Source;
            result.Question.ResponseTime = model.Question.ResponseTime  ;
            result.Question.LessonTopicId = model.Question.LessonTopicId;
            result.Question.QuestionMakerUserId = currentUserId;
            result.Question.LessonTopicId = model.Question.LessonTopicId;
            result.Question.QuestionTypeId = model.Question.QuestionTypeId;
            result.Question.DifficultyLevelTypeId = model.Question.DifficultyLevelTypeId;
            result.Question.LessonId = model.Question.LessonId;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            multipleChoiceQuestionsRepository.Update(result);
            multipleChoiceQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int id  )
        {
            try
            {
                Find(id);
                int questionId = multipleChoiceQuestionsRepository.Find(id).QuestionId;
                var mainDBContext = new MainDBContext();
                using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var multipleChoiceQuestionsRepository = new Repository<MultipleChoiceQuestionsModel>(mainDBContext);
                        multipleChoiceQuestionsRepository.Delete(c => c.Id == id);
                        multipleChoiceQuestionsRepository.SaveChanges();
                        //================================================
                        var questionRepository = new Repository<QuestionsModel>(mainDBContext);
                        questionRepository.Delete(c => c.Id == questionId);
                        questionRepository.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception(SystemCommonMessage.OperationStoppedByError);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new CustomException(ex.Message);
            }
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
            multipleChoiceQuestionsRepository?.Dispose();
        }
        #endregion
    }
}
