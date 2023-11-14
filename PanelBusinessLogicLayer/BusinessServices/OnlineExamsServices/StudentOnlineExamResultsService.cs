using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
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
        public SysResult Find(int onlineExamStudentId)
        {
            var result = studentOnlineExamResultsComponent.Find(onlineExamStudentId).Select(c => new StudentOnlineExamResultsViewModel()
            {
                CorrectAnswered = c.CorrectAnswered,
                Unanswered = c.Unanswered,
                RawScore = (float)Math.Round(c.RawScore * 100f) / 100f,
                IncorrectAnswered = c.IncorrectAnswered,
                LessonId = c.LessonId,
                LessonName = c.Lesson.Name,
                MinScore = c.MinScore,
                MaxScore = c.MaxScore,
                AvrageScore = c.AvrageScore,
                LessonRank = c.LessonRank,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================== 
        public SysResult Read(int onlineExamId)
        {
            using (var studentOnlineExamBatchFinalizeComponent = new StudentOnlineExamBatchFinalizeComponent())
            {
                studentOnlineExamBatchFinalizeComponent.Operation(onlineExamId);
            } 
            var result = studentOnlineExamResultsComponent.Read(onlineExamId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };

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
