using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
   public class StudentPaymentLinksComponent : IDisposable
    {
        private Repository<StudentPaymentLinksModel> studentPaymentLinksRepository;
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
         //===============================================
        public StudentPaymentLinksComponent()
        {
            studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>();
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
        }
        //================================================

        public IQueryable<StudentPaymentLinksModel> Read(int studentUserId) 
        { 
            var result = studentPaymentLinksRepository.Where(c => c.CourseMeetingStudent.StudentUserId == studentUserId && !c.IsPaid, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting, c => c.CourseMeetingStudent.StudentUsers);
            return result;
        }

        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentPaymentLinksRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
