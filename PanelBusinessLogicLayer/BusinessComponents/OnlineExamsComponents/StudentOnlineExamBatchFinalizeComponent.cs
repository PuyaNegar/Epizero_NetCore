using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamBatchFinalizeComponent : IDisposable
    {
        private Repository<OnlineExamStudentsModel> onlineExamStudentsRepository;
        //=======================================================
        public StudentOnlineExamBatchFinalizeComponent()
        {
            onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>();
        }
        //=======================================================
        public void Operation(int onlineExamId)
        {
            ValidateOnlineExam(onlineExamId);
            var onlineExamStudents = onlineExamStudentsRepository.Where(c => c.OnlineExamId == onlineExamId && c.IsFinalized == false && c.EnterDateTime != null).Select(c => new OnlineExamStudentsModel()
            {
                Id = c.Id,
                EnterDateTime = c.EnterDateTime,
                OnlineExam = new OnlineExamsModel()
                {
                    StartDateTime = c.OnlineExam.StartDateTime,
                    AllowedTimeToEnter = c.OnlineExam.AllowedTimeToEnter,
                    Duration = c.OnlineExam.Duration,
                }
            }).ToList();

            foreach (var onlineExamStudent in onlineExamStudents)
            {
                using (var studentOnlineExamFinalizeComponent = new StudentOnlineExamFinalizeComponent())
                {
                    studentOnlineExamFinalizeComponent.Operation(onlineExamStudent.Id);
                }
            }
            CalculateResults(onlineExamId);
        }
        //=========================================================================================
        void ValidateOnlineExam(int onlineExamId)
        {
            using (var onlineExamsRepository = new Repository<OnlineExamsModel>())
            {
                var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                bool IsExpired = result.StartDateTime.AddMinutes(result.Duration).AddMinutes(result.AllowedTimeToEnter == null ? 0 : result.AllowedTimeToEnter.Value) < DateTime.UtcNow;
                if (!IsExpired)
                    throw new CustomException("مهلت آزمون هنوز به پایان نرسیده است و نمی توانید در این وضعیت امتحان را نهایی نمایید");
            }
        }
        //=========================================================================================
        void CalculateResults(int onlineExamId)
        {
            using (var studentOnlineExamResultsRepository = new Repository<StudentOnlineExamResultsModel>())
            {
                var studentOnlineExamResults = studentOnlineExamResultsRepository.Where(c => c.OnlineExamStudent.OnlineExamId == onlineExamId && !c.OnlineExamStudent.IsAbsentOnMainTime , c=>c.Lesson).ToList();
                var groups = studentOnlineExamResults.GroupBy(c => c.LessonId).Select(c => new { LessonId = c.Key, Count = c.Count(), MinScore = c.Min(c => c.RawScore), MaxScore = c.Max(c => c.RawScore), Average = c.Average(c => c.RawScore) });
                foreach (var group in groups)
                {
                    double SumX = Math.Sqrt((double)studentOnlineExamResults.Where(c => c.LessonId == group.LessonId).Sum(c => Math.Pow(c.RawScore - group.Average, 2)) / group.Count);

                    foreach (var studentOnlineExamResult in studentOnlineExamResults.Where(c => c.LessonId == group.LessonId).OrderByDescending(c => c.RawScore))
                    {
                        studentOnlineExamResult.MinScore = group.MinScore;
                        studentOnlineExamResult.MaxScore = group.MaxScore;
                        studentOnlineExamResult.AvrageScore = group.Average;
                        studentOnlineExamResult.ParticipantsCount = group.Count;
                        studentOnlineExamResult.TotalRank = 0;
                        studentOnlineExamResult.LessonRank = 0;  
                        studentOnlineExamResult.Balance = Convert.ToDecimal(1000 * ((studentOnlineExamResult.RawScore - group.Average) / SumX) + 5000);
                        studentOnlineExamResultsRepository.Update(studentOnlineExamResult); 
                    }

                 
                    int i = 0;
                    decimal LastScore = 0;
                    var averageBalance = studentOnlineExamResults.Where(c => c.LessonId == group.LessonId).Average(c => c.Balance);
                    foreach (var studentOnlineExamResult in studentOnlineExamResults.Where(c => c.LessonId == group.LessonId).OrderByDescending(c => c.Balance))
                    {
                        studentOnlineExamResult.AvrageBalance  = averageBalance;
                        studentOnlineExamResult.LessonRank = LastScore == studentOnlineExamResult.Balance ? (i == 0 ? ++i : i) : ++i;
                        studentOnlineExamResultsRepository.Update(studentOnlineExamResult);
                        LastScore = studentOnlineExamResult.Balance;
                    }
                }
                var totalRankDictionary = GetTotalRankDictionaryByBalance(studentOnlineExamResults);
                foreach (var studentOnlineExamResult in studentOnlineExamResults)
                {
                    studentOnlineExamResult.TotalRank = totalRankDictionary[studentOnlineExamResult.OnlineExamStudentId];
                    studentOnlineExamResultsRepository.Update(studentOnlineExamResult);
                }
                studentOnlineExamResultsRepository.SaveChanges();
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Dictionary<int, int> GetTotalRankDictionaryByBalance(List<StudentOnlineExamResultsModel> model)
        {
            var groups = model.GroupBy(c => c.OnlineExamStudentId).Select(c => new { OnlineExamStudentId = c.Key, TotalBalance = c.Sum(d => d.Lesson.UnitCount * d.Balance) / c.Sum(d => d.Lesson.UnitCount) /* c.Average(c => c.Balance) */}).OrderByDescending(c => c.TotalBalance);
            var result = new Dictionary<int, int>();
            int i = 0;
            decimal LastScore = 0;
            int row = 1;
            foreach (var group in groups)
            {
                result.Add((int)group.OnlineExamStudentId, LastScore == group.TotalBalance ? (i == 0 ? ++i : i) : i = row);
                LastScore = group.TotalBalance;
                row++;
            }
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
