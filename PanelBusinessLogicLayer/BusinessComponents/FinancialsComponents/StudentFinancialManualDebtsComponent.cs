using Common.Enums;
using Common.Extentions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
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
        public void Add(StudentFinancialManualDebtsModel model)
        {
            studentFinancialManualDebtsRepository.Add(model);
            studentFinancialManualDebtsRepository.SaveChanges();
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
                    UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
                    CourseMeetingStudentId = c.CourseMeetingStudentId,
                    CourseName = c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
                    CourseMeetingStudentType = c.CourseMeetingStudent.CourseMeetingStudentType.Name,
                }).ToList();
            return result;
        }
        //=======================================================
        public void Delete(StudentFinancialManualDebtsModel model)
        {
            studentFinancialManualDebtsRepository.Delete(model);
            studentFinancialManualDebtsRepository.SaveChanges();
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
