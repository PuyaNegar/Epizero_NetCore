using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.TrainingManagementModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialDebtsComponent : IDisposable
    {
        private Repository<StudentFinancialDebtsModel> studentFinancialDebtsRepository;
        //===============================================
        public StudentFinancialDebtsComponent()
        {
            studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>();
        }
        //=================================================
        public StudentFinancialDebtsComponent(MainDBContext mainDBContext)
        {
            studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(mainDBContext);
        }
        //===============================================
        public List<StudentFinancialDebtsViewModel> Read(int StudentUserId)
        {
            var result = studentFinancialDebtsRepository.Where(c => c.CourseMeetingStudent.StudentUserId == StudentUserId, c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.CourseMeeting.Course, c => c.ModUser)
                .Select(c => new StudentFinancialDebtsViewModel()
                {
                    Id = c.Id,
                    UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "<br>" + "(" + c.RegDateTime.ToLocalDateTimeLongFormatString() + ")",
                    IsCanceled = c.IsCanceled,
                    DiscountDiscription = c.DiscountDiscription,
                    IsOnlineRegistrated = c.CourseMeetingStudent.IsOnlineRegistrated.ToActiveStatus() , 
                    IsCanceledName  = c.IsCanceled ? "انصراف از دوره" : "عادی",
                    CourseName = c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") ",
                    CourseMeetingStudentType = c.CourseMeetingStudent.CourseMeetingStudentType.Name,
                    DebtAmount = c.CourseMeetingStudent.Price  + c.CourseMeetingStudent.SalePartnerPrice,
                    TotalAmount = c.CourseMeetingStudent.Price + c.CourseMeetingStudent.SalePartnerPrice + c.CourseMeetingStudent.DiscountAmount,
                    StudentUserFullName = c.CourseMeetingStudent.StudentUsers.FirstName + " " + c.CourseMeetingStudent.StudentUsers.LastName,
                    RegUserFullName = c.ModUser.FirstName + " " + c.ModUser.LastName,
                    DiscountAmount = c.CourseMeetingStudent.DiscountAmount,
                    Price = c.CourseMeetingStudent.Price,
                    SalePartnerPrice = c.CourseMeetingStudent.SalePartnerPrice,
                }).ToList();
            return result;
        }
        //=================================================================
        public void Delete(StudentFinancialDebtsModel model, int currentUserId)
        {
            var result = studentFinancialDebtsRepository.SingleOrDefault(c => c.Id == model.Id , c=>c.CourseMeetingStudent);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.IsCanceled = true;
            result.CourseMeetingStudent.IsActive = false;
            result.CourseMeetingStudent.IsTemporaryRegistration = true;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            studentFinancialDebtsRepository.Update(result);
            studentFinancialDebtsRepository.SaveChanges();
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
