using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataAccessLayer.StoredProcedures;
using DataModels.FinancialsModels;
using DataModels.TrainingManagementModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class CalculateCourseMultiTeacherSharesComponent : IDisposable
    {
        private Repository<CourseMultiTeacherSharesModel> courseMultiTeacherSharesRepository;
        //===============================================
        public CalculateCourseMultiTeacherSharesComponent()
        {
            courseMultiTeacherSharesRepository = new Repository<CourseMultiTeacherSharesModel>();
        }
        //===============================================
        public CalculateCourseMultiTeacherSharesViewModel Calculate(int courseId)
        {
            var teacherUserId = GetCourseTeacherUserId(courseId);
            TeacherPaymentMethodUpdaterProcedure.Execute(teacherUserId, courseId);
            var courseMultiTeacherShares = courseMultiTeacherSharesRepository.Where(c => c.CourseId == courseId, c => c.Course, c => c.TeacherUser).ToList();
            var courseTotalShare = GetTeacherPaymentMethod(teacherUserId, courseId);
            var meetingMultiTeacherShare = GetMeetingMultiTeacherShare(courseId, courseMultiTeacherShares);
            var courseRemainingShare = courseTotalShare - meetingMultiTeacherShare.Sum(c => c.TotalAmount);
            var percentageMultiTeacherShares = GetPercentageMultiTeacherShares(courseRemainingShare, courseMultiTeacherShares);
            return new CalculateCourseMultiTeacherSharesViewModel()
            {
                CourseRemainingShare = courseRemainingShare - percentageMultiTeacherShares.Sum(c => c.CalculatedAmount),
                CourseTotalShare = courseTotalShare,
                MeetingMultiTeacherShres = meetingMultiTeacherShare,
                PercentageMultiTeacherShares = percentageMultiTeacherShares,
                TotalMeetingsShare = meetingMultiTeacherShare.Sum(c => c.TotalAmount),
                TotalPercentageShare = percentageMultiTeacherShares.Sum(c => c.CalculatedAmount),
            };
        }
        //===============================================
        long GetTeacherPaymentMethod(int teacherUserId, int courseId)
        {
            try
            {
                using (var teacherPaymentMethodsRepository = new Repository<TeacherPaymentMethodsModel>())
                {
                    var result = teacherPaymentMethodsRepository.SingleOrDefault(c => c.CourseId == courseId && c.TeacherUserId == teacherUserId);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    return result.TotalDebtAmount;
                }
            }
            catch (Exception)
            {
                throw new CustomException("نحوه پرداخت به معلم برای این دوره ثبت نشده است");
            }

        }
        //================================================================
        List<PercentageMultiTeacherSharesViewModel> GetPercentageMultiTeacherShares(long courseRemainingShare, List<CourseMultiTeacherSharesModel> courseMultiTeacherShares)
        {

            var result = courseMultiTeacherShares.Where(c => c.CourseMultiTeacherShareTypeId == (int)CourseMultiTeacherShareType.Percent).ToList();
            if (!result.Any())
                return new List<PercentageMultiTeacherSharesViewModel>();
            var meetingMultiTeacherShares = new List<PercentageMultiTeacherSharesViewModel>();
            var viewModel = result.Select(c => new PercentageMultiTeacherSharesViewModel()
            {
                Id = c.Id,
                CourseOrExamName = c.Course.Name,
                Percent = c.AmountOrPercent,
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                TeacherUserId = c.TeacherUserId,
                CalculatedAmount = c.AmountOrPercent * courseRemainingShare / 100,
            }).ToList();

            return viewModel;
        }
        //================================================================
        List<MeetingMultiTeacherSharesViewModel> GetMeetingMultiTeacherShare(int courseId, List<CourseMultiTeacherSharesModel> courseMultiTeacherShares)
        {
            using (var courseMeetingDedicatedTeachersRepository = new Repository<CourseMeetingDedicatedTeachersModel>())
            {
                var result = courseMultiTeacherShares.Where(c => c.CourseMultiTeacherShareTypeId == (int)CourseMultiTeacherShareType.ForEachMeeting ).ToList();
                if (!result.Any())
                    return new List<MeetingMultiTeacherSharesViewModel>();
                var meetingMultiTeacherShares = new List<MeetingMultiTeacherSharesViewModel>();
                var courseMeetingDedicatedTeachers = courseMeetingDedicatedTeachersRepository.Where(c => c.CourseMeeting.CourseId == courseId  ).GroupBy(c => c.TeacherUserId).Select(c => new { TeacherUserId = c.Key, Count = c.Count() }).ToList();
                foreach (var courseMultiTeacherShare in result )
                {
                    var courseMeetingDedicatedTeacher = courseMeetingDedicatedTeachers.SingleOrDefault(c => c.TeacherUserId == courseMultiTeacherShare.TeacherUserId );
                    var viewModel = new MeetingMultiTeacherSharesViewModel()
                    {
                        Id = courseMultiTeacherShare.Id,
                        CourseOrExamName  = courseMultiTeacherShare.Course.Name,
                        Amount = courseMultiTeacherShare.AmountOrPercent,
                        TeacherFullName = courseMultiTeacherShare.TeacherUser.FirstName + " " + courseMultiTeacherShare.TeacherUser.LastName,
                        TeacherUserId = courseMultiTeacherShare.TeacherUserId,
                        CourseMeetingsCount = courseMeetingDedicatedTeacher == null ? 0 :  courseMeetingDedicatedTeacher.Count,
                    };
                    viewModel.TotalAmount = viewModel.Amount * viewModel.CourseMeetingsCount;
                    meetingMultiTeacherShares.Add(viewModel);
                }
                return meetingMultiTeacherShares;
            }
        }
        //===============================================
        int GetCourseTeacherUserId(int courseId)
        {
            using (var courseRepository = new Repository<CoursesModel>())
            {
                var result = courseRepository.SingleOrDefault(c => c.Id == courseId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.TeacherUserId;
            }
        }
        //===============================================
        public void Dispose()
        {
            courseMultiTeacherSharesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        //===============================================
    }
}
