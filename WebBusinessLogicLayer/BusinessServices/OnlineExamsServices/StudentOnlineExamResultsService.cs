using Common.Objects;
using System;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentOnlineExamResultsService : IDisposable
    {
        private StudentOnlineExamResultsComponent studentOnlineExamResultsComponent;
        //===============================================
        public StudentOnlineExamResultsService()
        {
            studentOnlineExamResultsComponent = new StudentOnlineExamResultsComponent();
        }
        //=============================================== 
        public SysResult Find(int onlineExamId, int studentUserId)
        {
            var result = studentOnlineExamResultsComponent.Find(onlineExamId, studentUserId).Select(c => new StudentOnlineExamResultsViewModel()
            {
                Id=c.Id,
                FieldId = c.OnlineExamStudent.StudentUser.StudentUserProfile.FieldId,
                CorrectAnswered = c.CorrectAnswered,
                Unanswered = c.Unanswered, 
                RawScore = c.RawScore,
                IncorrectAnswered = c.IncorrectAnswered,
                LessonId = c.LessonId,
                LessonName = c.Lesson.Name,
                MinScore = c.MinScore,
                MaxScore = c.MaxScore,
                AvrageScore = c.AvrageScore, 
                AvrageBalance = c.AvrageBalance,
                LessonRank = c.LessonRank,
                ParticipantsCount =c.ParticipantsCount, 
                TotalRank = c.TotalRank,  
                Balance = c.Balance,
                LessonUnitCount = c.Lesson.UnitCount,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully , Value = result };
        }
        //=============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentOnlineExamResultsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
