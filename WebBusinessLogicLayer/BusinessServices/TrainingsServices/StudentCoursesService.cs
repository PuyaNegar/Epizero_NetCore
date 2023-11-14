using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;
using Common.Enums;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class StudentCoursesService : IDisposable
    {
        //============================================
        public SysResult<List<StudentCoursesViewModel>> Read(int studentUserId)
        {
            var result = StudentCourseMeetingsComponent.Read(studentUserId);
            var model = result.GroupBy(c => c.CourseId).Select(c => c.First().Course).Where(c=>c.CourseCategoryTypeId == (int)CourseCategoryType.Training ).Select(c => new StudentCoursesViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                StartDateTime = c.StartDate == null ? "ثبت نشده" :  c.StartDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                EndDateTime = c.EndDate  ==  null ?  "ثبت نشده" : c.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(), 
                CourseCategoryType = (CourseCategoryType)c.CourseCategoryTypeId ,  
            }).ToList();
            return new SysResult<List<StudentCoursesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
