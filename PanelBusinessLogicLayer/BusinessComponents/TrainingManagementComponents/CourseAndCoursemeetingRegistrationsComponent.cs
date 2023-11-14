using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class CourseAndCoursemeetingRegistrationsComponent : IDisposable
    {
 
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //============================================================
        public CourseAndCoursemeetingRegistrationsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //============================================================
        public IQueryable<CourseMeetingStudentsModel> Read()
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive ,c=> c.Course, c => c.StudentUsers,c=> c.StudentUsers.StudentUserProfile.City, c => c.ModUser);
            return result.OrderByDescending(c=> c.RegDateTime);
        }
        //===================================================
        public CourseMeetingStudentsModel Find(int Id)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.Id == Id, c => c.Course, c => c.StudentUsers, c => c.StudentUsers.StudentUserProfile.City).SingleOrDefault();
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
