using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using System; 

namespace DataModels.IdentitiesModels
{
    public class TeacherUserProfilesModel : IdentifierModel
    {
        public string MetaDescription { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsShowFinancial { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public bool IsEnabledSms { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BirthDay { get; set; }
        //=============================================  
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string LessonTeacher { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Skill { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public string BannerPicPath { get; set; }
        //=======================================================================ارتباطات
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel User { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int CityId { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual CitiesModel City { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public int TeacherPrefixId  { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherPrefixesModel TeacherPrefix {get;set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int TeacherUserTypeId { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual TeacherUserTypesModel TeacherUserType { get; set; }
        //=============================================================== 

    }
}
