using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents
{
    public class TeacherCourseStudentFinancialsComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //======================================================
        public TeacherCourseStudentFinancialsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //=====================================================================
        public IQueryable<CourseMeetingStudentsModel> Read(int courseId , int teacherUserId )
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && c.CourseId == courseId && c.Course.TeacherUserId == teacherUserId , c=>c.StudentUsers.StudentUserProfile.City , c=>c.CourseMeeting.Course , c=>c.Course , c=>c.Order.DiscountCode);
            return result;
        }
        //===============================================
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
