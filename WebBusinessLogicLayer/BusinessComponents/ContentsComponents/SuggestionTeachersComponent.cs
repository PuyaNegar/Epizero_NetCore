using System;
using System.Collections.Generic;
using System.Linq;
using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class SuggestionTeachersComponent : IDisposable
    {
        private Repository<SuggestionTeachersModel> suggestionTeachersRepository;
        //===========================================================
        public SuggestionTeachersComponent()
        {
            suggestionTeachersRepository = new Repository<SuggestionTeachersModel>();
        }
        //===========================================================
        public List<SuggestionTeachersViewModel> Read()
        {
            var RootCdnPath = AppConfigProvider.CdnUrl();
            var result = suggestionTeachersRepository.Where(c => c.IsActive, c => c.TeacherUser.TeacherUserProfile.TeacherPrefix, c => c.TeacherUser.TeacherUserProfile.TeacherUserType).OrderBy(c => c.Inx).Select(c => new SuggestionTeachersViewModel()
            {
                TeacherFullName = c.TeacherUser.FirstName +" " + c.TeacherUser.LastName,
                TeacherPersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : RootCdnPath + c.TeacherUser.PersonalPicPath,
                TeacherId = c.TeacherUserId,
                TeacherUserTypeName = c.TeacherUser.TeacherUserProfile.TeacherUserType.Name,
                TeacherUserTypeId = c.TeacherUser.TeacherUserProfile.TeacherUserTypeId,
                Skill = c.TeacherUser.TeacherUserProfile == null ? string.Empty : c.TeacherUser.TeacherUserProfile.Skill,
                TeacherPrifixTitle = c.TeacherUser.TeacherUserProfile == null ? string.Empty : c.TeacherUser.TeacherUserProfile.TeacherPrefix.Title,
            }).ToList();
            return result;
        }
        //=========================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            suggestionTeachersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //============================================================
    }
}
