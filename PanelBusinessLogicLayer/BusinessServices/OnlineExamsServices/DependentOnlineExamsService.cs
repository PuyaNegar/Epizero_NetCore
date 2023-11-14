using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class DependentOnlineExamsService : IDisposable
    {
        private DependentOnlineExamsComponent dependentOnlineExamsComponent;
        public DependentOnlineExamsService()
        {
            this.dependentOnlineExamsComponent = new DependentOnlineExamsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(OnlineExamsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            var startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, Convert.ToInt32(request.StartTime.Split(":")[0]), Convert.ToInt32(request.StartTime.Split(":")[1]), 0);
            var model = new OnlineExamsModel()
            {
                Name = request.Name,
                IsAbleToEnterExpiredExam = request.IsAbleToEnterExpiredExam.ToBoolean(),
                StartDateTime = startDateTime.ToUtcDateTime(),
                QuestionTypeId = request.QuestionTypeId,
                Duration = request.Duration,
                IsRandomOption = request.IsRandomOption.ToBoolean(),
                IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                AllowedTimeToEnter = request.AllowedTimeToEnter,
                TeacherUserId = request.TeacherUserId.Value,
                OnlineExamTypeId = (int)OnlineExamType.Dependent,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                MaxGrade = request.MaxGrade,
                IsVisibleOnSite = request.IsVisibleOnSite.ToBoolean(),
                AnalysisVideoLink = request.AnalysisVideoLink
            };
            dependentOnlineExamsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read()
        {
            var result = dependentOnlineExamsComponent.Read().Select(c => new OnlineExamsViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsAbleToEnterExpiredExamName = c.IsAbleToEnterExpiredExam ? "بلی" : "خیر",
                StartDateTime = c.StartDateTime.ToLocalDateTimeShortFormatString(),
                QuestionTypeName = c.QuestionType.Name,
                QuestionTypeId = c.QuestionTypeId,
                IsVisibleOnSiteName = c.IsVisibleOnSite ? "بلی" : "خیر",
                Duration = c.Duration,
                AllowedTimeToEnter = c.AllowedTimeToEnter.Value,
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(OnlineExamsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            var startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, Convert.ToInt32(request.StartTime.Split(":")[0]), Convert.ToInt32(request.StartTime.Split(":")[1]), 0);
            var model = new OnlineExamsModel()
            {
                Id = request.Id,
                Name = request.Name,
                IsVisibleOnSite = request.IsVisibleOnSite.ToBoolean(),
                IsAbleToEnterExpiredExam = request.IsAbleToEnterExpiredExam.ToBoolean(),
                StartDateTime = startDateTime.ToUtcDateTime(),
                Duration = request.Duration,
                AnalysisVideoLink = request.AnalysisVideoLink,
                IsRandomOption = request.IsRandomOption.ToBoolean(),
                IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                AllowedTimeToEnter = request.AllowedTimeToEnter,
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow,
                MaxGrade = request.MaxGrade,
            };
            dependentOnlineExamsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<OnlineExamsViewModel> Find(int id)
        {
            var result = dependentOnlineExamsComponent.Find(id);
            var model = new OnlineExamsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                IsVisibleOnSite = result.IsVisibleOnSite.ToActiveStatus(),
                IsAbleToEnterExpiredExam = result.IsAbleToEnterExpiredExam.ToActiveStatus(),
                StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                QuestionTypeId = result.QuestionTypeId,
                QuestionTypeName = result.QuestionType.Name,
                TeacherUserId = result.TeacherUserId,
                TeacherFullName = result.TeacherUser.FirstName + " " + result.TeacherUser.LastName,
                Duration = result.Duration,
                MaxGrade = result.MaxGrade,
                AnalysisVideoLink = result.AnalysisVideoLink,
                AllowedTimeToEnter = result.AllowedTimeToEnter,
                IsRandomOption = result.IsRandomOption.ToActiveStatus(),
                IsRandomQuestions = result.IsRandomQuestions.ToActiveStatus(),
                HasNegativePoint = result.HasNegativePoint.ToActiveStatus(),
            };
            return new SysResult<OnlineExamsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int id)
        {
            dependentOnlineExamsComponent.Delete(id);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
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
            dependentOnlineExamsComponent?.Dispose();
        }
        #endregion
    }
}
