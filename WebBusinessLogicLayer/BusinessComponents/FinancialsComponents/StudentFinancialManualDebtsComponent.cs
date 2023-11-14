using Common.Enums;
using Common.Extentions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialManualDebtsComponent : IDisposable
    {
        private Repository<StudentFinancialManualDebtsModel> studentFinancialManualDebtsRepository;
        //=======================================================
        public StudentFinancialManualDebtsComponent()
        {
            studentFinancialManualDebtsRepository = new Repository<StudentFinancialManualDebtsModel>();
        }
        
        //=======================================================
        public List<StudentFinancialManualDebtsViewModel> Read(int StudentUserId)
        {
            var result = studentFinancialManualDebtsRepository.Where(c => c.CourseMeetingStudent.StudentUserId == StudentUserId, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting.Course, c => c.ModUser)
                .Select(c => new StudentFinancialManualDebtsViewModel()
                {
                    Id = c.Id,
                    DebtAmount = c.DebtAmount,
                    Description = c.Description,
                    RegDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                    UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName,
                    CourseMeetingStudentId = c.CourseMeetingStudentId,
                    CourseName = c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
                    CourseMeetingStudentType = c.CourseMeetingStudent.CourseMeetingStudentType.Name,
                }).ToList();
            return result;
        }
        
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialManualDebtsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
