using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels; 
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseMeetingStudentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //============================================================
        public CourseMeetingStudentsComponent()
        {
            mainDBContext = new MainDBContext();
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDBContext);
        }
        //============================================================
        public IQueryable<CourseMeetingStudentsModel> Read(int CourseMeetingId)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.CourseMeetingId == CourseMeetingId && c.IsActive && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting, c => c.StudentUsers, c => c.ModUser);
            return result;
        }
        //============================================================
        public void Add(int CourseMeetingId, List<CourseMeetingStudentsModel> models)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == CourseMeetingId, c => c.Course);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                foreach (var model in models)
                    model.IsTemporaryRegistration = true;
                var studentIds = models.Select(c => c.StudentUserId).ToList();
                ValidateAbleToAddCourseMeeting(CourseMeetingId, studentIds);
                ValidateStudentsInCourse(result.CourseId, studentIds);
                courseMeetingStudentsRepository.AddRange(models);
                courseMeetingStudentsRepository.SaveChanges();
            }
        } 
        //============================================================
        public IQueryable<CourseMeetingStudentsModel> ReadByStudentId(int studentId)
        {
            var result = courseMeetingStudentsRepository.Where(c =>  c.StudentUserId == studentId && c.StudentFinancialDebts != null, c => c.Course.TeacherUser, c => c.StudentUsers, c => c.CourseMeeting.Course.TeacherUser);
            return result;
        }
        //============================================================
        public void Delete(int Id, int currentUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = courseMeetingStudentsRepository.SingleOrDefault(c => c.Id == Id, c => c.CourseMeeting.Course);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);

                    result.ModUserId = currentUserId;
                    result.ModDateTime = DateTime.UtcNow;
                    result.IsActive = false;
                    courseMeetingStudentsRepository.Update(result);
                    courseMeetingStudentsRepository.SaveChanges();

                    using (var studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(mainDBContext))
                    {
                        var studentFinancialDebts = studentFinancialDebtsRepository.Where(c => c.CourseMeetingStudentId == result.Id).ToList();
                        foreach (var studentFinancialDebt in studentFinancialDebts)
                        {
                            studentFinancialDebt.IsCanceled = true;
                            studentFinancialDebt.ModUserId = currentUserId;
                            studentFinancialDebt.ModDateTime = DateTime.UtcNow;
                            studentFinancialDebtsRepository.Update(studentFinancialDebt);
                        }
                        if (studentFinancialDebts.Any())
                            studentFinancialDebtsRepository.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=============================================================================== 
        void ValidateStudentsInCourse(int courseId , List<int> studentUserIds )
        {
           var result =  courseMeetingStudentsRepository.Where(c => c.IsActive &&  c.CourseId == courseId && studentUserIds.Contains(c.StudentUserId) && c.CourseMeetingStudentTypeId ==  (int)CourseMeetingStudentType.Course, c=>c.StudentUsers).Select(c=>new { c.StudentUsers.FirstName , c.StudentUsers.LastName });
            if (result.Any())
            {
                var names = string.Empty;
                foreach (var student in result)
                    names += student.FirstName + " " + student.LastName + " - ";
                throw new CustomException(names +"قبلاً در دوره کامل ثبت نام نموده اند");
            }
        }
        //=============================================================================== 
        void ValidateAbleToAddCourseMeeting(int CourseMeetingId, List<int> studentIds)
        {
            var classStudents = courseMeetingStudentsRepository.Where(c => c.CourseMeetingId == CourseMeetingId && studentIds.Contains(c.StudentUserId) && c.IsActive && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting, c => c.StudentUsers).Select(c => new { c.StudentUsers.FirstName, c.StudentUsers.LastName }).ToList();
            if (classStudents.Any())
            {
                var names = string.Empty;
                foreach (var classStudent in classStudents)
                    names += classStudent.FirstName + " " + classStudent.LastName + " - ";
                throw new CustomException( names + "  قبلاً به این جلسه اضافه شده اند");
            }
        }
     
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
