using Common.Enums; 
using System.ComponentModel.DataAnnotations;

namespace PanelViewModels.FinancialsViewModels
{
    public class StudentChequeChangeStatusViewModel
    {
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "شناسه چک نبایستی خالی باشد")]
        public int StudentFinancialPaymentId { get; set; }
        //================================================
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "وضعیت چک را مشخص کنید")]
        public int ChequesStatusTypeId { get; set; }
        //================================================
    }
}
