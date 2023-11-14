using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class DescriptiveQuestionsComponent : IDisposable
    {
        private Repository<DescriptiveQuestionsModel> descriptiveQuestionsRepository;
        public DescriptiveQuestionsComponent()
        {
            this.descriptiveQuestionsRepository = new Repository<DescriptiveQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<DescriptiveQuestionsModel> Read(int lessonId)
        {
                return descriptiveQuestionsRepository.Where(c => c.Question.LessonId == lessonId);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(DescriptiveQuestionsModel model)
        {
            descriptiveQuestionsRepository.Add(model);
            descriptiveQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public DescriptiveQuestionsModel Find(int Id      )
        {
            var result = descriptiveQuestionsRepository.SingleOrDefault(c => c.Id == Id, c => c.Question.LessonTopic.Lesson, c => c.Question.Lesson, c => c.Question.QuestionType, c => c.Question.DifficultyLevelType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            //if (result.Question.QuestionMakerUserId != currentUserId)
            //    throw new CustomException("شما مجوز ویرایش سوال را ندارید");
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(DescriptiveQuestionsModel model, int currentUserId)
        {
            var result = descriptiveQuestionsRepository.SingleOrDefault(c => c.Id == model.Id, c => c.Question);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            //if (result.Question.QuestionMakerUserId != currentUserId)
            //    throw new CustomException("شما مجوز ویرایش سوال را ندارید");

            result.QuestionAnswerContext = model.QuestionAnswerContext;
            result.Question.QuestionContext = model.Question.QuestionContext;
            result.QuestionAnswerContext_Html = model.QuestionAnswerContext_Html;
            result.Question.QuestionContext_Html = model.Question.QuestionContext_Html;
            result.Question.DifficultyLevelTypeId = model.Question.DifficultyLevelTypeId;
            result.Question.Source = model.Question.Source;
            result.Question.LessonTopicId = model.Question.LessonTopicId;
            result.Question.QuestionMakerUserId = currentUserId;
            result.Question.LessonTopicId = model.Question.LessonTopicId;
            result.Question.ResponseTime = model.Question.ResponseTime;
            result.Question.QuestionTypeId = model.Question.QuestionTypeId;
            result.Question.LessonId = model.Question.LessonId;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            descriptiveQuestionsRepository.Update(result);
            descriptiveQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int id /*, int currentUserId*/)
        {
            try
            {
                Find(id/*, currentUserId*/);
                int questionId = descriptiveQuestionsRepository.Find(id).QuestionId;
                var mainDBContext = new MainDBContext();
                using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var descriptiveQuestionsRepository = new Repository<DescriptiveQuestionsModel>(mainDBContext);
                        descriptiveQuestionsRepository.Delete(c => c.Id == id);
                        descriptiveQuestionsRepository.SaveChanges();
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
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            descriptiveQuestionsRepository?.Dispose();
        }
        #endregion
    }
}
