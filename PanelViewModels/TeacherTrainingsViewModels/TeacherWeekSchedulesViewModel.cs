using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.TeacherTrainingsViewModels
{
    public class TeacherWeekSchedulesViewModel
    {
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public string WeekDayName { get; set; }
        //===========================================================
        /// <summary>
        /// 
        /// </summary>
        public List<WeekScheduleDetailsViewModel> WeekScheduleDetails { get; set; }
        //===========================================================
    }
}
