using System;

namespace DataModels.Base
{
    public class ModifyDateTimeModel : IdentifierModel
    {
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModDateTime { get; set; }
        //=============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegDateTime { get; set; }
        //=============================================================
    }
}
