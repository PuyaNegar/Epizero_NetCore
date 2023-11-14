using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseMeetingSectionsService : IDisposable
    {
        //================================================ 
        public SysResult<CourseMeetingSectionsViewModel> Read(int studentUserId, int courseMeetingId)
        {
            var courseMeetingBookletsTask = GetCourseMeetingBookletsTask(studentUserId, courseMeetingId);
            var courseMeetingVideosTask = GetCourseMeetingVideosTask(studentUserId, courseMeetingId);
            var homeworkTask = GetHomeworkTask(studentUserId, courseMeetingId);
            var userTask = GetUsersTask(studentUserId); 
            Task.WaitAll(courseMeetingBookletsTask, courseMeetingVideosTask, homeworkTask , userTask);
            var model = new CourseMeetingSectionsViewModel()
            {
                CourseMeetingBooklets = courseMeetingBookletsTask.Result,
                CourseMeetingVideos = courseMeetingVideosTask.Result,
                Homeworks = homeworkTask.Result,
                StudentMobNo = userTask.Result.UserName , 
                StudentUserFullName = userTask.Result.FirstName +  " " + userTask.Result.LastName
            };
            return new SysResult<CourseMeetingSectionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model }; 
        }
        //================================================ 
        Task<List<CourseMeetingBookletsViewModel>> GetCourseMeetingBookletsTask(int studentUserId, int courseMeetingId)
        {
            var task = new Task<List<CourseMeetingBookletsViewModel>>(() =>
            {
                using (var courseMeetingBookletsComponent = new CourseMeetingBookletsComponent())
                {
                    var result = courseMeetingBookletsComponent.Read(studentUserId, courseMeetingId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //================================================  
        Task<List<CourseMeetingVideosViewModel>> GetCourseMeetingVideosTask(int studentUserId, int courseMeetingId)
        {
            var task = new Task<List<CourseMeetingVideosViewModel>>(() =>
            {
                using (var courseMeetingBookletsComponent = new CourseMeetingVideosComponent())
                {
                    var result = courseMeetingBookletsComponent.Read(studentUserId, courseMeetingId);
                    return result;
                }
            });
            task.Start();
            return task;
        }

        //================================================  
        Task<List<HomeworksViewModel>> GetHomeworkTask(int studentUserId, int courseMeetingId)
        {
            var task = new Task<List<HomeworksViewModel>>(() =>
            {
                using (var homeworksComponent = new HomeworksComponent())
                {
                    var result = homeworksComponent.Read(studentUserId, courseMeetingId);
                    return result;
                }
            });
            task.Start();
            return task;
        }

        //=======================================
        Task < UsersModel>  GetUsersTask(int studentUserId )
        {
            var task = new Task<UsersModel>(() =>
            {
                using (var usersComponent = new UsersComponent())
                {
                    var result = usersComponent.Find(studentUserId  );
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            // courseMeetingBookletsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
