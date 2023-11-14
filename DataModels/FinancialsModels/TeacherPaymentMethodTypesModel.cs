using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.FinancialsModels
{
    public class TeacherPaymentMethodTypesModel
    {
        public TeacherPaymentMethodTypesModel()
        {
            TeacherPaymentMethods = new HashSet<TeacherPaymentMethodsModel>();
        }
        //================================
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        //================================
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        //================================
        /// <summary>
        /// 
        /// </summary>
        public string NameEN { get; set; }
        //=================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public ICollection<TeacherPaymentMethodsModel> TeacherPaymentMethods { get; set; }
    }
}
