using Common.Enums;
using Common.Extentions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class StudentIndependentOnlineExamService : IDisposable
    {
        //==============================================
        public SysResult<List<StudentCoursesViewModel>> Read(int studentUserId)
        {
            var result = StudentCourseMeetingsComponent.Read(studentUserId);
            var model = result.GroupBy(c => c.CourseId).Select(c => c.First().Course).Where(c => c.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam).Select(c => new StudentCoursesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                StartDateTime = c.StartDate == null ? "ثبت نشده" : c.StartDate.Value.ToDateShortFormatString(),
                EndDateTime = c.EndDate == null ? "ثبت نشده" : c.EndDate.Value.ToDateShortFormatString(),
                CourseCategoryType = (CourseCategoryType)c.CourseCategoryTypeId,
                IsVisibleOnSite = c.IsVisibleOnSite,
            }).ToList();
            return new SysResult<List<StudentCoursesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //==============================================
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}