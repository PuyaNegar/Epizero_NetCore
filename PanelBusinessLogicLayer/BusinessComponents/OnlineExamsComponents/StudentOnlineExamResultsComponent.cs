using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels; 
using PanelViewModels.OnlineExamsViewModels;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamResultsComponent : IDisposable
    {
        private Repository<StudentOnlineExamResultsModel> studentOnlineExamResultsRepository;
        private StudentOnlineExamFinalizeComponent studentOnlineExamFinalizeComponent;
        //==============================================
        public StudentOnlineExamResultsComponent()
        {
            studentOnlineExamFinalizeComponent = new StudentOnlineExamFinalizeComponent();
            studentOnlineExamResultsRepository = new Repository<StudentOnlineExamResultsModel>();
        }
        //==============================================
        public List<StudentOnlineExamResultsModel> Find(int onlineExamStudentId)
        {
            studentOnlineExamFinalizeComponent.Operation(onlineExamStudentId);
            var result = studentOnlineExamResultsRepository.Where(c => c.OnlineExamStudentId == onlineExamStudentId, c => c.Lesson).ToList();
            return result;
        }
        //==============================================
        public List<StudentOnlineExamResultGroupsViewModel> Read(int onlineExamId)
        {
            var result = studentOnlineExamResultsRepository.Where(c => c.OnlineExamStudent.OnlineExamId == onlineExamId, c => c.OnlineExamStudent.StudentUser.StudentUserProfile.City, c => c.Lesson).ToList();

            var query = result.GroupBy(c => new
            {
                c.OnlineExamStudent.StudentUserId,
                c.OnlineExamStudent.StudentUser.FirstName,
                c.OnlineExamStudent.StudentUser.LastName,
                CityId = c.OnlineExamStudent.StudentUser.StudentUserProfile.City == null ? 0 : c.OnlineExamStudent.StudentUser.StudentUserProfile.City.Id,
                CityName = c.OnlineExamStudent.StudentUser.StudentUserProfile.City == null ? "ثبت نشده" : c.OnlineExamStudent.StudentUser.StudentUserProfile.City.Name,
                c.OnlineExamStudent.StudentUser.StudentUserProfile.FieldId,
                c.OnlineExamStudent.StudentUser.StudentUserProfile.SchoolName,
                c.OnlineExamStudent.IsAbsentOnMainTime
            }).Select(c => new StudentOnlineExamResultGroupsViewModel()
            {
                StudentFullName = c.Key.FirstName + " " + c.Key.LastName,
                TotalRank = c.First().TotalRank, 
                SchoolName = c.Key.SchoolName,
                FieldId = c.Key.FieldId,
                CityName = c.Key.CityName,
                CityId = c.Key.CityId,
                IsAbsentOnMainTime = c.Key.IsAbsentOnMainTime,
                TotalBalance = c.Sum(d => d.Lesson.UnitCount * d.Balance) / c.Sum(d => d.Lesson.UnitCount),
                TotalScore = c.Sum(d => d.Lesson.UnitCount * d.RawScore) / c.Sum(d => d.Lesson.UnitCount),
                StudentOnlineExamResults = c.Select(d => new StudentOnlineExamResultsViewModel()
                {
                    IncorrectAnswered = d.IncorrectAnswered,
                    LessonName = d.Lesson.Name,
                    LessonUnitCount = d.Lesson.UnitCount,
                    RawScore = d.RawScore,
                    Balance = d.Balance,
                    LessonRank = d.LessonRank,
                    ParticipantsCount = d.ParticipantsCount,
                    Unanswered = d.Unanswered,
                    LessonId = d.LessonId,
                    MinScore = d.MinScore,
                    MaxScore = d.MaxScore,
                    AvrageScore = d.AvrageScore,
                    CorrectAnswered = d.CorrectAnswered,
                    TotalRank = d.TotalRank,
                    AverageBalance = d.AvrageBalance
                }).ToList()
            }).OrderByDescending(c => c.TotalBalance).ToList();
            return query;
        }
        //============================================== 
        #region DisposeObject
        public void Dispose()
        {
            studentOnlineExamResultsRepository?.Dispose();
            studentOnlineExamFinalizeComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
