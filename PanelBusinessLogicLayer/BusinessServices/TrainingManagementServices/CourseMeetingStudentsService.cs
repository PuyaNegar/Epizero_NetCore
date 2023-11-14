using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseMeetingStudentsService : IDisposable
    {
        private CourseMeetingStudentsComponent courseMeetingStudentsComponent;
        //========================================================================== 
        public CourseMeetingStudentsService()
        {
            courseMeetingStudentsComponent = new CourseMeetingStudentsComponent();
        }
        //========================================================================== 
        public SysResult Read(int CourseMeetingId)
        {
            var result = courseMeetingStudentsComponent.Read(CourseMeetingId).Select(c => new CourseMeetingStudentsViewModel()
            {
                Id = c.Id,
                CourseName = c.Course.Name,
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
                CourseMeetingName = c.CourseMeeting.Name,
                StudentUserId = c.StudentUserId,
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                StudentUserName = c.StudentUsers.UserName,
                IsOnlineRegistratedName = c.IsOnlineRegistrated ? "آنلاین" : "حضوری",
                IsTemporaryRegistrationName = c.IsTemporaryRegistration ? "موقت" : "ثبت نام شده",
                PaidAmount = c.IsTemporaryRegistration ? 0 : c.Price + c.SalePartnerPrice,
                DiscountAmount = c.DiscountAmount,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //==========================================================================
        public SysResult Add(CourseMeetingStudentsViewModel request, int currentUserId)
        {
            var courseId = GetCourseId(request.CourseMeetingId);
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
                    CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.CourseMeeting,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    CourseMeetingId = request.CourseMeetingId,
                    CourseId = courseId
                });
            }
            courseMeetingStudentsComponent.Add(request.CourseMeetingId, models);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //==========================================================================
        public SysResult AddStudentCourseMeeting(ListCourseMeetingStudentsViewModel request, int currentUserId)
        {
            var courseId = GetCourseId(request.CourseMeetingId);
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
                    CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.CourseMeeting,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    ModDateTime = DateTime.UtcNow,
                    CourseMeetingId = request.CourseMeetingId,
                    CourseId = courseId
                });
            }
            courseMeetingStudentsComponent.Add(request.CourseMeetingId, models );
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //========================================================================== 

        public SysResult<List<ComboBoxItems>> ReadCourseMeetigWithStudentId(int studentId)
        {
            var result = courseMeetingStudentsComponent.ReadByStudentId(studentId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                IsActive = c.IsActive,
                Value = c.Id.ToString(),
                Text = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.Course.Name : c.CourseMeeting.Name + " (" + c.CourseMeeting.Course.Name + ") "
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================== 
        public SysResult Delete(IntegerIdentifierViewModel viewModel, int currentUserId)
        {
            courseMeetingStudentsComponent.Delete(viewModel.Id.Value, currentUserId);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //============================================================
        private int GetCourseId(int CourseMeetingId)
        {
            using (var courseMettingComponent = new CourseMeetingsComponent())
            {
                var CourseMeetingsModel = courseMettingComponent.Find(CourseMeetingId);
                if (CourseMeetingsModel != null)
                    return CourseMeetingsModel.Course.Id;
                else
                    throw new CustomException("دوره ایی برای جلسه ثبت نشده است.");
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
            courseMeetingStudentsComponent?.Dispose();
        }
        #endregion
    }
}
