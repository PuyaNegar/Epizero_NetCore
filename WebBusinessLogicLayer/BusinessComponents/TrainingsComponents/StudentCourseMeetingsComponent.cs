using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public static class StudentCourseMeetingsComponent
    {
        //===================================================
        public static StudentAccessToCourseViewModel ReadAvalibleCourse(int studentUserId, int courseId)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
            {
                var result = courseMeetingStudentsRepository.Where(c => c.IsActive && c.StudentUserId == studentUserId && c.CourseId == courseId).ToList();
                if (!result.Any())
                    return new StudentAccessToCourseViewModel() { IsAccessToEntireCourse = false, AvalibleCourseMeetingIds = new List<int>() };
                if (result.Where(c => c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).Any())
                    return new StudentAccessToCourseViewModel() { IsAccessToEntireCourse = true, AvalibleCourseMeetingIds = new List<int>() };
                return new StudentAccessToCourseViewModel() { IsAccessToEntireCourse = false, AvalibleCourseMeetingIds = result.Where(c => c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting).Select(c => c.CourseMeetingId.Value).Distinct().ToList() };
            }
        }
        //===================================================
        public static List<StudentCourseGroupsViewModel> ReadWithGrouping(int studentUserId, CourseCategoryType courseCategoryType)
        {
            var result = Read(studentUserId).Where(c => c.Course.CourseCategoryTypeId == (int)courseCategoryType).ToList();
            return CreateGroups(result);
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
        //===================================================
        static List<StudentCourseGroupsViewModel> CreateGroups(List<CourseMeetingsModel> model)
        {
            var result = model.GroupBy(c => new { c.Course.Id, c.Course.Name }).Select(c => new StudentCourseGroupsViewModel()
            {
                Id = c.Key.Id,
                Name = c.Key.Name,
                StudentCourseMeetings = c.Select(d => new StudentCourseMeetingsViewModel()
                {
                    CourseMeetingId = d.Id,
                    Name = d.Name,
                    TeacherFullName = d.TeacherUser.FirstName + " " + d.TeacherUser.LastName,
                    HasHomework = d.HasHomework,
                    HasBooklet = d.HasBooklet,
                }).ToList()
            }).ToList();
            return result;
        }
        //===================================================
    }
}
