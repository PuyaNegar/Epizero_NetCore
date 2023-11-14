using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class ListCourseStudentsViewModel
    {
        public List<int> StudentUserIds { get; set; }
        public int CourseId { get; set; }
    }
}
