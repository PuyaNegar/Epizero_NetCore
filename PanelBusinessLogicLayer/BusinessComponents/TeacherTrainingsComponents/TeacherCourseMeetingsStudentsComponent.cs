using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherCourseMeetingsStudentsComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //==============================================
        public TeacherCourseMeetingsStudentsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //==============================================
        public TeacherCourseMeetingsStudentsComponent(MainDBContext mainDBContext)
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDBContext);
        }
        //==============================================
        public IQueryable<CourseMeetingStudentsModel> Read(int courseMeetingId, int teacherUserId)
        {
            var courseId = GetCourseId(courseMeetingId, teacherUserId);
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && (
           (c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting && c.CourseMeetingId == courseMeetingId) ||
           (c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course && c.CourseId == courseId)), c => c.StudentUsers.StudentUserProfile.City , c=>c.CourseMeetingStudentType, c=> c.Course);
            return result;
        }
        //==============================================
        public List<CourseMeetingStudentsModel> ReadWithoutDuplicate(int courseMeetingId, int teacherUserId)
        {
          var result =   Read(courseMeetingId , teacherUserId ).ToList() .GroupBy(c => new { c.StudentUserId, c.CourseId }).Select(c => c.OrderBy(c => c.CourseMeetingStudentTypeId).First()).ToList();
            return result;
        } 
        //==============================================
        int GetCourseId(int courseMeetingId, int teacherUserId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == courseMeetingId && c.TeacherUserId == teacherUserId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.CourseId;
            }
        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
