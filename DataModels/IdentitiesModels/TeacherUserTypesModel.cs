using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels.IdentitiesModels
{
   public class TeacherUserTypesModel
    {
        public TeacherUserTypesModel()
        {
            TeacherUserProfiles = new HashSet<TeacherUserProfilesModel>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string NameEN { get; set; }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public virtual ICollection<TeacherUserProfilesModel> TeacherUserProfiles { get; set; }
    }
}
