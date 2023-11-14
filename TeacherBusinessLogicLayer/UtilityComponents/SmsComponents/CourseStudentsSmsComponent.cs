using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using DataModels.TrainingManagementModels;
using Common.Enums;

namespace TeacherBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public class CourseStudentsSmsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        private Repository<StudentUserSmsOptionsModel> studentUserSmsOptionsRepository;
        private Repository<SmsOptionsModel> smsOptionsRepository;
        //===========================================
        public CourseStudentsSmsComponent()
        {
            mainDBContext = new MainDBContext();
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDBContext);
            studentUserSmsOptionsRepository = new Repository<StudentUserSmsOptionsModel>(mainDBContext);
            smsOptionsRepository = new Repository<SmsOptionsModel>();
        }
        //===========================================
        public List<UsersModel> Operation(int courseId, SmsOption smsOption  , int? studentUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var smsOptions = smsOptionsRepository.SingleOrDefault(c => c.Id == (int)smsOption && c.IsActive);
                    if (smsOptions == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    var result = GetCourseMeetingStudents(courseId , smsOptions, studentUserId);
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
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                UserName = c.UserName,
            }).ToList().GroupBy(c => c.Id).Select(c => c.First()).ToList();
        }
        //===========================================
        List<UsersModel> GetCourseMeetingStudents(int courseId,     SmsOptionsModel smsOptions, int? studentUserId)
        {
            var query = courseMeetingStudentsRepository.Where(c => c.CourseId == courseId && c.IsActive).Where(c => c.StudentUsers.StudentUserProfile.SMSCredit >= smsOptions.Price);
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
            }).ToList() ;
            return model;
        }
        //==========================================================
        void UpdateStudentUsersSmsCredit(SmsOptionsModel smsOptions, List<UsersModel> result)
        {
            using (var studentUserProfilesRepository = new Repository<StudentUserProfilesModel>(mainDBContext))
            {
                foreach (var studentUserProfile in result.Select(c => c.StudentUserProfile).ToList().GroupBy(c => c.UserId).Select(c => c.First()).ToList())
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
            courseMeetingStudentsRepository?.Dispose();
            studentUserSmsOptionsRepository?.Dispose();
            smsOptionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
