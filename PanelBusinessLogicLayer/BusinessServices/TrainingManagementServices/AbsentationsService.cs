using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class AbsentationsService : IDisposable
    {
        private AbsentationsComponent absentationsComponent;
        //=====================================================
        public AbsentationsService()
        {
            absentationsComponent = new AbsentationsComponent();
        }
        //=====================================================
        public SysResult Add(AbsentationsViewModel request, int currentUserId , int ? techerUserId  )
        {
           DateTime date = new DateTime(request.Date.CharacterAnalysis().ToDate().Year, request.Date.CharacterAnalysis().ToDate().Month, request.Date.CharacterAnalysis().ToDate().Day, 0, 0, 0).ToLocalDateTime();

            var CurrentDate = DateTime.UtcNow.ToLocalDateTime();
            var models = request.StudentsAbsentationState.Select(c => new AbsentationsModel()
            {
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                Date = date,
                IsPresent = c.IsPresent == null ? false : c.IsPresent.Value,
                StudentUserId = c.StudentUserId.Value,
                CourseMeetingId = request.CourseMeetingId.Value,
            }).ToList();
            absentationsComponent.Add(models, request.CourseMeetingId.Value, date, currentUserId , techerUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=====================================================
        public SysResult Update(AbsentationsViewModel request  , int currentUserId, int? teacherUserId)
        {
            var CurrentDate =  request.Date.ToDate().ToLocalDateTime();
            var models = request.StudentsAbsentationState.Select(c => new AbsentationsModel()
            {
                Date = CurrentDate,
                IsPresent = c.IsPresent == null ? false : c.IsPresent.Value,
                StudentUserId = c.StudentUserId.Value,
            }).ToList();
            absentationsComponent.Update(models, request.CourseMeetingId.Value, CurrentDate, currentUserId, teacherUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=====================================================
        public SysResult<AbsentationsViewModel> Read(int CourseMeetingId, int? techerUserId , DateTime? currentDate)
        { 
            var result = absentationsComponent.Read(CourseMeetingId, techerUserId , currentDate);
            var courseMeeting = new CourseMeetingsComponent().Find(CourseMeetingId);
            var model = new AbsentationsViewModel()
            {
                CourseMeetingName = courseMeeting.Course.Name + " - " + courseMeeting.Name + " - " + courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName,
                CourseMeetingId = CourseMeetingId, 
                Date = currentDate == null ? string.Empty : currentDate.Value.ToDateShortFormatString() , 
                IsAbsentationsDone = result.Where(c => c.IsPresent == null).Any() ? ActiveStatus.Deactive : ActiveStatus.Active,
                StudentsAbsentationState = result,
                IsPresentCount = result.Count(c => c.IsPresent != null && c.IsPresent.Value == true),
                CountStudent = result.Count(),
            };
            return new SysResult<AbsentationsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=====================================================

        public SysResult ReadByCourseMeeting(int CourseMeetingId)
        {
            var result = absentationsComponent.ReadByCourseMeetings(CourseMeetingId).OrderByDescending(c => c.RegDateTime).Select(c => new AbsentationsViewModel()
            {
                Id = CourseMeetingId,
                Date = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString()
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=====================================================  Disposing
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
            absentationsComponent?.Dispose();
        }
        #endregion
    }
}
