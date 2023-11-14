using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.TrainingManagementViewModels
{
    public class LevelSelectorViewModel
    {
        //===================================================================
        /// <summary>
        ///  مقطع تحصیلی
        /// </summary>
        [Display(Name = "مقطع تحصیلی")]
        public int LevelGroupId { get; set; }
        //===================================================================
        /// <summary>
        ///  پایه تحصیلی
        /// </summary>
        [Display(Name = "پایه تحصیلی")]
        public int LevelId { get; set; }
    }
}
