using DataModels.Base;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.OnlineExamModels
{
    public class OnlineExamFieldsModel : ModifyDateTimeWithUserModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int OnlineExamId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual OnlineExamsModel OnlineExam { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int FieldId { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public virtual FieldsModel Field { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=


    }
}
