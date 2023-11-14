using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherWeekSchedulesComponent : IDisposable
    {
        private Repository<CourseMeetingsModel> courseMeetingsRepository;
        //==================================================
        public TeacherWeekSchedulesComponent()
        {
            courseMeetingsRepository = new Repository<CourseMeetingsModel>();
        }
        //==================================================
        public List<TeacherWeekSchedulesViewModel> Read(int teacherUserId )
        {
            var currentDateTime = DateTime.UtcNow.ToLocalDateTime();
            var startDate = DateTime.Now.AddDays(1 - currentDateTime.DayOfWeek.ToDayOfWeekNumber());
            var endDate = startDate.AddDays(6);
            var _startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0).ToUtcDateTime();
            var _endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59).ToUtcDateTime();
            var result = courseMeetingsRepository.Where(c => c.TeacherUserId == teacherUserId &&  _startDateTime <= c.StartDateTime && c.StartDateTime <= _endDateTime , c=> c.Course).ToList();
            var weekSchedules = new List<TeacherWeekSchedulesViewModel>();
            if (result.Any())
                for (int i = 1; i <= 7; i++)
                    weekSchedules.Add(new TeacherWeekSchedulesViewModel()
                    {
                        WeekDayName = i.ToWeekDay(),
                        WeekScheduleDetails = result.Where(c => c.StartDateTime.ToLocalDateTime().DayOfWeek.ToDayOfWeekNumber() == i).OrderBy(c => c.StartDateTime)
                        .Select(c => new WeekScheduleDetailsViewModel()
                        {
                            Description = c.Name + " (" + c.Course.Name + ") ساعت " + c.StartDateTime.ToLocalDateTimeLongFormatString().Split('-')[1].Trim(),
                            CourseId = c.CourseId
                        }).ToList()
                    });
            return weekSchedules;
        }
        //==================================================
        public void Dispose()
        {
            courseMeetingsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
