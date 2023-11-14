using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class StudentCourseAndCourseMeetingsComponent : IDisposable
    {

        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //==============================================
        public StudentCourseAndCourseMeetingsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //==============================================
        public IQueryable<CourseMeetingStudentsModel> Read(int studentUserId)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && c.StudentUserId == studentUserId, c => c.Course, c => c.CourseMeeting.Course);
            return result;
        }
        //==============================================
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
