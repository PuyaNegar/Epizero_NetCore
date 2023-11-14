using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamQuestionsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        private Repository<OnlineExamStudentAnswersModel> onlineExamStudentAnswersRepository;
        public StudentOnlineExamQuestionsComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>(mainDBContext);
            onlineExamStudentAnswersRepository = new Repository<OnlineExamStudentAnswersModel>(mainDBContext);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<StudentOnlineExamQuestionsViewModel> Read(int onlineExamId, int studentUserId,    bool IsShowCorrectAnswer = false)
        { 
            var query = from onlineExamQuestion in onlineExamQuestionsRepository.Where(c => c.OnlineExamId == onlineExamId, c => c.OnlineExamMultipleChoiceQuestion, c => c.OnlineExamDescriptiveQuestion, c => c.QuestionType, c => c.Lesson)
                        join onlineExamStudentAnswer in onlineExamStudentAnswersRepository.Where(c => c.OnlineExamStudent.StudentUserId == studentUserId, c => c.DescrptiveQuestionAnswer, c => c.MultipleChoiceQuestionAnswer) on onlineExamQuestion.Id equals onlineExamStudentAnswer.OnlineExamQuestionId into ps
                        from temp in ps.DefaultIfEmpty()
                        select new StudentOnlineExamQuestionsViewModel()
                        {
                            Id = onlineExamQuestion.Id,
                            OnlineExamId = onlineExamQuestion.OnlineExamId,
                            QuestionContext = onlineExamQuestion.QuestionContext,
                            QuestionTypeId = onlineExamQuestion.QuestionTypeId,
                            QuestionTypeName = onlineExamQuestion.QuestionType.Name,
                            LessonId = onlineExamQuestion.LessonId,
                            LessonName = onlineExamQuestion.Lesson.Name,
                            MultipleChoiceQuestionOptions = onlineExamQuestion.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions ? new StudentMultipleChoiceQuestionOptionsViewModel()
                            {
                                Id = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Id,
                                Option1 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option1,
                                Option2 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option2,
                                Option3 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option3,
                                Option4 = onlineExamQuestion.OnlineExamMultipleChoiceQuestion.Option4,
                                CorrentOption = IsShowCorrectAnswer ? onlineExamQuestion.OnlineExamMultipleChoiceQuestion.CorrectOption :  0  , 
                            } : null,

                            DescriptiveAnswers = temp == null ? null : (temp.DescrptiveQuestionAnswer == null ? null : new StudentDescriptiveAnswersViewModel()
                            {
                                OnlineExamId = onlineExamQuestion.OnlineExamId,
                                OnlineExamQuestionId = onlineExamQuestion.Id,
                                AnswerContext = temp.DescrptiveQuestionAnswer.AnswerContext
                            }),
                            MultipeChoiceAnswer = temp == null ? null : (temp.MultipleChoiceQuestionAnswer == null ? null : new StudentMultipeChoiceAnswerViewModel()
                            {
                                OnlineExamId = onlineExamQuestion.OnlineExamId,
                                OnlineExamQuestionId = onlineExamQuestion.Id,
                                SelectedOption = temp.MultipleChoiceQuestionAnswer.SelectedOption,   
                            }),
                        };
            return query.ToList();
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamQuestionsRepository?.Dispose();
            onlineExamStudentAnswersRepository?.Dispose();
            mainDBContext?.Dispose(); 
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
