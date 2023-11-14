using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialDebtsComponent : IDisposable
    {
        private Repository<StudentFinancialDebtsModel> studentFinancialDebtsRepository;
        //===============================================
        public StudentFinancialDebtsComponent(MainDBContext mainDBContext)
        {
            studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(mainDBContext);
        }
        //===============================================
        public List<StudentFinancialDebtsViewModel> Read(int StudentUserId)
        {
            var result = studentFinancialDebtsRepository.Where(c => c.CourseMeetingStudent.StudentUserId == StudentUserId, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting.Course  )
                .Select(c => new StudentFinancialDebtsViewModel()
                {
                    Id = c.Id,
                    IsCanceled = c.IsCanceled,
                    CourseName = c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
                    CourseMeetingStudentType = c.CourseMeetingStudent.CourseMeetingStudentType.Name,
                    DebtAmount = c.CourseMeetingStudent.Price + c.CourseMeetingStudent.SalePartnerPrice,
                    TotalAmount = c.CourseMeetingStudent.Price + c.CourseMeetingStudent.SalePartnerPrice + c.CourseMeetingStudent.DiscountAmount,
                    StudentUserFullName = c.CourseMeetingStudent.StudentUsers.FirstName + " " + c.CourseMeetingStudent.StudentUsers.LastName,
                    DiscountAmount = c.CourseMeetingStudent.DiscountAmount,
                }).ToList(); ;
            return result; 
        } 
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialDebtsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
