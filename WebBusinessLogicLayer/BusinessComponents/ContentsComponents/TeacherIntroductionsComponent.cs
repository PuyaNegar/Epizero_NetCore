using Common.Enums;
using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class TeacherIntroductionsComponent : IDisposable
    {
        public TeacherIntroductionsViewModel Read(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var teacherCourseTask = GetTeacherCourseTask(teacherUserId);
            var teacherSampleVideosTask = GetTeacherSampleVideosTask(teacherUserId);
            var teacherUserTask = GetTeacherUserTask(teacherUserId);
            var teacherResumesTask = GetTeacherResumesTask(teacherUserId);
            var acceptedStudentInEntranceExamGroupsTask = GetAcceptedStudentInEntranceExamGroupsTask(teacherUserId);
            Task.WaitAll(teacherCourseTask, teacherSampleVideosTask, teacherResumesTask, teacherUserTask);
            var viewModel = new TeacherIntroductionsViewModel()
            {
                BannerPicPath = string.IsNullOrEmpty(teacherUserTask.Result.TeacherUserProfile.BannerPicPath) ? string.Empty : CdnUrl + teacherUserTask.Result.TeacherUserProfile.BannerPicPath,
                FullName = teacherUserTask.Result.FirstName + " " + teacherUserTask.Result.LastName,
                Description = teacherUserTask.Result.TeacherUserProfile.Description,
                PersonalPicPath = string.IsNullOrEmpty(teacherUserTask.Result.PersonalPicPath) ? string.Empty : CdnUrl + teacherUserTask.Result.PersonalPicPath,
                Skill = teacherUserTask.Result.TeacherUserProfile.Skill,
                MetaDescription  = teacherUserTask.Result.TeacherUserProfile.MetaDescription,
                TeacherPrefix = teacherUserTask.Result.TeacherUserProfile.TeacherPrefix.Title,
                TeachersCourse = teacherCourseTask.Result,
                TeacherSampleVideos = teacherSampleVideosTask.Result,
                TeacherResumes = teacherResumesTask.Result,
                AcceptedStudentInEntranceExamGroups = acceptedStudentInEntranceExamGroupsTask.Result
            };
            return viewModel;
        }
        //===================================================================
        static Task<UsersModel> GetTeacherUserTask(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<UsersModel>(() =>
            {
                using (var userRepository = new Repository<UsersModel>())
                {
                    var result = userRepository.FirstOrDefault(c => c.Id == teacherUserId && c.IsActive && c.UserGroupId == (int)UserGroup.Teacher, c => c.TeacherUserProfile.TeacherPrefix);
                    return result;
                }
            });
            task.Start();
            return task;
        } 
        //===================================================================
        static Task<List<TeacherSampleVideosViewModel>> GetTeacherSampleVideosTask(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<TeacherSampleVideosViewModel>>(() =>
            {
                using (var teacherSampleVideosRepository = new Repository<TeacherSampleVideosModel>())
                {
                    var result = teacherSampleVideosRepository.Where(c => c.TeacherId == teacherUserId && c.IsActive && c.Teacher.UserGroupId == (int)UserGroup.Teacher, c => c.Teacher)
                    .Select(c => new TeacherSampleVideosViewModel()
                    {
                        Id = c.Id,
                        Link = c.Link,
                        Title = c.Title,
                        Inx = c.Inx
                    }).OrderBy(c => c.Inx).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=============================================================================
        static Task<List<TeachersCourseViewModel>> GetTeacherCourseTask(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<TeachersCourseViewModel>>(() =>
            {
                using (var coursesRepository = new Repository<CoursesModel>())
                {
                    var result = coursesRepository.Where(c => c.IsActive && c.TeacherUserId == teacherUserId, c => c.TeacherUser.TeacherUserProfile)
                    .Select(c => new TeachersCourseViewModel()
                    {
                        Id = c.Id,
                        BannerPicPath = string.IsNullOrEmpty(c.BannerPicPath) ? string.Empty : CdnUrl + c.BannerPicPath,
                        DiscountPrice = Convert.ToInt32( c.Price - (c.Price * c.DiscountPercent / 100)),
                        DiscountPercent = c.DiscountPercent,
                        Name = c.Name,
                        Price = c.Price,
                        TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                        TeacherPersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : CdnUrl + c.TeacherUser.PersonalPicPath,
                        TeacherSkill = c.TeacherUser.TeacherUserProfile.Skill
                    }).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }

        //=============================================================================
        static Task<List<TeacherResumesViewModel>> GetTeacherResumesTask(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<TeacherResumesViewModel>>(() =>
            {
                using (var teacherResumesRepository = new Repository<TeacherResumesModel>())
                {
                    var result = teacherResumesRepository.Where(c => c.TeacherUserId == teacherUserId && c.IsActive, c => c.TeacherUser.TeacherUserProfile).OrderBy(c => c.Inx)
                    .Select(c => new TeacherResumesViewModel()
                    {
                        Id = c.Id,
                        Title = c.Title
                    }).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=================================================================
        static Task<List<AcceptedStudentInEntranceExamGroupsViewModel>> GetAcceptedStudentInEntranceExamGroupsTask(int teacherUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<AcceptedStudentInEntranceExamGroupsViewModel>>(() =>
            {
                using (var component = new AcceptedStudentInEntranceExamsComponent())
                {
                    var result = component.Raed(teacherUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //================================================================= Disposing
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
            // teacherSampleVideosRepository?.Dispose();
        }
        #endregion
    }
}
