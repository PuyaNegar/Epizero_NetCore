
namespace PanelViewModels.FinancialsViewModels
{
    public class PercentageMultiTeacherSharesViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserId { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string  TeacherFullName { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public long CalculatedAmount { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public int Percent { get; set; }
        //=================================================
        /// <summary>
        /// 
        /// </summary>
        public string CourseOrExamName { get; set; }
    }
}
