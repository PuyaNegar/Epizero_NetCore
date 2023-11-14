using DataModels.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataModels.FinancialsModels
{
    public class PaidChequesModel : ModifyDateTimeWithUserModel
    {
        public PaidChequesModel()
        {
            StudentCheques = new HashSet<StudentChequesModel>();
        }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public DateTime DueDate { get; set; }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public DateTime IssueDate { get; set; }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public int AmountPaid { get; set; }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public string ChequesNo { get; set; }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //========================================  
        /// <summary>
        /// 
        /// </summary>
        public int RemainingAmount { get; set; }

        //========================================
        //========================================
        //
        /// <summary>
        /// کد شعبه
        /// </summary>
        public string BranchCode { get; set; }
        //========================================  
        /// <summary>
        /// نام شعبه
        /// </summary>
        public string BranchName { get; set; }
        //========================================
        /// <summary>
        /// کد صیادی 16 رقمی
        /// </summary>
        public string FishingCode { get; set; }
        //========================================
        /// <summary>
        /// شماره حساب
        /// </summary>
        public string AccountNumber { get; set; }
        //========================================
        /// <summary>
        /// نام صاحب حساب
        /// </summary>
        public string NameAccountHolder { get; set; }
        //========================================
        //========================================


        //============================================================================================ ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int BankId { get; set; }
        //====================================================
        ///<summary>
        /// 
        /// </summary>
        public virtual BanksModel Bank { get; set; }

        //====================================================
        /// <summary>
        /// 
        /// </summary>
        public int ChequesStatusTypeId { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public int StudentFinancialPaymentId { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ChequesStatusTypesModel ChequesStatusType { get; set; }
        //========================================
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<StudentChequesModel> StudentCheques { get; set; }
    }
}
