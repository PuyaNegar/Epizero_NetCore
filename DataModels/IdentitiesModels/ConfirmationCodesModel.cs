using System;
using DataModels.Base;
namespace DataModels.IdentitiesModels
{
    public class ConfirmationCodesModel : IdentifierModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public string SendCode { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsConfirm { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime SentDateTime { get; set; }
        //=========================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpireDateTime { get; set; }
        //=========================================================
    }
}
