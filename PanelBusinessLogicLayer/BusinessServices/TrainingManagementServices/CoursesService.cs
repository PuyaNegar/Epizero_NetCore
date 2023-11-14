using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CoursesService : IDisposable
    {
        private CoursesComponent courseComponent;
        //===============================================================================
        public CoursesService()
        {
            courseComponent = new CoursesComponent();
        }
        //===============================================================================
        public SysResult Add(CoursesViewModel request, int currentUserId, CourseCategoryType courseCategoryType)
        {
            request.CourseFAQIds = request.CourseFAQIds ?? new List<string>();
            request.CommentOldStudentCoursesIds = request.CommentOldStudentCoursesIds ?? new List<string>();
            float discountPercent;
            int discountAmount;
            CalculateDiscountParameter(request, out discountPercent, out discountAmount);

            var model = new CoursesModel()
            {
                CourseMeetingCount = request.CourseMeetingCount,
                Audience = request.Audience,
                Name = request.Name,
                Inx = request.Inx.Value,
                Description = request.Description,
                DiscountAmount = discountAmount,
                DiscountPercent = discountPercent,
                BannerPicPath = request.BannerPicPath,
                LogoPicPath = request.LogoPicPath,
                Price = request.Price,
                IsVisibleOnSite = request.IsVisibleOnSite.ToBoolean(),
                IsMultiTeacher = request.IsMultiTeacher.ToBoolean(),
                IsShowDetailsInWeb = request.IsShowDetailsInWeb.ToBoolean(),
                CourseDuration = request.CourseDuration,
                StartDate = string.IsNullOrEmpty(request.StartDate) ? (DateTime?)null : request.StartDate.ToDate().ToUtcDateTime(),
                EndDate = string.IsNullOrEmpty(request.EndDate) ? (DateTime?)null : request.EndDate.ToDate().ToUtcDateTime(),
                CourseTypeId = request.CourseTypeId,
                TeacherUserId = request.TeacherUserId,
                LessonId = courseCategoryType == CourseCategoryType.OnlineExam ? (int?)null : request.LessonId,
                LanguageId = request.LanguageId,
                IsActive = request.IsActive.ToBoolean(),
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                MetaDescription = request.MetaDescription,
                CourseCategoryTypeId = (int)courseCategoryType
            };
            //**********************************************
            var courseFAQsModel = request.CourseFAQIds.Select(item => new CourseFAQsModel
            {
                CourseId = model.Id,
                FAQId = Convert.ToInt32(item),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                Inx = 1
            }).ToList();
            var commentOldStudentCoursesModel = request.CommentOldStudentCoursesIds.Select(item => new CommentOldStudentCoursesModel
            {
                CourseId = model.Id,
                OldStudentCommentId = Convert.ToInt32(item),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                Inx = 1
            }).ToList();
            model.CommentOldStudentCourses = commentOldStudentCoursesModel;
            model.CourseFAQs = courseFAQsModel;
            courseComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

      

        //===============================================================================
        public SysResult Read(bool? IsActive, CourseCategoryType? courseCategoryType, bool selectOnlyMultiTeacherCourse)
        {
            var result = courseComponent.Read(IsActive, courseCategoryType, selectOnlyMultiTeacherCourse).Select(c => new CoursesViewModel()
            {
                Id = c.Id,
                Inx = c.Inx,
                Name = c.Name,
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                CourseTypeName = c.CourseTypes.Name,
                TeacherUserId = c.TeacherUserId,
                CourseCategoryTypeName = c.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? "آزمون" : "دوره",
                LessonName = courseCategoryType == CourseCategoryType.OnlineExam ? "ثبت نشده" : c.Lessons.Name,
                Price = c.Price,
                
                IsVisibleOnSiteName = c.IsVisibleOnSite ? "بلی" : "خیر",
                DiscountType = c.DiscountAmount == 0  ? "درصدی" : "مبلغی",
                DiscountPercentOrDiscountAmount = c.DiscountAmount == 0 ?  c.DiscountPercent    :  c.DiscountAmount  ,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                IsMultiTeacherName = c.IsMultiTeacher ? "بلی" : "خیر",
                IsMultiTeacher = c.IsMultiTeacher.ToActiveStatus(),
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            }).OrderByDescending(c => c.Inx);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(CoursesViewModel request, int currentUserId, CourseCategoryType courseCategoryType)
        {
            float discountPercent;
            int discountAmount;
            request.CourseFAQIds = request.CourseFAQIds ?? new List<string>();
            request.CommentOldStudentCoursesIds = request.CommentOldStudentCoursesIds ?? new List<string>();
            CalculateDiscountParameter(request, out discountPercent, out discountAmount);

            var model = new CoursesModel()
            {
                CourseMeetingCount = request.CourseMeetingCount,
                Audience = request.Audience,
                Id = request.Id,
                Name = request.Name,
                Inx = request.Inx.Value,
                IsShowDetailsInWeb = request.IsShowDetailsInWeb.ToBoolean(),
                Description = request.Description,
                BannerPicPath = request.BannerPicPath,
                LogoPicPath = request.LogoPicPath,
                Price = request.Price,
                DiscountAmount = discountAmount,
                DiscountPercent = discountPercent,
                CourseDuration = request.CourseDuration,
                IsVisibleOnSite = request.IsVisibleOnSite.ToBoolean(),
                StartDate = string.IsNullOrEmpty(request.StartDate) ? (DateTime?)null : request.StartDate.ToDate().ToUtcDateTime(),
                EndDate = string.IsNullOrEmpty(request.EndDate) ? (DateTime?)null : request.EndDate.ToDate().ToUtcDateTime(),
                CourseTypeId = request.CourseTypeId,
                TeacherUserId = request.TeacherUserId,
                LanguageId = request.LanguageId,
                LessonId = courseCategoryType == CourseCategoryType.OnlineExam ? (int?)null : request.LessonId,
                IsActive = request.IsActive.ToBoolean(),
                IsMultiTeacher = request.IsMultiTeacher.ToBoolean(),
                MetaDescription = request.MetaDescription
            };
            var courseFAQModel = request.CourseFAQIds.Select(item => new CourseFAQsModel
            {
                CourseId = model.Id,
                FAQId = Convert.ToInt32(item),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                Inx = 1
            }).ToList();

            var commentOldStudentCoursesModel = request.CommentOldStudentCoursesIds.Select(item => new CommentOldStudentCoursesModel
            {
                CourseId = model.Id,
                OldStudentCommentId = Convert.ToInt32(item),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                Inx = 1
            }).ToList();
            model.CommentOldStudentCourses = commentOldStudentCoursesModel;
            model.CourseFAQs = courseFAQModel;

            courseComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult<CoursesViewModel> Find(int id)
        {

            var result = courseComponent.Find(id);
            var _CourseFAQIds = result.CourseFAQs.Select(c => c.FAQId.ToString()).ToList<string>();
            var _CommentOldStudentCourseIds = result.CommentOldStudentCourses.Select(c => c.OldStudentCommentId.ToString()).ToList<string>();

            var model = new CoursesViewModel()
            {
                CourseMeetingCount = result.CourseMeetingCount, 
                Audience = result.Audience,
                CourseFAQIds = _CourseFAQIds,
                CommentOldStudentCoursesIds = _CommentOldStudentCourseIds,
                Id = result.Id,
                Name = result.Name,
                Inx = result.Inx,
                LessonName = result.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? string.Empty : result.Lessons.Level.LevelGroup.Name + " _ " + result.Lessons.Level.Name + " _ " + result.Lessons.Name,
                LessonId = result.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? 0 : result.LessonId.Value,
                Description = result.Description,
                LanguageId = result.LanguageId,
                BannerPicPath = result.BannerPicPath,
                IsVisibleOnSite = result.IsVisibleOnSite.ToActiveStatus(),
                IsShowDetailsInWeb = result.IsShowDetailsInWeb.ToActiveStatus(),
                LogoPicPath = result.LogoPicPath,
                Price = result.Price,
                DiscountPercentOrDiscountAmount = result.DiscountAmount == 0 ? result.DiscountPercent : result.DiscountAmount,
                DiscountTypeId = result.DiscountAmount == 0 ? (int)DiscountType.Percent : (int)DiscountType.Amount,
                CourseDuration = result.CourseDuration,
                CourseTypeId = result.CourseTypeId,
                TeacherUserId = result.TeacherUserId,
                MetaDescription = result.MetaDescription,
                IsActive = result.IsActive.ToActiveStatus(),
                IsMultiTeacher = result.IsMultiTeacher.ToActiveStatus(),
                StartDate = result.StartDate == null ? string.Empty : result.StartDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                EndDate = result.EndDate == null ? string.Empty : result.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(),
            };
            return new SysResult<CoursesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult<CoursesViewModel> FindDescription(int Id)
        {
            var result = courseComponent.FindDescription(Id);
            var viewModel = new CoursesViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description
            };
            return new SysResult<CoursesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================================
        public SysResult UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            courseComponent.UpdateDescription(Id, Description.CharacterAnalysis(), CurrentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new CoursesModel()
            {
                Id = a.Id.Value,
            }).ToList();
            courseComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = courseComponent.ReadForComboBox();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name + " ( " + " استاد " + c.TeacherUser.FirstName + " " + c.TeacherUser.LastName + " ) ",
                Value = c.Id.ToString(),
                Data = string.Format("{0:N0}", (c.Price - (c.Price * c.DiscountPercent / 100)))
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
        }
        //===============================================================================
        void CalculateDiscountParameter(CoursesViewModel request, out float discountPercent, out int discountAmount)
        {
            discountPercent = 0;
            discountAmount = 0;
            if (request.DiscountTypeId == (int)DiscountType.Amount)
            {
                discountPercent = 100 * request.DiscountPercentOrDiscountAmount / request.Price;
                if (discountPercent > 100)
                    throw new Exception("مبلغ تخفیف نبایستی بیشتر از مبلغ اصلی باشد");
                discountAmount = Convert.ToInt32(request.DiscountPercentOrDiscountAmount);
            }
            else
            {
                if (request.DiscountPercentOrDiscountAmount < 0 || request.DiscountPercentOrDiscountAmount > 100)
                    throw new Exception("درصد تخفیف بایستی عددی بین 0 تا 100 باشد");
                discountPercent = request.DiscountPercentOrDiscountAmount;
            }
        }
        //=============================================================================== Disposing
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
            courseComponent?.Dispose();
        }
        #endregion
    }
}
