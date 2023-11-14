using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class CourseStudentsReportsComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        List<UsersModel> StudentUsers = null;
        //======================================================================
        public CourseStudentsReportsComponent(int teacherUserId)
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
            StudentUsers = Read(teacherUserId);
        }
        //======================================================================
        List<UsersModel> Read(int teacherUserId)
        {
           var result =  courseMeetingStudentsRepository.Where(c => c.IsActive &&
                        c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course &&
                        c.Course.TeacherUserId == teacherUserId,
                         c => c.StudentUsers.StudentUserProfile.City,
                         c => c.StudentUsers.StudentUserProfile.Field,
                         c => c.StudentUsers.StudentUserProfile.Level).Select(c => new UsersModel()
                         {
                             Gender = c.StudentUsers.Gender,
                             StudentUserProfile = new StudentUserProfilesModel()
                             {
                                 LevelId = c.StudentUsers.StudentUserProfile.Level == null ? null : c.StudentUsers.StudentUserProfile.LevelId,
                                 Level = c.StudentUsers.StudentUserProfile.Level == null ? null : new LevelsModel() { Id = c.StudentUsers.StudentUserProfile.Level.Id, Name = c.StudentUsers.StudentUserProfile.Level.Name },
                                 CityId = c.StudentUsers.StudentUserProfile.CityId == null ? (int?)null : c.StudentUsers.StudentUserProfile.CityId.Value,
                                 City = c.StudentUsers.StudentUserProfile.City == null ? null : new CitiesModel() { Id = c.StudentUsers.StudentUserProfile.City.Id, Name = c.StudentUsers.StudentUserProfile.City.Name },
                                 FieldId = c.StudentUsers.StudentUserProfile.FieldId == null ? null : c.StudentUsers.StudentUserProfile.FieldId,
                                 Field = c.StudentUsers.StudentUserProfile.Field == null ? null : new FieldsModel { Id = c.StudentUsers.StudentUserProfile.Field.Id, Name = c.StudentUsers.StudentUserProfile.Field.Name },
                             }

                         }).ToList();
            return result;
        }
        //======================================================================
        public List<IntegerKeyValueViewModel> GetCities()
        {
            var result = StudentUsers.GroupBy(c => new { c.StudentUserProfile.CityId }).Select(c => new IntegerKeyValueViewModel()
            {
                Key = c.Key.CityId == null ? "نامشخص" : c.First().StudentUserProfile.City.Name,
                Value = c.Count()
            }).ToList();
            return result;
        }
        //======================================================================
        public List<IntegerKeyValueViewModel> GetGenders()
        {
            var count = StudentUsers.Count();
            var result = StudentUsers.GroupBy(c => new { c.Gender }).Select(c => new IntegerKeyValueViewModel()
            {
                Key = c.Key.Gender ? "مرد" : "زن",
                Value = Convert.ToInt32( c.Count() / (float)count * 100 ), 
            }).ToList();




            return result;
        }
        //======================================================================
        public List<IntegerKeyValueViewModel> GetLevels()
        {
            var result = StudentUsers.GroupBy(c => new { c.StudentUserProfile.LevelId }).Select(c => new IntegerKeyValueViewModel()
            {
                Key = c.Key.LevelId == null ? "نامشخص" : c.First().StudentUserProfile.Level.Name,
                Value = c.Count()
            }).ToList();
            return result;
        }
        //======================================================================
        public List<IntegerKeyValueViewModel> GetFields()
        {
            var result = StudentUsers.GroupBy(c => new { c.StudentUserProfile.FieldId }).Select(c => new IntegerKeyValueViewModel()
            {
                Key = c.Key.FieldId == null ? "نامشخص" : c.First().StudentUserProfile.Field.Name,
                Value = c.Count()
            }).ToList();
            return result;
        }
        //======================================================================
        public void Dispose()
        {
            StudentUsers = null;
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
