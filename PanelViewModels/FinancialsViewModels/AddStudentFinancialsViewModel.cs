using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace PanelViewModels.FinancialsViewModels
{
   public class AddStudentFinancialsViewModel
    {
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set;  }


        public int? CourseMeetingId { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public string StudentUserIds  { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "تاریخ ثبت")]
        [Required(ErrorMessage = " نوع آموزش نبایستی خالی باشد")]
        public int CourseMeetingStudentTypeId { get; set; } 
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public AddSalesPartnerUserSharesViewModel AddSalesPartnerUserShares { get; set; }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public AddStudentFinancialManualDebtViewModel ManualDebt { get; set; }
        //=====================================================================

        /// <summary>
        /// 
        /// </summary>
        public AddStudentFinancialPaymentsViewModel  Cash { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public AddStudentFinancialPaymentsViewModel BankTransfer { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentFinancialPosPaymentsViewModel PosPayments { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentDiscountsViewModel StudentDiscount { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public List<AddChequePaymentsViewModel> Cheques { get; set;  }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        public StudentPaymentLinksViewModel StudentPaymentLink { get; set;  }
    }
}
