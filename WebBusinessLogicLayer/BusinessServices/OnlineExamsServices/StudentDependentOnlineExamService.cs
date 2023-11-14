using Common.Extentions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
   public class StudentDependentOnlineExamService : IDisposable
    {
        private StudentDependentOnlineExamComponent studentDependentOnlineExam;
        //==============================================
        public StudentDependentOnlineExamService()
        {
            studentDependentOnlineExam = new StudentDependentOnlineExamComponent(); 
        }
        //==============================================
        public SysResult<List<StudentOnlineExamViewModel>> Read(int studentUserId )
        {
           var result =  studentDependentOnlineExam.Read(studentUserId).Select(c => new StudentOnlineExamViewModel()
           {
               OnlineExamId = c.OnlineExamId,
               Name = c.OnlineExam.Name,
               Duration = c.OnlineExam.Duration,
               StartDateTime = c.OnlineExam.StartDateTime.ToLocalDateTimeShortFormatString(),
               QuestionTypeId = c.OnlineExam.QuestionTypeId,
               OnlineExamTypeName = c.OnlineExam.QuestionType.Name,
               IsExpired = (c.IsFinalized) ? true : (c.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration) : DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration).AddMinutes(c.OnlineExam.AllowedTimeToEnter.Value)),
               IsShowQuestionAnswer = (c.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow > c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration) : DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration).AddMinutes(c.OnlineExam.AllowedTimeToEnter.Value)) && StudentOnlineExamFinalizeComponent.IsFinalized(c.OnlineExam.Id, studentUserId),
               IsFinalized = c.IsFinalized,
               AnalysisVideoLink = c.OnlineExam.AnalysisVideoLink,
               EnterDateTime = c.EnterDateTime == null ? null : c.EnterDateTime.Value.ToDateShortFormatString(),
               IsRandomOption = c.OnlineExam.IsRandomOption.ToActiveStatus(),
               IsRandomQuestion = c.OnlineExam.IsRandomQuestions.ToActiveStatus(),
               IsVisibleOnSite = c.OnlineExam.IsVisibleOnSite
           }).ToList(); ;
           return new SysResult<List<StudentOnlineExamViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result }; 
        }
        //==============================================
        #region DisposeObject
        public void Dispose()
        {
            studentDependentOnlineExam?.Dispose(); 
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
