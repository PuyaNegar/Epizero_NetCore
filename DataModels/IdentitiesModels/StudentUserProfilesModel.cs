using DataModels.Base;
using DataModels.BasicDefinitionsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Numerics;

namespace DataModels.IdentitiesModels
{
    public class StudentUserProfilesModel : IdentifierModel
    {
         
        /// <summary>
        /// 
        /// </summary>
        public string HomePhoneNumber { get; set; }
        //=============================================
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BirthDay { get; set; }
        //============================================= 
        /// <summary>
        /// 
        /// </summary>
        public string SchoolName { get; set; } 
        //============================================= 
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        //============================================= 
        /// <summary>
        /// 
        /// </summary>
        public string FatherMobNo { get; set;  }
        //============================================= 
        /// <summary>
        /// 
        /// </summary>
        public string MotherMobNo { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string NationalCardPicPath  { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public string FavoriteJob { get; set; }
        //============================================
        /// <summary>
        /// 
        /// </summary>
        public int SMSCredit { get; set; }
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
        public int ?  CityId { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual CitiesModel City { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int? SchoolTypeId { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual SchoolTypesModel SchoolType  { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public int? IntroductionWithAcademyTypeId { get; set; }
        //=============================================================== 
        /// <summary>
        /// 
        /// </summary>
        public virtual IntroductionWithAcademyTypesModel  IntroductionWithAcademyType { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? FieldId { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual FieldsModel Field { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? LevelId { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual LevelsModel Level { get; set; }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public int? IdentifierUserId { get; set;  }
        //===============================================================
        /// <summary>
        /// 
        /// </summary>
        public virtual UsersModel IdentifierUser  { get; set;  }
    }
}
