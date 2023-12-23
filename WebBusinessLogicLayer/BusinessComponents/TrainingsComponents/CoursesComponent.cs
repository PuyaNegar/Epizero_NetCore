using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.ContentsViewModels;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CoursesComponent : IDisposable
    {

        private Repository<CoursesModel> courseRepository;
        //============================================================
        public CoursesComponent()
        {
            courseRepository = new Repository<CoursesModel>();
        }
        public CoursesViewModel Read(int courseId, int? studentUserId)
        {
            var course = GetCourse(courseId);
            var teacherResumesTask = GetTeacherResumesTask(course.TeacherUserId);
            var CdnUrl = AppConfigProvider.CdnUrl();
            var courseMeetingTask = GetCourseMeetingTask(courseId, (CourseCategoryType)course.CourseCategoryTypeId, studentUserId);
            var similarCouresTask = GetSimilarCouresTask(courseId, course.Lessons == null ? 0 : course.Lessons.LevelId, (CourseCategoryType)course.CourseCategoryTypeId);
            var courseSampleVideosTask = GetCourseSampleVideosTask(courseId);
            var courseDescriptionVideosTask = GetCourseDescriptionVideosTask(courseId);
            var courseMeetingStudentsTask = GetCourseMeetingStudentsTask(studentUserId, courseId);
            var studentFieldIdTask = GetStudentFieldIdTask(studentUserId);
            var courseDedicatedTeachersTask = GetCourseDedicatedTeachersTask(courseId);
            var courseFAQsTask = GetCourseFAQsTask(courseId);
            var commentOldStudentCoursesTask = GetCommentOldStudentCoursesTask(courseId);
            var courseStudentNewCommentsTask = GetCourseStudentNewCommentsTask(courseId);
            var scoreTask = GetScoreTask();
            Task.WaitAll(studentFieldIdTask, courseStudentNewCommentsTask, courseDedicatedTeachersTask, courseMeetingTask, similarCouresTask, courseSampleVideosTask, courseMeetingStudentsTask);

            var viewModel = new CoursesViewModel()
            {
                Id = course.Id,
                CourseMeetingCount = course.CourseMeetingCount,
                Audience = course.Audience,
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
                DiscountPrice = Convert.ToInt32(course.Price - (course.Price * course.DiscountPercent / 100)),
                StartDate = course.StartDate == null ? "ثبت نشده" : course.StartDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                TeacherUserId = course.TeacherUser.Id,
                TeacherFullName = course.TeacherUser.FirstName + " " + course.TeacherUser.LastName,
                LessonName = course.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? "ثبت نشده" : course.Lessons.Name,
                LevelName = course.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam ? "ثبت نشده" : course.Lessons.Level.Name,
                LanguageName = course.Languages.Name,
                CourseMeetings = courseMeetingTask.Result,
                CourseSampleVideos = courseSampleVideosTask.Result,
                CourseDescriptionVideos = courseDescriptionVideosTask.Result,
                StudentAccessToCourse = courseMeetingStudentsTask.Result,
                SimilarCoures = similarCouresTask.Result,
                StudentFieldId = studentFieldIdTask.Result,
                CourseFAQs = courseFAQsTask.Result,
                TeacherResumes = teacherResumesTask.Result,
                CommentOldStudentCourses = commentOldStudentCoursesTask.Result,
                CourseDedicatedTeachers = course.IsMultiTeacher ? courseDedicatedTeachersTask.Result : new List<CourseDedicatedTeachersViewModel>(),
                CourseStudentNewComments = courseStudentNewCommentsTask.Result,
                NumberCoins = course.DiscountPercent > 0 ? ((Convert.ToInt32(course.Price - (course.Price * course.DiscountPercent / 100))) / 100000) * scoreTask.Result : (course.Price / 100000) * scoreTask.Result,
            };
            return viewModel;
        }
        //===================================================================
        CoursesModel GetCourse(int courseId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            using (var courseRepository = new Repository<CoursesModel>())
            {
                var result = courseRepository.FirstOrDefault(c => c.Id == courseId && c.IsActive, c => c.CourseTypes, c => c.CourseMeetings, c => c.Lessons.Level, c => c.Languages, c => c.TeacherUser);
                return result;
            }
        }
        //===================================================================
        public IQueryable<CoursesModel> ReadByCousreType(CourseCategoryType? courseCategoryType)
        {

            IQueryable<CoursesModel> query = courseRepository.SelectAllAsQuerable(c => c.CourseTypes, c => c.Lessons.Level, c => c.TeacherUser.TeacherUserProfile);
            query = query.Where(c => c.CourseCategoryTypeId == (int)courseCategoryType && c.IsActive);
            return query.OrderByDescending(c => c.Inx);

        }
        //===================================================================
        Task<List<CourseDescriptionVideosViewModel>> GetCourseDescriptionVideosTask(int courseId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<CourseDescriptionVideosViewModel>>(() =>
            {
                using (var courseSampleVideosRepository = new Repository<CourseDescriptionVideosModel>())
                {
                    var result = courseSampleVideosRepository.Where(c => c.CourseId == courseId && c.IsActive, c => c.Course)
                    .Select(c => new CourseDescriptionVideosViewModel()
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
        //===================================================================
        Task<List<CourseSampleVideosViewModel>> GetCourseSampleVideosTask(int courseId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<CourseSampleVideosViewModel>>(() =>
            {
                using (var courseSampleVideosRepository = new Repository<CourseSampleVideosModel>())
                {
                    var result = courseSampleVideosRepository.Where(c => c.CourseId == courseId && c.IsActive, c => c.Course)
                    .Select(c => new CourseSampleVideosViewModel()
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
        Task<List<CourseMeetingsViewModel>> GetCourseMeetingTask(int courseId, CourseCategoryType courseCategoryType, int? studentUserId)
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var task = new Task<List<CourseMeetingsViewModel>>(() =>
            {
                var onlineExamFields = new List<OnlineExamFieldsModel>();
                if (courseCategoryType == CourseCategoryType.OnlineExam)
                {
                    using (var onlineExamFieldsRepository = new Repository<OnlineExamFieldsModel>())
                    {
                        onlineExamFields = onlineExamFieldsRepository.Where(c => c.OnlineExam.CourseMeeting.CourseId == courseId).ToList();
                    }
                }
                using (var coursesMeetingRepository = new Repository<CourseMeetingsModel>())
                {
                    var result = coursesMeetingRepository.Where(c => c.CourseId == courseId && c.IsActive, c => c.Course.TeacherUser, c => c.OnlineExam.OnlineExamQuestions, c => c.CourseMeetingDedicatedTeacher.TeacherUser).ToList().OrderBy(c => c.StartDateTime)
                    .Select(c => new CourseMeetingsViewModel()
                    {
                        Id = c.Id,
                        Inx = c.Inx,
                        NumberQuestions = c.OnlineExam == null ? "ثبت نشده" : c.OnlineExam.OnlineExamQuestions.Count().ToString(),
                        AnalysisVideoLink = c.OnlineExam == null ? null : c.OnlineExam.AnalysisVideoLink,
                        IsPurchasable = c.IsPurchasable,
                        DiscountPrice = Convert.ToInt32(c.Price - (c.Price * c.DiscountPercent / 100)),
                        Name = c.Name,
                        Price = c.Price,
                        CourseId = c.CourseId,
                        TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                        CourseName = c.Course.Name,
                        Description = c.Description,
                        HasBooklet = c.HasBooklet,
                        CourseDuration = c.OnlineExam == null ? 0 : c.OnlineExam.Duration,
                        StartDateTime = c.OnlineExam != null ? c.StartDateTime.ToLocalDateTime().ToDateShortFormatString() + "-" + c.OnlineExam.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString() : c.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                        EndDateTime = c.OnlineExam != null ? c.OnlineExam.StartDateTime.AddMinutes(/*c.OnlineExam.Duration +*/ (c.OnlineExam.AllowedTimeToEnter == null ? 0 : c.OnlineExam.AllowedTimeToEnter.Value)).ToLocalDateTimeShortFormatString().Replace("ساعت", "-") : "ثیت نشده",
                        StartDateTimeOrginal = c.OnlineExam != null ? c.OnlineExam.StartDateTime : (DateTime?)null,
                        IsShowQuestionAnswer = c.OnlineExam != null ? (c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration + (c.OnlineExam.AllowedTimeToEnter == null ? 0 : c.OnlineExam.AllowedTimeToEnter.Value)) < DateTime.UtcNow && StudentOnlineExamFinalizeComponent.IsFinalized(c.OnlineExam.Id, studentUserId)) : false,
                        IsStarted = c.OnlineExam != null ? c.OnlineExam.StartDateTime < DateTime.UtcNow : false,
                        QuestionsPdf = c.PDFQuestionPath != null ? AppConfigProvider.CdnUrl() + c.PDFQuestionPath : null,
                        IsAvailableForSpecificFields = c.OnlineExam != null ? c.OnlineExam.IsAvailableForSpecificFields : false,
                        HasExam = c.HasExam,
                        HasHomework = c.HasHomework,
                        IsAbleToViewOrBuy = c.StartDateTime.Date > DateTime.UtcNow.Date ? false : true,
                        OnlineExamId = c.OnlineExam == null ? (int?)null : c.OnlineExam.Id,
                        OnlineExamFieldIds = (c.OnlineExam != null) ? (c.OnlineExam.IsAvailableForSpecificFields ? onlineExamFields.Where(d => d.OnlineExamId == c.OnlineExam.Id).Select(c => c.FieldId).ToList() : null) : new List<int>(),
                        CourseDedicatedTeacher = c.CourseMeetingDedicatedTeacher == null ? null : new CourseDedicatedTeachersViewModel()
                        {
                            CourseId = c.CourseId,
                            TeacherFullName = c.CourseMeetingDedicatedTeacher.TeacherUser.FirstName + " " + c.CourseMeetingDedicatedTeacher.TeacherUser.LastName,
                            TeacherUserId = c.CourseMeetingDedicatedTeacher.TeacherUser.Id,
                            PersonalPicPath = string.IsNullOrEmpty(c.CourseMeetingDedicatedTeacher.TeacherUser.PersonalPicPath) ? string.Empty : CdnUrl + c.CourseMeetingDedicatedTeacher.TeacherUser.PersonalPicPath
                        }
                    }).OrderBy(c => c.Inx).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=============================================================================
        Task<List<SimilarCouresViewModel>> GetSimilarCouresTask(int courseId, int levelId, CourseCategoryType courseCategoryType)
        {
            var RootCdnPath = AppConfigProvider.CdnUrl();
            var task = new Task<List<SimilarCouresViewModel>>(() =>
            {
                using (var coursesRepository = new Repository<CoursesModel>())
                {
                    Expression<Func<CoursesModel, bool>> query = courseCategoryType == CourseCategoryType.Training ?
                    (Expression<Func<CoursesModel, bool>>)(c => c.Id != courseId && c.CourseCategoryTypeId == (int)CourseCategoryType.Training && c.Lessons.LevelId == levelId && c.IsActive && c.Lessons.Level.IsActive) :
                    (Expression<Func<CoursesModel, bool>>)(c => c.Id != courseId && c.CourseCategoryTypeId == (int)CourseCategoryType.OnlineExam && c.IsActive && c.IsVisibleOnSite);

                    var result = coursesRepository.Where(query, c => c.TeacherUser).OrderBy(r => Guid.NewGuid()).Take(10).ToList().Select(c => new SimilarCouresViewModel()
                    {
                        Id = c.Id,
                        DiscountPrice = Convert.ToInt32(c.Price - (c.Price * c.DiscountPercent / 100)),
                        Name = c.Name,
                        Price = c.Price,
                        DiscountPercent = c.DiscountPercent,
                        TeacherPersonalPicPath = string.IsNullOrEmpty(c.TeacherUser.PersonalPicPath) ? string.Empty : RootCdnPath + c.TeacherUser.PersonalPicPath,
                        BannerPicPath = string.IsNullOrEmpty(c.BannerPicPath) ? string.Empty : RootCdnPath + c.BannerPicPath,
                        LogoPicPath = string.IsNullOrEmpty(c.LogoPicPath) ? string.Empty : RootCdnPath + c.LogoPicPath,
                        TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName
                    }).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=================================================================
        Task<StudentAccessToCourseViewModel> GetCourseMeetingStudentsTask(int? studentUserId, int courseId)
        {
            var task = new Task<StudentAccessToCourseViewModel>(() =>
            {
                if (studentUserId == null)
                    return new StudentAccessToCourseViewModel() { IsAccessToEntireCourse = false, AvalibleCourseMeetingIds = new List<int>() };
                return StudentCourseMeetingsComponent.ReadAvalibleCourse(studentUserId.Value, courseId);
            });
            task.Start();
            return task;
        }
        //==============================================================
        Task<int> GetStudentFieldIdTask(int? studentUserId)
        {
            var task = new Task<int>(() =>
            {
                if (studentUserId == null)
                    return 0;
                using (var repository = new Repository<StudentUserProfilesModel>())
                {
                    var result = repository.SingleOrDefault(c => c.UserId == studentUserId);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    return result.FieldId == null ? 0 : result.FieldId.Value;
                }
            });
            task.Start();
            return task;
        }
        //======================================================================
        Task<List<CourseDedicatedTeachersViewModel>> GetCourseDedicatedTeachersTask(int courseId)
        {
            var task = new Task<List<CourseDedicatedTeachersViewModel>>(() =>
            {
                using (var courseMultiTeacherShares = new Repository<CourseMultiTeacherSharesModel>())
                {
                    var cdnUrl = AppConfigProvider.CdnUrl();
                    var data = courseMultiTeacherShares.Where(c => c.CourseId == courseId).Select(c => new CourseMultiTeacherSharesModel()
                    {
                        CourseId = c.CourseId,
                        TeacherUserId = c.TeacherUserId,
                        IsIndexTeacher = c.IsIndexTeacher,
                        TeacherUser = new UsersModel()
                        {
                            Id = c.TeacherUser.Id,
                            FirstName = c.TeacherUser.FirstName,
                            LastName = c.TeacherUser.LastName,
                            PersonalPicPath = c.TeacherUser.PersonalPicPath,
                            TeacherUserProfile = new TeacherUserProfilesModel() { TeacherPrefix = new TeacherPrefixesModel() { Title = c.TeacherUser.TeacherUserProfile.TeacherPrefix.Title } }
                        }
                    }).ToList().GroupBy(c => new { c.IsIndexTeacher, c.CourseId, c.TeacherUser.FirstName, c.TeacherUser.LastName, c.TeacherUserId, c.TeacherUser.PersonalPicPath, TeacherPrefixTitle = c.TeacherUser.TeacherUserProfile.TeacherPrefix.Title }).Select(c => new CourseDedicatedTeachersViewModel()
                    {
                        CourseId = c.Key.CourseId,
                        TeacherUserId = c.Key.TeacherUserId,
                        IsIndexTeacher = c.Key.IsIndexTeacher,
                        TeacherFullName = c.Key.TeacherPrefixTitle + " " + c.Key.FirstName + " " + c.Key.LastName,
                        PersonalPicPath = string.IsNullOrEmpty(c.Key.PersonalPicPath) ? string.Empty : cdnUrl + c.Key.PersonalPicPath,
                    }).OrderBy(c => Guid.NewGuid()).ToList();
                    return data;
                }
            });
            task.Start();
            return task;
        }

        //======================================================================
        Task<List<CourseFAQsViewModel>> GetCourseFAQsTask(int courseId)
        {
            var task = new Task<List<CourseFAQsViewModel>>(() =>
            {
                List<int> FAQIds;
                List<FAQModel> result = null;
                using (var courseFAQsRepository = new Repository<CourseFAQsModel>())
                {
                    FAQIds = courseFAQsRepository.Where(c => c.CourseId == courseId).Select(c => c.FAQId).ToList<int>();
                }
                using (var fAQsRepository = new Repository<FAQModel>())
                {
                    result = fAQsRepository.Where(c => FAQIds.Contains(c.Id) && c.IsActive && !c.IsWebSite).ToList();
                }
                var viewModel = result.Select(c => new CourseFAQsViewModel()
                {
                    Id = c.Id,
                    AnswerContext = c.AnswerContext,
                    QuestionContext = c.QuestionContext,
                });
                return viewModel.OrderBy(c => c.Inx).ToList();
            });
            task.Start();
            return task;
        }
        //======================================================================
        Task<List<CommentOldStudentCoursesViewModel>> GetCommentOldStudentCoursesTask(int courseId)
        {
            var task = new Task<List<CommentOldStudentCoursesViewModel>>(() =>
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                List<int> OldStudentCommentIds;
                List<OldStudentCommentsModel> result = null;
                using (var commentOldStudentCoursesRepository = new Repository<CommentOldStudentCoursesModel>())
                {
                    OldStudentCommentIds = commentOldStudentCoursesRepository.Where(c => c.CourseId == courseId).Select(c => c.OldStudentCommentId).ToList<int>();
                }
                using (var oldStudentCommentsRepository = new Repository<OldStudentCommentsModel>())
                {
                    result = oldStudentCommentsRepository.Where(c => OldStudentCommentIds.Contains(c.Id) && c.IsActive, c => c.StudentUser).ToList();
                }
                var viewModel = result.Select(c => new CommentOldStudentCoursesViewModel()
                {
                    Id = c.Id,
                    CommentAudio = string.IsNullOrEmpty(c.CommentAudio) ? null : cdnUrl + c.CommentAudio,
                    CommentText = c.CommentText,
                    CommentVideo = c.CommentVideo,
                    Title = c.Title,
                    CommentTypeId = c.CommentTypeId,
                    RegDateTime = c.RegDateTimeComment.ToLocalDateTimeShortFormatString(),
                    StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                    PersonalPicPath = string.IsNullOrEmpty(c.StudentUser.PersonalPicPath) ? null : cdnUrl + c.StudentUser.PersonalPicPath,
                    Inx = c.Inx,
                });
                return viewModel.OrderBy(c => c.Inx).ToList();
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<List<ReadCourseStudentNewCommentsViewModel>> GetCourseStudentNewCommentsTask(int courseId)
        {
            var task = new Task<List<ReadCourseStudentNewCommentsViewModel>>(() =>
            {
                var cdnUrl = AppConfigProvider.CdnUrl();
                List<CourseStudentNewCommentsModel> result = null;
                using (var courseStudentNewCommentsRepository = new Repository<CourseStudentNewCommentsModel>())
                {
                    result = courseStudentNewCommentsRepository.Where(c => c.CourseId == courseId && c.IsActive, c => c.StudentUser, c => c.Course)
                    .OrderByDescending(c => c.RegDateTime).ToList();
                }
                var viewModel = result.Select(c => new ReadCourseStudentNewCommentsViewModel()
                {
                    Id = c.Id,
                    Comment = c.Comment,
                    RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                    StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                    PersonalPicPath = string.IsNullOrEmpty(c.StudentUser.PersonalPicPath) ? null : cdnUrl + c.StudentUser.PersonalPicPath,
                });
                return viewModel.ToList();
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<List<TeacherResumesViewModel>> GetTeacherResumesTask(int teacherUserId)
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
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<int> GetScoreTask()
        {
            var task = new Task<int>(() =>
            {
                var score = 0;
                using (var scoringTariffsRepository = new Repository<ScoringTariffsModel>())
                {
                    var result = scoringTariffsRepository.SingleOrDefault(c => c.Id == 2);
                    if (result != null)
                        score = result.Score;
                }
                return score;
            });
            task.Start();
            return task;
        }
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
