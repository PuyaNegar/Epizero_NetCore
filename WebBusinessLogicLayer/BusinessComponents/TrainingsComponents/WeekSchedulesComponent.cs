using Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class WeekSchedulesComponent : IDisposable
    {
        //===============================================
        public List<WeekSchedulesViewModel> Read(int studentUserId)
        {
            var currentDateTime = DateTime.UtcNow.ToLocalDateTime();
            var startDate = DateTime.Now.AddDays(1 - currentDateTime.DayOfWeek.ToDayOfWeekNumber());
            var endDate = startDate.AddDays(6);
            var _startDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0).ToUtcDateTime();
            var _endDateTime = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59).ToUtcDateTime();
            var courseMeetings = StudentCourseMeetingsComponent.Read(studentUserId);
            var result = courseMeetings.Where(c => _startDateTime <= c.StartDateTime && c.StartDateTime <= _endDateTime).ToList();
            var weekSchedules = new List<WeekSchedulesViewModel>();
            if (result.Any())
                for (int i = 1; i <= 7; i++)
                    weekSchedules.Add(new WeekSchedulesViewModel()
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
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
