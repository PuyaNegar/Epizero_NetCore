using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.OnlineExamsViewModels
{
   public class OnlineExamMultipleChoiceQuestionsViewModel
    {
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن سوال")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string QuestionContext { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "متن سوال")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string QuestionContext_CkFormat { get; set; }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محتوای سوال")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsTextQuestionContext { get; set; } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 1")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option1 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 2")]
       // [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option2 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 3")]
      //  [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option3 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 4")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option4 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=




        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 1")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option1_CkFormat { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 2")]
        // [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option2_CkFormat { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 3")]
        //  [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option3_CkFormat { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه 4")]
        //[Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public string Option4_CkFormat { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=








        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "گزینه صحیح")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int  CorrectOption { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پاسخ تشریحی")]
        public string DescriptiveAnswer { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "پاسخ تشریحی")]
        public string DescriptiveAnswer_CkFormat { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محتوای گزینه 1")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsTextOption1 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محتوای گزینه 2")]
         [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsTextOption2 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محتوای گزینه 3")]
          [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsTextOption3 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "محتوای گزینه 4")]
         [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public ActiveStatus IsTextOption4 { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    }
}
