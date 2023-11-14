using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class StudentValidateProfilesComponent : IDisposable
    {
        private Repository<UsersModel> usersRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentValidateProfilesComponent()
        {
            usersRepository = new Repository<UsersModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Validate(int studentUserId)
        {
            var result = usersRepository.SingleOrDefault(c => c.Id == studentUserId && c.UserGroupId == (int)UserGroup.Student, c => c.StudentUserProfile);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            var hasError = false;
            var errorMessage = string.Empty;

            if (string.IsNullOrEmpty(result.StudentUserProfile.SchoolName))
            {
                hasError = true;
                errorMessage += "نام مدرسه را در بخش پروفایل تکمیل کنید" + "\n";
            }
            if (result.StudentUserProfile.SchoolTypeId == null)
            {
                hasError = true;
                errorMessage += "نوع مدرسه را در بخش پروفایل مشخص کنید" + "\n";
            }
            if (result.StudentUserProfile.FieldId == null)
            {
                hasError = true;
                errorMessage += "رشته خود را در بخش پروفایل مشخص کنید" + "\n";
            }

            if (result.StudentUserProfile.CityId == null)
            {
                hasError = true;
                errorMessage += "شهر را در بخش پروفایل مشخص کنید" + "\n";
            }
             
            if (hasError)
                throw new CustomException("شهر ، رشته ، نوع مدرسه ، نام مدرسه را در بخش پروفایل مشخص کنید");
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            usersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
