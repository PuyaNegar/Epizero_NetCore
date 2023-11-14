using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using System;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Common.Enums;

namespace TeacherBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public class CourseMeetingStudentSmsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private TeacherCourseMeetingsStudentsComponent courseMeetingsStudents;
        private Repository<StudentUserSmsOptionsModel> studentUserSmsOptionsRepository;
        private Repository<SmsOptionsModel> smsOptionsRepository;
        //===========================================
        public CourseMeetingStudentSmsComponent()
        {
            mainDBContext = new MainDBContext();
            courseMeetingsStudents = new TeacherCourseMeetingsStudentsComponent(mainDBContext);
            studentUserSmsOptionsRepository = new Repository<StudentUserSmsOptionsModel>(mainDBContext);
            smsOptionsRepository = new Repository<SmsOptionsModel>();
        }
        //===========================================
        public List<UsersModel> Operation(int courseMeetingId, int teacherUserId, SmsOption smsOption, int? studentUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var smsOptions = smsOptionsRepository.SingleOrDefault(c => c.Id == (int)smsOption && c.IsActive);
                    if (smsOptions == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    var result = GetCourseMeetingStudents(courseMeetingId, teacherUserId ,    smsOptions, studentUserId);
                    UpdateStudentUsersSmsCredit(smsOptions, result);
                    transaction.Commit();
                    return CreateModel(result);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

        }
        //===========================================
        private static List<UsersModel> CreateModel(List<UsersModel> result)
        {
            return result.Select(c => new UsersModel()
            {
                Id = c.Id , 
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserName = c.UserName,
            }).GroupBy(c=>c.Id).Select(c=>c.First()).ToList();
        }
        //===========================================
        List<UsersModel> GetCourseMeetingStudents(int courseMeetingId, int teacherUserId,   SmsOptionsModel smsOptions, int? studentUserId)
        {
            var query = courseMeetingsStudents.Read(courseMeetingId, teacherUserId).Where(c => c.StudentUsers.StudentUserProfile.SMSCredit >= smsOptions.Price);
            if (studentUserId != null)
                query = query.Where(c => c.StudentUserId == studentUserId.Value);
            var model = query.Join(studentUserSmsOptionsRepository.Where(c => c.SmsOption.IsActive && c.SmsOptionId == smsOptions.Id),
            c => c.StudentUserId,
            d => d.StudentUserId,
            (c, d) => new UsersModel
            {
                Id = c.StudentUserId,
                UserName = c.StudentUsers.UserName,
                FirstName = c.StudentUsers.FirstName,
                LastName = c.StudentUsers.LastName,
                StudentUserProfile = c.StudentUsers.StudentUserProfile
            }).ToList();
            return model;
        }
        //==========================================================
        void UpdateStudentUsersSmsCredit(SmsOptionsModel smsOptions, List<UsersModel> result)
        {
            using (var studentUserProfilesRepository = new Repository<StudentUserProfilesModel>(mainDBContext))
            {
                foreach (var studentUserProfile in result.Select(c => c.StudentUserProfile).GroupBy(c=>c.UserId).Select(c=>c.First()).ToList())
                {
                    studentUserProfile.SMSCredit = (studentUserProfile.SMSCredit - smsOptions.Price < 0) ? 0 : (studentUserProfile.SMSCredit - smsOptions.Price);
                    studentUserProfilesRepository.Update(studentUserProfile);
                }
                studentUserProfilesRepository.SaveChanges();
            }
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            courseMeetingsStudents?.Dispose();
            studentUserSmsOptionsRepository?.Dispose();
            smsOptionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
