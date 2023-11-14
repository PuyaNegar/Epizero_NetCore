using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;  
using System.Linq; 

namespace TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents
{
   public class TeacherCourseMeetingsComponent
    {
        private Repository<CourseMeetingsModel> courseMeetingsRepository;
        //==============================================================
        public TeacherCourseMeetingsComponent()
        {
            courseMeetingsRepository = new Repository<CourseMeetingsModel>(); 
        }
        //==============================================================
        public IQueryable<CourseMeetingsModel> Read(int courseId  , int teacherUserId)
        {
            var result = courseMeetingsRepository.Where(c => c.TeacherUserId == teacherUserId && c.CourseId == courseId);
            return result;
        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
