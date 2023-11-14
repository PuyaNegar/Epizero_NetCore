using Common.Extentions;
using Common.Objects;
using DataModels.OnlineExamModels; 
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class CourseMeetingOnlineExamsService : IDisposable
    {
        private CourseMeetingOnlineExamsComponent courseMeetingOnlineExamsComponent;
        public CourseMeetingOnlineExamsService()
        {
            courseMeetingOnlineExamsComponent = new CourseMeetingOnlineExamsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(OnlineExamsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            var startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, Convert.ToInt32(request.StartTime.Split(":")[0]), Convert.ToInt32(request.StartTime.Split(":")[1]), 0);
            var model = new OnlineExamsModel()
            {
                Name = request.Name,
                StartDateTime = startDateTime.ToUtcDateTime(),
                QuestionTypeId = request.QuestionTypeId,
                Duration = request.Duration,
                IsRandomOption = request.IsRandomOption.ToBoolean(),
                IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                AllowedTimeToEnter = request.AllowedTimeToEnter,
                TeacherUserId = currentUserId,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                MaxGrade = request.MaxGrade,
            };
            courseMeetingOnlineExamsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read()
        {
            var result = courseMeetingOnlineExamsComponent.Read().Select(c => new OnlineExamsViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                StartDateTime = c.StartDateTime.ToLocalDateTimeShortFormatString(),
                QuestionTypeName = c.QuestionType.Name,
                QuestionTypeId = c.QuestionTypeId,
                //TeacherUserName = c.TeacherUser.FirstName + ' ' + c.TeacherUser.LastName,
                Duration = c.Duration, 
                AllowedTimeToEnter = c.AllowedTimeToEnter.Value
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
                StartDateTime = startDateTime.ToUtcDateTime(),
                Duration = request.Duration,
                IsRandomOption = request.IsRandomOption.ToBoolean(),
                IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                AllowedTimeToEnter = request.AllowedTimeToEnter,
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow,
                MaxGrade = request.MaxGrade,
            };
            courseMeetingOnlineExamsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<OnlineExamsViewModel> Find(int id)
        {
            var result = courseMeetingOnlineExamsComponent.Find(id);
            var model = new OnlineExamsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                StartDate = result.StartDateTime.ToLocalDateTimeShortFormatString().Split('-')[0],
                StartTime = result.StartDateTime.ToLocalDateTimeShortFormatString().Split('-')[1],
                QuestionTypeId = result.QuestionTypeId,
                QuestionTypeName = result.QuestionType.Name,
                TeacherUserId = result.TeacherUserId,
                Duration = result.Duration,
                MaxGrade = result.MaxGrade,
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
            courseMeetingOnlineExamsComponent.Delete(id);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        { 
            courseMeetingOnlineExamsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
