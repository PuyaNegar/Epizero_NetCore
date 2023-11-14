using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class TemporaryCourseStudentsComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        //=============================================
        public TemporaryCourseStudentsComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(); 
        }
        //=============================================
        public IQueryable<CourseMeetingStudentsModel> Read(bool isActive)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && c.IsTemporaryRegistration && c.Course.IsActive == isActive,c=> c.ModUser, c => c.Course.TeacherUser, c => c.CourseMeeting.TeacherUser, c=>c.StudentUsers);
            return result; 
        }  
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
