using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamQuestionsComponent : IDisposable
    {
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        Repository<OnlineExamMultipleChoiceQuestionsModel> onlineExamMultipleChoiceQuestionsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamQuestionsComponent()
        {
            this.onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>();
            onlineExamMultipleChoiceQuestionsRepository = new Repository<OnlineExamMultipleChoiceQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamQuestionsModel Find(int Id)
        {
            var result = onlineExamQuestionsRepository.SingleOrDefault(c => c.Id == Id, c => c.OnlineExamMultipleChoiceQuestion, c => c.DifficultyLevelType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<OnlineExamQuestionGroupsViewModel> Read(int OnlineExamId, bool IncludeMultipleOptions)
        {
            var result = onlineExamQuestionsRepository.Where(c => c.OnlineExamId == OnlineExamId, c => c.DifficultyLevelType, c => c.Lesson, c => c.OnlineExamMultipleChoiceQuestion).ToList();
            return result.GroupBy(c => new { c.LessonId, c.Lesson.Name }).Select(c => new OnlineExamQuestionGroupsViewModel()
            {
                LessonId = c.Key.LessonId,
                LessonName = c.Key.Name,
                OnlineExamQuestions = c.OrderBy(c => c.Inx).Select(c => new OnlineExamQuestionsViewModel()
                {
                    Id = c.Id,
                    QuestionContext = c.QuestionContext,
                    IsTextQuestionContext = c.IsTextQuestionContext,
                    DifficultyLevelTypeName = c.DifficultyLevelType.Name,
                    OnlineExamId = c.OnlineExamId,
                    Inx = c.Inx,
                    QuestionType = (QuestionType)c.QuestionTypeId,
                    MultipleOptions = IncludeMultipleOptions && (QuestionType)c.QuestionTypeId == QuestionType.MultipleChoiceQuestions ? new MultipleOptionsViewModel()
                    {
                        IsTextOption1 = c.OnlineExamMultipleChoiceQuestion.IsTextOption1,
                        IsTextOption2 = c.OnlineExamMultipleChoiceQuestion.IsTextOption2,
                        IsTextOption3 = c.OnlineExamMultipleChoiceQuestion.IsTextOption3,
                        IsTextOption4 = c.OnlineExamMultipleChoiceQuestion.IsTextOption4,
                        Option1 = c.OnlineExamMultipleChoiceQuestion.Option1,
                        Option2 = c.OnlineExamMultipleChoiceQuestion.Option2,
                        Option3 = c.OnlineExamMultipleChoiceQuestion.Option3,
                        Option4 = c.OnlineExamMultipleChoiceQuestion.Option4,
                    } : null,
                }).ToList()
            }).ToList();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(int questionId, int onlineExamId, int currentUserId)
        {
            OnlineExamsComponent.CheckPermisionForEdit(onlineExamId);
            var onlineExam = GetAndValidateTeacherOnlineExam(onlineExamId);
            var question = GetQuestion(questionId);
            CheckOnlineExamTypeAndQuestionType(onlineExam, question);

            var model = new OnlineExamQuestionsModel()
            {
                IsTextQuestionContext = question.IsTextQuestionContext,
                QuestionContext = question.QuestionContext_Html,
                QuestionContext_CkFormat = question.QuestionContext,
                QuestionTypeId = question.QuestionTypeId,
                ResponseTime = question.ResponseTime,
                Source = question.Source,
                DifficultyLevelTypeId = question.DifficultyLevelTypeId,
                QuestionMakerUserId = question.QuestionMakerUserId,
                OnlineExamId = onlineExamId,
                LessonId = question.LessonId,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
            };
            if ((int)QuestionType.DescriptiveQuestions == question.QuestionTypeId)
            {
                model.OnlineExamDescriptiveQuestion = new OnlineExamDescriptiveQuestionsModel()
                {
                    QuestionAnswerContext = question.DescriptiveQuestion.QuestionAnswerContext_Html,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                };
            }
            if ((int)QuestionType.MultipleChoiceQuestions == question.QuestionTypeId)
            {
                model.OnlineExamMultipleChoiceQuestion = new OnlineExamMultipleChoiceQuestionsModel()
                {
                     
                    Option1 = question.MultipleChoiceQuestion.Option1_Html,
                    Option2 = question.MultipleChoiceQuestion.Option2_Html,
                    Option3 = question.MultipleChoiceQuestion.Option3_Html,
                    Option4 = question.MultipleChoiceQuestion.Option4_Html,
                    DescriptiveAnswer = question.MultipleChoiceQuestion.DescriptiveAnswer_Html,


                    Option1_CkFormat = question.MultipleChoiceQuestion.Option1,
                    Option2_CkFormat = question.MultipleChoiceQuestion.Option2,
                    Option3_CkFormat = question.MultipleChoiceQuestion.Option4,
                    Option4_CkFormat = question.MultipleChoiceQuestion.Option4,
                    DescriptiveAnswer_CkFormat = question.MultipleChoiceQuestion.DescriptiveAnswer,

                     
                    IsTextOption1 = question.MultipleChoiceQuestion.IsTextOption1,
                    IsTextOption2 = question.MultipleChoiceQuestion.IsTextOption2,
                    IsTextOption3 = question.MultipleChoiceQuestion.IsTextOption3,
                    IsTextOption4 = question.MultipleChoiceQuestion.IsTextOption4,
                    CorrectOption = question.MultipleChoiceQuestion.CorrectOption,


                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                };
            }
            onlineExamQuestionsRepository.Add(model);
            onlineExamQuestionsRepository.SaveChanges();
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int OnlineExamQuestionId, int onlineExamId, int currentUserId)
        {
            try
            {
                OnlineExamsComponent.CheckPermisionForEdit(onlineExamId);
                GetAndValidateTeacherOnlineExam(onlineExamId);
                var mainDBContext = new MainDBContext();
                using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var onlineExamMulteChoiceQuestion = new Repository<OnlineExamMultipleChoiceQuestionsModel>(mainDBContext);
                        onlineExamMulteChoiceQuestion.Delete(c => c.OnlineExamQuestionsId == OnlineExamQuestionId);
                        onlineExamMulteChoiceQuestion.SaveChanges();
                        //*******************************************************
                        var onlineExamDescriptiveQuestion = new Repository<OnlineExamDescriptiveQuestionsModel>(mainDBContext);
                        onlineExamDescriptiveQuestion.Delete(c => c.OnlineExamQuestionsId == OnlineExamQuestionId);
                        onlineExamDescriptiveQuestion.SaveChanges();
                        //*******************************************************
                        var onlineExamQuetion = new Repository<OnlineExamQuestionsModel>(mainDBContext);
                        onlineExamQuetion.Delete(c => c.Id == OnlineExamQuestionId);
                        onlineExamQuetion.SaveChanges();
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
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        QuestionsModel GetQuestion(int questionId)
        {
            using (var questionsRepository = new Repository<QuestionsModel>())
            {
                var result = questionsRepository.SingleOrDefault(c => c.Id == questionId, c => c.QuestionType, c => c.DifficultyLevelType, c => c.DescriptiveQuestion, c => c.MultipleChoiceQuestion);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        OnlineExamsModel GetAndValidateTeacherOnlineExam(int onlineExamId)
        {
            using (var onlineExamRepository = new Repository<OnlineExamsModel>())
            {
                var result = onlineExamRepository.Where(c => c.Id == onlineExamId).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void CheckOnlineExamTypeAndQuestionType(OnlineExamsModel onlineExamModel, QuestionsModel questionModel)
        {
            if (onlineExamModel.QuestionTypeId != (int)QuestionType.Descriptive_MultipleChoiceQuestions)
                if (onlineExamModel.QuestionTypeId != questionModel.QuestionTypeId)
                    if (questionModel.QuestionTypeId == (int)QuestionType.DescriptiveQuestions)
                        throw new CustomException("سوال تشریحی نمی تواند به آزمون تستی افزوده شود");
                    else
                        throw new CustomException("سوال تستی نمی تواند به آزمون تشریحی افزوده شود");
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void UpdateQuestionCorrectOption(int onlineExamQuestionId, int currectOption, int currentUserId)
        {
            var result = onlineExamMultipleChoiceQuestionsRepository.SingleOrDefault(c => c.OnlineExamQuestionsId == onlineExamQuestionId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.CorrectOption = currectOption;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            onlineExamMultipleChoiceQuestionsRepository.Update(result);
            onlineExamMultipleChoiceQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamMultipleChoiceQuestionsModel FindOnlineExamQuestion(int onlineExamQuestionId)
        {
            var result = onlineExamMultipleChoiceQuestionsRepository.SingleOrDefault(c => c.OnlineExamQuestionsId == onlineExamQuestionId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamMultipleChoiceQuestionsRepository?.Dispose();
            onlineExamQuestionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
