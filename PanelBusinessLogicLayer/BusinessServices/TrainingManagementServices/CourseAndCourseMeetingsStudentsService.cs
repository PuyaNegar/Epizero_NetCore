using Common.Enums;
using Common.Functions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseAndCourseMeetingsStudentsService : IDisposable
    {
        private CourseAndCourseMeetingsStudentsComponent courseAndCourseMeetingsStudentsComponent;
        OnlineExamsComponent onlineExamsComponent;
        //==========================================
        public CourseAndCourseMeetingsStudentsService()
        {
            courseAndCourseMeetingsStudentsComponent = new  CourseAndCourseMeetingsStudentsComponent();
            onlineExamsComponent = new OnlineExamsComponent();
        }
        //==========================================
        public SysResult<List<CourseAndCourseMeetingStudentsViewModel>> ReadCourseStudentsWithoutDuplicate(int courseId)
        {
            var result = courseAndCourseMeetingsStudentsComponent.ReadCourseStudentsWithoutDuplicate(courseId).Select(c => new CourseAndCourseMeetingStudentsViewModel()
            {
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                StudentUserId = c.StudentUserId,
                CityName = c.StudentUsers.StudentUserProfile.City == null ?  "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                GenderName = c.StudentUsers.Gender ? "مرد" : "زن",
                CourseName = c.Course.Name, 
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
            }).ToList();
            return new SysResult<List<CourseAndCourseMeetingStudentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }

        //==========================================
        public SysResult<List<CourseAndCourseMeetingStudentsViewModel>> ReadCourseMeetingStudentsWithoutDuplicate(int courseMeetingId)
        {
            var result = courseAndCourseMeetingsStudentsComponent.ReadCourseMeetingStudentsWithoutDuplicate(courseMeetingId, null).Select(c => new CourseAndCourseMeetingStudentsViewModel()
            {
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                StudentUserId = c.StudentUserId,
                CityName = c.StudentUsers.StudentUserProfile.City == null ? "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                GenderName = c.StudentUsers.Gender ? "مرد" : "زن",
                CourseName = c.Course.Name,
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
            }).ToList();
            return new SysResult<List<CourseAndCourseMeetingStudentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }


        //==========================================
        public SysResult<List<CourseAndCourseMeetingStudentsViewModel>> ReadCourseMeetingStudentsWithoutDuplicateByOnlineExamId(int onlineExamId)
        {

            var onlineExam = onlineExamsComponent.Find(onlineExamId);
            if (onlineExam.OnlineExamTypeId != (int)OnlineExamType.Independent)
                throw new CustomException("این عمیلات برای آزمون های مستقل امکانپذیر است");
            var result = courseAndCourseMeetingsStudentsComponent.ReadCourseMeetingStudentsWithoutDuplicate(onlineExam.CourseMeetingId.Value, null).Select(c => new CourseAndCourseMeetingStudentsViewModel()
            {
                StudentFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                StudentUserId = c.StudentUserId,
                CityName = c.StudentUsers.StudentUserProfile.City == null ? "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                GenderName = c.StudentUsers.Gender ? "مرد" : "زن",
                CourseName = c.Course.Name,
                CourseMeetingStudentType = c.CourseMeetingStudentType.Name,
            }).ToList();
            return new SysResult<List<CourseAndCourseMeetingStudentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseAndCourseMeetingsStudentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
