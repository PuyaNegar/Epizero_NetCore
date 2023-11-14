using Common.Extentions;
using Common.Objects;
using System;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentOnlineExamsService : IDisposable
    {
        private StudentOnlineExamsComponent studentOnlineExamsComponent;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentOnlineExamsService()
        {
            this.studentOnlineExamsComponent = new StudentOnlineExamsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int studentUserId)
        {
            var result = studentOnlineExamsComponent.Read(studentUserId).Select(c => new StudentOnlineExamViewModel()
            {
                OnlineExamId = c.OnlineExamId,
                Name = c.OnlineExam.Name,
                Duration = c.OnlineExam.Duration,
                StartDateTime = c.OnlineExam.StartDateTime.ToLocalDateTimeShortFormatString(),
                QuestionTypeId = c.OnlineExam.QuestionTypeId,
                OnlineExamTypeName = c.OnlineExam.QuestionType.Name,
                IsExpired = (c.IsFinalized) ? true : (c.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration) : DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration).AddMinutes(c.OnlineExam.AllowedTimeToEnter.Value)),
                IsShowQuestionAnswer =   (c.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow > c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration) : DateTime.UtcNow > c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration).AddMinutes(c.OnlineExam.AllowedTimeToEnter.Value)),
                IsFinalized = c.IsFinalized,
                EnterDateTime = c.EnterDateTime == null ? null : c.EnterDateTime.Value.ToDateShortFormatString(),
                IsRandomOption = c.OnlineExam.IsRandomOption.ToActiveStatus(),
                IsRandomQuestion = c.OnlineExam.IsRandomQuestions.ToActiveStatus(),
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<StudentOnlineExamViewModel> Find(int onlineExamId  , int studentUserId )
        {
            var result = studentOnlineExamsComponent.Find(onlineExamId, studentUserId);
            var model = new StudentOnlineExamViewModel()
            {
                OnlineExamId = result.OnlineExamId,
                Name = result.OnlineExam.Name,
                Duration = result.OnlineExam.Duration,
                StartDateTime = result.OnlineExam.StartDateTime.ToLocalDateTimeShortFormatString(),
                QuestionTypeId = result.OnlineExam.QuestionTypeId,
                OnlineExamTypeName = result.OnlineExam.QuestionType.Name,
                IsExpired = (result.IsFinalized) ? true : (result.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow >= result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration) : DateTime.UtcNow >= result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration).AddMinutes(result.OnlineExam.AllowedTimeToEnter.Value)),
                IsFinalized = result.IsFinalized,
                EnterDateTime = result.EnterDateTime == null ? null : result.EnterDateTime.Value.ToDateShortFormatString(),
                IsRandomOption = result.OnlineExam.IsRandomOption.ToActiveStatus(),
                IsRandomQuestion = result.OnlineExam.IsRandomQuestions.ToActiveStatus(),
            };
            return new SysResult<StudentOnlineExamViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Finalize(int onlineExamId, int studentUserId)
        {
            using (var studentOnlineExamFinalizeComponent = new StudentOnlineExamFinalizeComponent())
            {
                int OnlineExamStudentId = 0; 
                studentOnlineExamFinalizeComponent.Operation(onlineExamId, studentUserId , ref OnlineExamStudentId );
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<int> GetRemainingTime(int onlineExamId, int studentUserId)
        {
            using (var studentOnlineExamValidationsComponent = new StudentOnlineExamValidationsComponent())
            {
                double RemainingTime = 0;
                studentOnlineExamValidationsComponent.Operation(onlineExamId, studentUserId, ref RemainingTime , false);
                if (RemainingTime < 0)
                    RemainingTime = 0;
                return new SysResult<int>() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = Convert.ToInt32(RemainingTime) };
            }
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            studentOnlineExamsComponent?.Dispose();
        }
        #endregion
    }
}
