using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Enums;
using System.Linq.Expressions;
using PanelViewModels.TeacherTrainingsViewModels;
using PanelViewModels.TrainingManagementViewModels;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherCoursesComponent : IDisposable
    {
        private Repository<CoursesModel> coursesRepository;
        //====================================================
        public TeacherCoursesComponent()
        {
            coursesRepository = new Repository<CoursesModel>();
        }
        //====================================================
        public IQueryable<CoursesModel> Read(int teacherUserId)
        {
            var result = coursesRepository.Where(c => c.TeacherUserId == teacherUserId && c.IsActive);
            return result;
        }
        //====================================================
        public List<TeacherCoursesViewModel> ReadWithCourseMeetings(int teacherUserId, CourseCategoryType? courseCategoryType)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {

                var query1 = courseCategoryType == null ? (Expression<Func<CourseMeetingsModel, bool>>)(c => c.TeacherUserId == teacherUserId && c.IsActive && c.Course.IsActive) : (Expression<Func<CourseMeetingsModel, bool>>)(c => c.Course.CourseCategoryTypeId == (int)courseCategoryType && c.TeacherUserId == teacherUserId && c.IsActive && c.Course.IsActive);
                var courseMeetings = courseMeetingsRepository.Where(query1).ToList();
                var query2 = courseCategoryType == null ? (Expression<Func<CoursesModel, bool>>)(c => c.TeacherUserId == teacherUserId && c.IsActive) : (Expression<Func<CoursesModel, bool>>)(c => c.CourseCategoryTypeId == (int)courseCategoryType && c.TeacherUserId == teacherUserId && c.IsActive);
                var result = coursesRepository.Where(query2).ToList().Select(c => new TeacherCoursesViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    CourseDuration = c.CourseDuration,
                    StartDate = c.StartDate == null ? "ثبت نشده" : c.StartDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                    EndDate = c.EndDate == null ? "ثبت نشده" : c.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                    CourseMeetings = courseMeetings.Where(d => d.CourseId == c.Id).Select(d => new TeacherCourseMeetingsViewModel()
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        StartDateTime = d.StartDateTime.ToLocalDateTimeShortFormatString(),
                    }).ToList(),
                }).ToList();
                return result;
            }
        }
       
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            coursesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
