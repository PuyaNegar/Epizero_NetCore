using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Extentions;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseStudentsService : IDisposable
    {
        private CourseStudentsComponent courseStudentsComponent;
        //========================================================================== 
        public CourseStudentsService()
        {
            courseStudentsComponent = new CourseStudentsComponent();
        }
        //========================================================================== 
        public SysResult Read(int CourseId)
        {
            var result = courseStudentsComponent.Read(CourseId).Select(c => new CourseStudentsViewModel()
            {
                Id = c.Id,
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
                FieldName = c.StudentUsers.StudentUserProfile.Field.Name,
                UserName = c.StudentUsers.UserName,
                StudentUserId = c.StudentUserId,
                IsOnlineRegistratedName = c.IsOnlineRegistrated ? "آنلاین" : "حضوری",
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                IsTemporaryRegistrationName = c.IsTemporaryRegistration ? "موقت" : "ثبت نام شده",
                PaidAmount = c.IsTemporaryRegistration ? 0 : c.Price + c.SalePartnerPrice,
                DiscountAmount = c.DiscountAmount,
                IsActive = c.IsActive,
                IsActiveName = c.IsActive ? "فعال" : "انصرافی"

            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //==========================================================================
        public SysResult Add(CourseStudentsViewModel request, int currentUserId)
        {

            if (string.IsNullOrEmpty(request.StudentUserIds))
                throw new CustomException("لیست دانشجویان نباید خالی ارسال شود ");
            var models = new List<CourseMeetingStudentsModel>();
            foreach (var StudentUserId in request.StudentUserIds.Split(',').Select(Int32.Parse).ToList())
            {
                models.Add(new CourseMeetingStudentsModel()
                {
                    StudentUserId = StudentUserId,
                    IsActive = true,
                    IsTemporaryRegistration = true,
                    IsOnlineRegistrated = false,
                    CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.Course,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    CourseMeetingId = null,
                    CourseId = request.CourseId
                });
            }
            courseStudentsComponent.Add(request.CourseId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //==========================================================================
        public SysResult AddStudentCourse(ListCourseStudentsViewModel request, int currentUserId)
        {
            if (request.StudentUserIds.Count() == 0)
                throw new CustomException("لیست دانشجویان نباید خالی ارسال شود ");
            var models = new List<CourseMeetingStudentsModel>();
            foreach (var StudentUserId in request.StudentUserIds)
            {
                models.Add(new CourseMeetingStudentsModel()
                {
                    StudentUserId = StudentUserId,
                    IsActive = true,
                    IsTemporaryRegistration = true,
                    IsOnlineRegistrated = false,
                    CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.Course,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    CourseMeetingId = null,
                    CourseId = request.CourseId
                });
            }
            courseStudentsComponent.Add(request.CourseId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //========================================================================== 
        public SysResult Delete(IntegerIdentifierViewModel viewModel, int currentUserId)
        {
            courseStudentsComponent.Delete(viewModel.Id.Value, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================== 
        public SysResult SendSms(CourseMeetingStudentType courseMeetingStudentType, StudentCustomSmsViewModel viewModel)
        {
            CourseStudentCustomSmsComponent.Operation(courseMeetingStudentType, viewModel.CourseId, viewModel.Message);
            return new SysResult() { IsSuccess = true, Message = "پیامک ها با موفقیت به دانش آموزان دوره ارسال گردید" };
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
            courseStudentsComponent?.Dispose();
        }
        #endregion
    }
}
