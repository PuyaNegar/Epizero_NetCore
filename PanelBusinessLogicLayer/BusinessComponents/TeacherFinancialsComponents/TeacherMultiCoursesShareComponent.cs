using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using PanelViewModels.TeacherFinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents
{
    public class TeacherMultiCoursesShareComponent : IDisposable
    {
        private Repository<CourseMultiTeacherSharesModel> courseMultiTeacherSharesRepository;
        private CalculateCourseMultiTeacherSharesComponent calculateCourseMultiTeacherSharesComponent;
        //==================================================
        public TeacherMultiCoursesShareComponent()
        {
            courseMultiTeacherSharesRepository = new Repository<CourseMultiTeacherSharesModel>();
            calculateCourseMultiTeacherSharesComponent = new CalculateCourseMultiTeacherSharesComponent();
        }
        //==================================================
        public TeacherMultiCoursesShareViewModel Calculate(int teacherUserId)
        {
            var courseIds = courseMultiTeacherSharesRepository.Where(c => c.TeacherUserId == teacherUserId && c.Course.IsMultiTeacher).Select(c => c.CourseId).ToList();
            var models = new List<CalculateCourseMultiTeacherSharesViewModel>();
            foreach (var courseId in courseIds)
                models.Add(calculateCourseMultiTeacherSharesComponent.Calculate(courseId));
            
            var viewModel = new TeacherMultiCoursesShareViewModel() { MeetingMultiTeacherShares = new List<MeetingMultiTeacherSharesViewModel>() , PercentageMultiTeacherShares = new List<PercentageMultiTeacherSharesViewModel>() };
            
            foreach (var model in models)
            { 
                var meetingMultiTeacherShres = model.MeetingMultiTeacherShres.Where(c => c.TeacherUserId == teacherUserId).ToList();
                if (meetingMultiTeacherShres.Any())
                    viewModel.MeetingMultiTeacherShares.AddRange(meetingMultiTeacherShres);
 
                var percentageMultiTeacherShares = model.PercentageMultiTeacherShares.Where(c => c.TeacherUserId == teacherUserId).ToList();
                if (percentageMultiTeacherShares.Any())
                    viewModel.PercentageMultiTeacherShares.AddRange(percentageMultiTeacherShares); 
            }
            viewModel.TotalMeetingShare = viewModel.MeetingMultiTeacherShares.Sum(c => c.TotalAmount);
            viewModel.TotalPercentageShare = viewModel.PercentageMultiTeacherShares.Sum(c =>c.CalculatedAmount);
            viewModel.TotalShare = viewModel.TotalMeetingShare + viewModel.TotalPercentageShare;

            return viewModel;
        }
        //==================================================
        public void Dispose()
        {
            courseMultiTeacherSharesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
