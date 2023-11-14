using System;
using System.Collections.Generic;
using System.Text;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class UpdateAbsentationsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseMeetingId  { get; set; }
        //======================================================
        /// <summary>
        /// 
        /// </summary>
        public List<int> StudentUserIds  { get; set; }
        //======================================================
    }
}
