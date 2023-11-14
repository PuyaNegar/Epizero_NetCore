using Common.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.ContentManagement;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class ContentsServices : IDisposable
    {
        //===================================================
        public SysResult<ContentsViewModel> Read()
        {
            var sliderTask = ReadSliders();
           // var rssTask = ReadRss();
            var coursePromoSections = ReadCoursePromoSections();
            var onlineExamPromoSections = ReadOnlineExamPromoSections();
            var suggestionTeachers = ReadSuggestionTeachers();
            var homePageNotificationTask = ReadHomePageNotification();
            var countStudentTask = GetCountStudent();
            var countOnlineExamsTask = GetCountOnlineExams();
            var countOnlineClassesTask = GetCountOnlineClasses();
            Task.WaitAll(sliderTask, coursePromoSections, onlineExamPromoSections , homePageNotificationTask );
            var viewModel = new ContentsViewModel()
            {
               // Rss = rssTask.Result,
                Sliders = sliderTask.Result,
                CoursePromoSections = coursePromoSections.Result,
                OnlineExamPromoSections = onlineExamPromoSections.Result,
                SuggestionTeachers = suggestionTeachers.Result,
                NumberOfStudent = countStudentTask.Result,
                NumberOfOnlineExams = countOnlineExamsTask.Result,
                NumberOfOnlineClasses = countOnlineClassesTask.Result,
                HomePageNotification = homePageNotificationTask.Result
                  
            };
            return new SysResult<ContentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }

        //===================================================
        private Task<HomePageNotificationsViewModel> ReadHomePageNotification()
        {
            var task = new Task<HomePageNotificationsViewModel>(() =>
            {
                using (var homePageNotificationComponent = new HomePageNotificationsComponent())
                {
                    var result = homePageNotificationComponent.Read();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<List<SlidersViewModel>> ReadSliders()
        {
            var task = new Task<List<SlidersViewModel>>(() =>
            {
                using (var slidersComponent = new SlidersComponent())
                {
                    var result = slidersComponent.Read();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<List<RssViewModel>> ReadRss()
        {
            var task = new Task<List<RssViewModel>>(() =>
            {
                using (var slidersComponent = new BlogsComponent())
                {
                    var result = slidersComponent.ReadRss();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<List<CoursePromoSectionsViewModel>> ReadCoursePromoSections()
        {
            var task = new Task<List<CoursePromoSectionsViewModel>>(() =>
            {
                using (var coursePromoSectionsComponent = new CoursePromoSectionsComponent())
                {
                    var result = coursePromoSectionsComponent.Read();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<List<OnlineExamPromoSectionsViewModel>> ReadOnlineExamPromoSections()
        {
            var task = new Task<List<OnlineExamPromoSectionsViewModel>>(() =>
            {
                using (var onlineExamPromoSectionsComponent = new OnlineExamPromoSectionsComponent())
                {
                    var result = onlineExamPromoSectionsComponent.Read();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<int> GetCountStudent()
        {
            var task = new Task<int>(() =>
            {
                using (var usersService = new UsersService())
                {
                    var result = usersService.GetCountStudent();
                    return result.Value;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<int> GetCountOnlineExams()
        {
            var task = new Task<int>(() =>
            {
                using (var onlineExamsService = new OnlineExamsComponent())
                {
                    var result = onlineExamsService.GetCountOnlineExams();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<int> GetCountOnlineClasses()
        {
            var task = new Task<int>(() =>
            {
                using (var onlineExamsService = new OnlineClassesComponent())
                {
                    var result = onlineExamsService.GetCountOnlineClasses();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=========================================================== 
        private Task<List<SuggestionTeachersViewModel>> ReadSuggestionTeachers()
        {
            var task = new Task<List<SuggestionTeachersViewModel>>(() =>
            {
                using (var suggestionTeachersComponent = new SuggestionTeachersComponent())
                {
                    var result = suggestionTeachersComponent.Read();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=========================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        //============================================================
    }
}
