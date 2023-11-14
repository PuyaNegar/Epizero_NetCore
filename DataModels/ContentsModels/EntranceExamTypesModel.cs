using DataModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.ContentsModels
{
   public class EntranceExamTypesModel : IdentifierModel
    {
        public EntranceExamTypesModel()
        {
            AcceptedStudentInEntranceExams = new HashSet<AcceptedStudentInEntranceExamsModel>();
        }
        //*******************************************************************
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
        //*******************************************************************
        /// <summary>
        /// عنوان لاتین
        /// </summary>
        public string NameEN { get; set; }
        //*******************************************************************
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<AcceptedStudentInEntranceExamsModel> AcceptedStudentInEntranceExams { get; set; }
    }
}
