using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.ContentsViewModels;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CoursesService : IDisposable
    {
        private CoursesComponent coursesComponent;
        public CoursesService()
        {
            coursesComponent = new CoursesComponent();
        }
        //=============================================================================
        public SysResult<CoursesViewModel> Read(int courseId, int? studentUserId)
        {
            var viewModel = coursesComponent.Read(courseId, studentUserId);
            return new SysResult<CoursesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=============================================================================
        public SysResult ReadByCourseCategoryType(CourseCategoryType? courseCategoryType)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var result = coursesComponent.ReadByCousreType(courseCategoryType).Select(course => new CoursesViewModel()
            {
                Id = course.Id,
                Audience = course.Audience,
                CourseMeetingCount = course.CourseMeetingCount,
                CourseCategoryType = (CourseCategoryType)course.CourseCategoryTypeId,
                MetaDescription = course.MetaDescription,
                LogoPicPath = string.IsNullOrEmpty(course.LogoPicPath) ? string.Empty : CdnUrl + course.LogoPicPath,
                BannerPicPath = string.IsNullOrEmpty(course.BannerPicPath) ? string.Empty : CdnUrl + course.BannerPicPath,
                CourseDuration = course.CourseDuration,
                CourseTypeId = course.CourseTypeId,
                CourseTypeName = course.CourseTypes.Name,
                Name = course.Name,
                IsShowDetailsInWeb = course.IsShowDetailsInWeb,
                IsMultiTeacher = course.IsMultiTeacher,
                IsVisibleOnSite = course.IsVisibleOnSite,
                TeacherPicPath = string.IsNullOrEmpty(course.TeacherUser.PersonalPicPath) ? string.Empty : CdnUrl + course.TeacherUser.PersonalPicPath,
                Price = course.Price,
                Description = course.Description,
                DiscountPercent = course.DiscountPercent,
                DiscountPrice = Convert.ToInt32( course.Price - (course.Price * course.DiscountPercent / 100)),
                StartDate = course.StartDate == null ? "ثبت نشده" : course.StartDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                TeacherUserId = course.TeacherUser.Id,
                TeacherFullName = course.TeacherUser.FirstName + " " + course.TeacherUser.LastName,
                LessonName = course.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? "ثبت نشده" : course.Lessons.Name,
                LanguageName = course.Languages.Name,
                LevelName = course.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? "ثبت نشده" : course.Lessons.Level.Name,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            coursesComponent?.Dispose();
        }
        #endregion
    }
}
