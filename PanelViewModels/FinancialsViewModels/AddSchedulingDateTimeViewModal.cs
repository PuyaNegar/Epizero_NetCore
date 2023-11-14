using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PanelViewModels.FinancialsViewModels
{
    public class AddSchedulingDateTimeViewModal
    {
        [Display(Name = "تاریخ تسویه")]
        [Required(ErrorMessage = "تاریخ تسویه نبایستی خالی باشد")]
        [RegularExpression(@"^\d{4}/\d{2}/\d{2}$", ErrorMessage = "فرمت تاریخ تسویه صحیح نمی باشد")]
        public DateTime Date { get; set; }
        //==================================================================
        [Display(Name = "نحوه پرداخت ")]
        [Required(ErrorMessage = "فیلد نبایستی خالی باشد")]
        public int TeacherPaymentMethodId { get; set; }
    }
}
