using DataModels.IdentitiesModels;
using System;


namespace DataModels.TrainingManagementModels
{
    public class CourseFAQsModel
    {
         
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public int Inx { get; set; }
        //===============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime ModDateTime { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int CourseId { get; set; }
        public virtual CoursesModel Course { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /// <summary>
        /// 
        /// </summary>
        public int FAQId { get; set; }
        public virtual FAQModel FAQ { get; set; }
        //===================================================== ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int ModUserId { get; set; }

        //============================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel ModUser { get; set; }
    }
}
