using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;
 
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class UserProfilesService : IDisposable
    {
        private UserProfilesComponent userProfilesComponent;
        //====================================================
        public UserProfilesService()
        {
            userProfilesComponent = new UserProfilesComponent();
        }
        //====================================================
        public SysResult<StudentUserProfileViewModel> Find(int CurrentUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var user = userProfilesComponent.Find(CurrentUserId);
            var result = user.StudentUserProfile == null ? new StudentUserProfileViewModel() { FirstName = user.FirstName, LastName = user.LastName } : new StudentUserProfileViewModel()
            {
                UserHashId = user.Id.ToString().EncriptWithDESAlgoritm() ,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender.ToActiveStatus(),
                NationalCode = user.NationalCode,
                PersonalPicPath = string.IsNullOrEmpty(user.PersonalPicPath) ? string.Empty :  user.PersonalPicPath,
                NationalCardPicPath = string.IsNullOrEmpty(user.StudentUserProfile.NationalCardPicPath) ? string.Empty :  user.StudentUserProfile.NationalCardPicPath,
                CityId = user.StudentUserProfile.CityId,
                CityName = user.StudentUserProfile.CityId == null ? string.Empty : user.StudentUserProfile.City.Province.Name + " _ " + user.StudentUserProfile.City.Name,
                FatherMobNo = user.StudentUserProfile.FatherMobNo,
                MotherMobNo = user.StudentUserProfile.MotherMobNo,
                FeildId = user.StudentUserProfile.FieldId,
                LevelId = user.StudentUserProfile.LevelId,
                HomePhoneNumber = user.StudentUserProfile.HomePhoneNumber,
                IntroductionWithAcademyTypeId = user.StudentUserProfile.IntroductionWithAcademyTypeId,
                BirthDay = user.StudentUserProfile.BirthDay.HasValue ? user.StudentUserProfile.BirthDay.Value.ToLocalDateTime().ToDateShortFormatString() : null,
                SchoolTypeId = user.StudentUserProfile.SchoolTypeId,
                SchoolName = user.StudentUserProfile.SchoolName,
                FavoriteJob = user.StudentUserProfile.FavoriteJob,
                Email = user.StudentUserProfile.Email

            };
            return new SysResult<StudentUserProfileViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //====================================================
        public SysResult Update(StudentUserProfileViewModel viewModel, int CurrentUserId)
        {

            var model = new StudentUserProfilesModel()
            {
                UserId = CurrentUserId,
                BirthDay =  string.IsNullOrEmpty(viewModel.BirthDay)   ? (DateTime?)null : viewModel.BirthDay.CharacterAnalysis().ToDate().ToUtcDateTime(),
                HomePhoneNumber = viewModel.HomePhoneNumber,    
                SchoolName = viewModel.SchoolName,
                SchoolTypeId = viewModel.SchoolTypeId,
                IntroductionWithAcademyTypeId = viewModel.IntroductionWithAcademyTypeId,
                CityId = viewModel.CityId,
                Email = viewModel.Email,
                FatherMobNo = viewModel.FatherMobNo,
                MotherMobNo = viewModel.MotherMobNo,
                FieldId = viewModel.FeildId,
                LevelId = viewModel.LevelId,
                FavoriteJob = viewModel.FavoriteJob,
                NationalCardPicPath = viewModel.NationalCardPicPath,
                User = new UsersModel() { FirstName = viewModel.FirstName, LastName = viewModel.LastName, Gender = viewModel.Gender.Value.ToBoolean(), PersonalPicPath = viewModel.PersonalPicPath, NationalCode = viewModel.NationalCode }
            };
            userProfilesComponent.AddOrUpdate(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //====================================================
        public SysResult UpdateField(SelectedFeildViewModel viewModel, int CurrentUserId)
        {
            var model = new StudentUserProfilesModel()
            {
                UserId = CurrentUserId,
                FieldId = viewModel.FieldId,
            };
            userProfilesComponent.UpdateField(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }

        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            userProfilesComponent?.Dispose();
        }
        #endregion
    }
}
