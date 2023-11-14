using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents;
using PanelViewModels.TeacherFinancialsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices
{
    public class TeacherCourseStudentFinancialsService : IDisposable
    {
        private TeacherCourseStudentFinancialsComponent courseStudentFinancialsComponent;
        //===============================================================================
        public TeacherCourseStudentFinancialsService()
        {
            courseStudentFinancialsComponent = new TeacherCourseStudentFinancialsComponent();
        }
        //===============================================================================
        public SysResult<TeacherCourseStudentFinancialsSummeryViewModel> Read(int courseId,int teacherUserId )
        {
            var result = courseStudentFinancialsComponent.Read(courseId , teacherUserId).Select(c => new TeacherCourseStudentFinancialsViewModel()
            {
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                CityName = c.StudentUsers.StudentUserProfile.City == null ? "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                CourseName = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.Course.Name : c.CourseMeeting.Name + " (" + c.CourseMeeting.Course.Name + ") ",
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
                IsTemporaryRegistration = c.IsTemporaryRegistration,
                Price = c.IsTemporaryRegistration ? 0 : c.Price,
                DiscountAmount = c.IsTemporaryRegistration ? 0 : c.DiscountAmount,
                DebtAmount = c.IsTemporaryRegistration ? 0 : c.Price + c.SalePartnerPrice,
                TotalAmount = c.IsTemporaryRegistration ? 0 : c.Price + c.SalePartnerPrice + c.DiscountAmount,
                SalePartnerPrice = c.IsTemporaryRegistration ? 0 : c.SalePartnerPrice,
                 DiscountCode = c.IsOnlineRegistrated ?( c.Order.DiscountCode == null ? string.Empty : c.Order.DiscountCode.Code) : string.Empty ,
                DiscountCodeDescription = c.IsOnlineRegistrated ? (c.Order.DiscountCode == null ? string.Empty : c.Order.DiscountCode.Description) : string.Empty,


            }).ToList(); 
            var model = new TeacherCourseStudentFinancialsSummeryViewModel()
            {
                CourseStudentFinancials = result,
                SumOfPrice = result.Sum(c => c.Price),
                SumOfDebtAmount = result.Sum(c => c.DebtAmount),
                SumOfDiscountAmount = result.Sum(c => c.DiscountAmount),
                SumOfSalePartnerPrice = result.Sum(c => c.SalePartnerPrice),
                SumOfTotalAmount = result.Sum(c => c.TotalAmount),
            };
            return new SysResult<TeacherCourseStudentFinancialsSummeryViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentFinancialsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
