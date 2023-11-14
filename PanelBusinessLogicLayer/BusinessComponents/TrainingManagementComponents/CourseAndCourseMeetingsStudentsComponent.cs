using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseAndCourseMeetingsStudentsComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //==============================================
        public CourseAndCourseMeetingsStudentsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //==============================================
        IQueryable<CourseMeetingStudentsModel> ReadCourseStudent(int courseId)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && (
           (c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course && c.CourseId == courseId)), c => c.StudentUsers.StudentUserProfile.City, c => c.CourseMeetingStudentType, c => c.Course);
            return result;
        }
        //==============================================
        IQueryable<CourseMeetingStudentsModel> ReadCourseMeetingStudent(int courseMeetingId, int? teacherUserId)
        {
            var courseId = GetCourseId(courseMeetingId, teacherUserId);
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && (
           (c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting && c.CourseMeetingId == courseMeetingId) ||
           (c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course && c.CourseId == courseId)), c => c.StudentUsers.StudentUserProfile.City, c => c.CourseMeetingStudentType, c => c.Course);
            return result;
        }
        //==============================================
        public List<CourseMeetingStudentsModel> ReadCourseStudentsWithoutDuplicate(int courseId)
        {
            var result = ReadCourseStudent(courseId).ToList().GroupBy(c => new { c.StudentUserId, c.CourseId }).Select(c => c.OrderBy(c => c.CourseMeetingStudentTypeId).First()).ToList();
            return result;
        }
        //==============================================
        public List<CourseMeetingStudentsModel> ReadCourseMeetingStudentsWithoutDuplicate(int courseMeetingId, int? teacherUserId)
        {
            var result = ReadCourseMeetingStudent(courseMeetingId, teacherUserId).ToList().GroupBy(c => new { c.StudentUserId, c.CourseId }).Select(c => c.OrderBy(c => c.CourseMeetingStudentTypeId).First()).ToList();
            return result;
        }
        //==============================================
        int GetCourseId(int courseMeetingId, int? teacherUserId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.Where(c => c.Id == courseMeetingId);
                if (teacherUserId != null)
                    result = result.Where(c => c.TeacherUserId == teacherUserId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.SingleOrDefault().CourseId;
            }
        }


        //===================================================
        public static List<CourseMeetingsModel> Read(int studentUserId)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
            {
                var courseMeetingStudents = courseMeetingStudentsRepository.Where(c => c.IsActive && c.StudentUserId == studentUserId && c.Course.IsActive, c => c.CourseMeeting.Course, c => c.CourseMeeting.TeacherUser, c => c.Course.TeacherUser).ToList();
                var courseIds = courseMeetingStudents.Where(c => c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).Select(c => c.CourseId).ToList();
                using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
                {
                    var courseMeetings_1 = courseMeetingsRepository.Where(c => courseIds.Contains(c.CourseId) && c.IsActive, c => c.TeacherUser, c => c.Course.TeacherUser).ToList();
                    var courseMeetings_2 = courseMeetingStudents.Where(c => c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting && c.CourseMeeting.IsActive).Select(c => c.CourseMeeting).ToList();
                    var result = courseMeetings_1.Concat(courseMeetings_2).ToList().GroupBy(c => c.Id).Select(c => c.First()).ToList();
                    return result;
                }
            }
        } 
        //===================================================
        public static void Validate(int studentUserId, int courseMeetingId)
        {
            var result = Read(studentUserId);
            if (!result.Any(c => c.Id == courseMeetingId))
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
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
