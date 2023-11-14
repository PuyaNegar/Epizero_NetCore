using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamViewModels
{
    public class OnlineExamQuestionCorrectOptionsViewModel
    {
        //=====================================================
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamQuestionId { get; set; }
        //=====================================================



        /// <summary>
        /// 
        /// </summary>
        [DisplayName("گزینه صحیح")]
        [Required(ErrorMessage = "گزینه صحیح نبایستی خالی باشد")]
        public int CorrectOption { get; set; }
        //=====================================================
    }
}
