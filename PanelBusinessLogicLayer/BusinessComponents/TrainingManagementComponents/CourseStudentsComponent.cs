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
    public class CourseStudentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //============================================================
        public CourseStudentsComponent()
        {
            mainDBContext = new MainDBContext();
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDBContext);
        }
        //============================================================
        public IQueryable<CourseMeetingStudentsModel> Read(int CourseId)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && c.CourseId == CourseId && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course, c => c.StudentUsers ,c=> c.StudentUsers.StudentUserProfile.Field, c => c.ModUser);
            return result;
        }
        //============================================================
        public void Add(int CourseId, List<CourseMeetingStudentsModel> models)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var coursesRepository = new Repository<CoursesModel>())
                    {
                        var studentIds = models.Select(c => c.StudentUserId).ToList();
                        var result = coursesRepository.SingleOrDefault(c => c.Id == CourseId);
                        if (result == null)
                            throw new CustomException(SystemCommonMessage.DataWasNotFound);
                        foreach (var model in models)
                            model.IsTemporaryRegistration = true; 
                        ValidateAbleToAddCourse(CourseId, studentIds); 
                        courseMeetingStudentsRepository.AddRange(models);
                        courseMeetingStudentsRepository.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException(ex.Message);
                }
            }
        }
        //============================================================
        public void Delete(int Id, int currentUserId)
        {

            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = courseMeetingStudentsRepository.SingleOrDefault(c => c.Id == Id, c => c.Course);
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


        void ValidateAbleToAddCourse(int CourseId, List<int> studentIds)
        {
            var courseStudents = courseMeetingStudentsRepository.Where(c =>c.IsActive &&  c.CourseId == CourseId && studentIds.Contains(c.StudentUserId) && c.IsActive && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course , c=>c.StudentUsers).Select(c => new { c.StudentUsers.FirstName, c.StudentUsers.LastName }).ToList();
            if (courseStudents.Any())
            {
                var names = string.Empty;
                foreach (var courseStudent in courseStudents)
                    names += courseStudent.FirstName + " " + courseStudent.LastName + " - ";
                throw new CustomException(names + "  قبلاً به این دوره اضافه شده اند");
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
