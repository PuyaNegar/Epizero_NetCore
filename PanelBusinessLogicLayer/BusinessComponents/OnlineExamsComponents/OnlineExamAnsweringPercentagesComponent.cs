using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamQuestionPercentagesViewModel
    {
        public int QuestionId { get; set; }
        public int LessonId { get; set; }
        public int CorrectOption { get; set; }
        public string LessonName { get; set; }
        public int Inx { get; set; }
    }
    public class OnlineExamAnswerPercentagesViewModel
    {
        public int QuestionId { get; set; }
        public int StudentUserId { get; set; }
        public int SelectedOption { get; set; }
    }

    public class OnlineExamAnsweringPercentagesComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        private Repository<MultipleChoiceQuestionAnswersModel> multipleChoiceQuestionAnswersRepository;
        private Repository<OnlineExamStudentsModel> onlineExamStudentsRepository;
        //==================================================
        public OnlineExamAnsweringPercentagesComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>(mainDBContext);
            onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>(mainDBContext);
            multipleChoiceQuestionAnswersRepository = new Repository<MultipleChoiceQuestionAnswersModel>(mainDBContext);
        }
        //==================================================
        public List<OnlineExamAnsweringPercentageGroupsViewModel> Operation(int onlineExamId)
        {
            var onlineExamQuestions = GetOnlineExamQuestions(onlineExamId);
            var onlineExamAnswers = GetOnlineExamAnswer(onlineExamId);
            var questionCount = onlineExamQuestions.Count;
            var studentCount = onlineExamStudentsRepository.Where(c => c.OnlineExamId == onlineExamId && c.IsFinalized).Count();
            return CreateViewModel(onlineExamQuestions, onlineExamAnswers, questionCount, studentCount);
        }
        //==================================================
        private List<OnlineExamAnsweringPercentageGroupsViewModel> CreateViewModel(List<OnlineExamQuestionPercentagesViewModel> onlineExamQuestions, List<OnlineExamAnswerPercentagesViewModel> onlineExamAnswers, int questionCount, int studentCount)
        {
            var PercentageGroups = new List<OnlineExamAnsweringPercentageGroupsViewModel>();
            foreach (var group in onlineExamQuestions.GroupBy(c => new { c.LessonId, c.LessonName }).Select(c => new { LessonName = c.Key.LessonName, Data = c.ToList() }))
            {
                var PercentageGroup = new OnlineExamAnsweringPercentageGroupsViewModel();
                PercentageGroup.LessonName = group.LessonName;

                var percentages = new List<OnlineExamAnsweringPercentagesViewModel>();
                foreach (var d in group.Data)
                {
                    var FalseAnsweredCount = onlineExamAnswers.Where(x => x.QuestionId == d.QuestionId && x.SelectedOption != d.CorrectOption).Count();
                    var TrueAnsweredCount = onlineExamAnswers.Where(x => x.QuestionId == d.QuestionId && x.SelectedOption == d.CorrectOption).Count();
                     
                    var FalseAnsweredPercent = CalculatePercentage(studentCount, FalseAnsweredCount);
                    var TrueAnsweredPercent = CalculatePercentage(studentCount, TrueAnsweredCount);
                    var NoAnsweredPercent = 100 - (TrueAnsweredPercent + FalseAnsweredPercent);

                    var percentage = new OnlineExamAnsweringPercentagesViewModel()
                    {
                        QuestionId = d.QuestionId,
                        FalseAnsweredPercent = FalseAnsweredPercent,
                        NoAnsweredPercent = NoAnsweredPercent,
                        TrueAnsweredPercent = TrueAnsweredPercent,
                    };
                    percentages.Add(percentage);
                }
                PercentageGroup.OnlineExamAnsweringPercentages = percentages.OrderBy(c=>c.TrueAnsweredPercent).ThenByDescending(c=>c.FalseAnsweredPercent).ThenByDescending(c=>c.NoAnsweredPercent).ToList();
                PercentageGroups.Add(PercentageGroup);
            }

            return PercentageGroups;
        }
        //==================================================
        List<OnlineExamAnswerPercentagesViewModel> GetOnlineExamAnswer(int onlineExamId)
        {
            return multipleChoiceQuestionAnswersRepository.Where(c => c.OnlineExamStudentAnswer.OnlineExamStudent.OnlineExamId == onlineExamId && c.OnlineExamStudentAnswer.OnlineExamStudent.IsFinalized, c => c.OnlineExamStudentAnswer.OnlineExamStudent).Select(c =>
                        new OnlineExamAnswerPercentagesViewModel
                        {
                            QuestionId = c.OnlineExamStudentAnswer.OnlineExamQuestionId,
                            StudentUserId = c.OnlineExamStudentAnswer.OnlineExamStudent.StudentUserId,
                            SelectedOption = c.SelectedOption
                        }).ToList();
        }
        //==================================================
        List<OnlineExamQuestionPercentagesViewModel> GetOnlineExamQuestions(int onlineExamId)
        {
            return onlineExamQuestionsRepository.Where(c => c.OnlineExamId == onlineExamId && c.OnlineExam.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions, c => c.OnlineExamMultipleChoiceQuestion, c => c.Lesson).OrderBy(c => c.Inx)
                            .Select(c => new OnlineExamQuestionPercentagesViewModel
                            {
                                QuestionId = c.Id,
                                LessonId = c.Lesson.Id,
                                CorrectOption = c.OnlineExamMultipleChoiceQuestion.CorrectOption,
                                LessonName = c.Lesson.Name,
                                Inx = c.Inx,
                            }).ToList();
        }
        //==================================================
        decimal CalculatePercentage(int totalStudentCount, int value)
        {
            if (totalStudentCount == 0)
                return 0;
            return Math.Round((decimal)value * 100 / totalStudentCount, 0);
        }

        //==================================================
        public void Dispose()
        {
            mainDBContext?.Dispose();
            onlineExamStudentsRepository?.Dispose();
            multipleChoiceQuestionAnswersRepository?.Dispose();
            onlineExamQuestionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
