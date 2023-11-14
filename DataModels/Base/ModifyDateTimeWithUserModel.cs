using System;
using System.Collections.Generic;
using System.Text;
using DataModels.IdentitiesModels;

namespace DataModels.Base
{
    public class ModifyDateTimeWithUserModel : IdentifierModel
    {
        //=============================================================
        /// <summary>
        /// تاریخ تغییر
        /// </summary>
        public DateTime? ModDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// تاریخ درج
        /// </summary>
        public DateTime RegDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// شناسه ویرایش کننده
        /// </summary>
        public int ModUserId { get; set; }
        //=============================================================
        /// <summary>
        /// ویرایش کننده
        /// </summary>
        public virtual UsersModel ModUser { get; set; }
        //=============================================================
    }
}
