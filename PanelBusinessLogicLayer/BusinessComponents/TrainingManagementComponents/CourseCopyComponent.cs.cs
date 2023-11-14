using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.HomeworksModels;
using DataModels.TrainingManagementModels;
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseCopyComponent : IDisposable
    {
        MainDBContext mainDBContext { get; set; }
        Repository<CourseMeetingVideosModel> courseMeetingVideosRepository;
        Repository<CoursesModel> coursesRepository;
        Repository<CourseMeetingsModel> courseMeetingsRepository;
        Repository<CourseSampleVideosModel> courseSampleVideosRepository;
        Repository<CourseDescriptionVideosModel> courseDescriptionVideosRepository;
        Repository<CourseMeetingBookletsModel> courseMeetingBookletsRepository;
        Repository<CourseBookletsModel> courseBookletsRepository;
        Repository<HomeworksModel> homeworksRepository;
        public CourseCopyComponent()
        {
            mainDBContext = new MainDBContext();
            coursesRepository = new Repository<CoursesModel>(mainDBContext);
            courseMeetingsRepository = new Repository<CourseMeetingsModel>(mainDBContext);
            courseMeetingVideosRepository = new Repository<CourseMeetingVideosModel>(mainDBContext);
            courseSampleVideosRepository = new Repository<CourseSampleVideosModel>(mainDBContext);
            courseMeetingBookletsRepository = new Repository<CourseMeetingBookletsModel>(mainDBContext);
            courseBookletsRepository = new Repository<CourseBookletsModel>(mainDBContext);
            homeworksRepository = new Repository<HomeworksModel>(mainDBContext);
            courseDescriptionVideosRepository = new Repository<CourseDescriptionVideosModel>();
        }
        //============================================
        public void Operation(int courseId, int currentUserId)
        {
            var course = coursesRepository.SingleOrDefault(c => c.Id == courseId);
            if (course == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);


            var courseSampleVideos = courseSampleVideosRepository.Where(c => c.CourseId == courseId).ToList();
            var newCourse = new CoursesModel()
            {
                BannerPicPath = course.BannerPicPath,
                TeacherUserId = course.TeacherUserId,
                CourseCategoryTypeId = course.CourseCategoryTypeId,
                CourseDuration = course.CourseDuration,
                StartDate = course.StartDate,
                CourseTypeId = course.CourseTypeId,
                LessonId = course.LessonId,
                CourseMeetingCount = course.CourseMeetingCount,
                Audience = course.Audience,
                Description = course.Description,
                EndDate = course.EndDate,
                DiscountPercent = course.DiscountPercent,
                Inx = course.Inx,
                RegDateTime = DateTime.UtcNow,
                Price = course.Price,
                Name = course.Name,
                ModUserId = currentUserId,
                LogoPicPath = course.LogoPicPath,
                IsActive = course.IsActive,
                IsMultiTeacher = course.IsMultiTeacher,
                IsVisibleOnSite = course.IsVisibleOnSite,
                MetaDescription = course.MetaDescription,
                IsShowDetailsInWeb = course.IsShowDetailsInWeb,
                LanguageId = course.LanguageId,
                CourseBooklets = courseBookletsRepository.Where(c => c.CourseId == courseId).Select(c => new CourseBookletsModel()
                {
                    EmbedLink = c.EmbedLink,
                    ModUserId = currentUserId,
                    FilePath = c.FilePath,
                    Description = c.Description,
                    IsActive = c.IsActive,
                    Title = c.Title,
                    RegDateTime = DateTime.UtcNow,
                }).ToList(),
                CourseDescriptionVideos = courseDescriptionVideosRepository.Where(c => c.CourseId == courseId).ToList().Select(c => new CourseDescriptionVideosModel()
                {
                    IsActive = c.IsActive,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    Link = c.Link,
                    Title = c.Title,
                    Inx = c.Inx,
                }).ToList(),
                CourseSampleVideos = courseSampleVideos.Select(c => new CourseSampleVideosModel()
                {
                    Inx = c.Inx,
                    IsActive = c.IsActive,
                    Title = c.Title,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = currentUserId,
                    Link = c.Link,
                }).ToList(),
                CourseMeetings = courseMeetingsRepository.Where(c => c.CourseId == courseId).ToList().Select(c => new CourseMeetingsModel()
                {
                    Description = c.Description,
                    IsActive = c.IsActive,
                    DiscountPercent = c.DiscountPercent,
                    TeacherUserId = c.TeacherUserId,
                    StartDateTime = c.StartDateTime,
                    RegDateTime = DateTime.UtcNow,
                    HasBooklet = c.HasBooklet,
                    HasExam = false,
                    HasHomework = c.HasHomework,
                    Price = c.Price,
                    Name = c.Name,
                    ModUserId = currentUserId,
                    IsPurchasable = c.IsPurchasable,

                    CourseMeetingVideos = courseMeetingVideosRepository.Where(d => d.CourseMeeting.Id == c.Id).ToList().Select(d => new CourseMeetingVideosModel()
                    {
                        BannerPicPath = d.BannerPicPath,
                        Description = d.Description,
                        IsActive = d.IsActive,
                        Link = d.Link,
                        RegDateTime = DateTime.UtcNow,
                        Title = d.Title,
                        ModUserId = currentUserId,
                    }).ToList(),
                    CourseMeetingBooklet = courseMeetingBookletsRepository.Where(d => d.CourseMeeting.Id == c.Id).ToList().Select(d => new CourseMeetingBookletsModel()
                    {
                        Description = d.Description,
                        FilePath = d.FilePath,
                        IsActive = d.IsActive,
                        Title = d.Title,
                        ModUserId = currentUserId,
                        RegDateTime = DateTime.UtcNow,
                    }).ToList(),
                    Homeworks = homeworksRepository.Where(d => d.CourseMeeting.Id == c.Id).ToList().Select(d => new HomeworksModel()
                    {
                        Description = d.Description,
                        Title = d.Title,
                        RegDateTime = DateTime.UtcNow,
                        FilePath = d.FilePath,
                        ExpiredDate = d.ExpiredDate,
                        IsActive = d.IsActive,
                        ModUserId = currentUserId,
                    }).ToList(),
                }).ToList(),
            };

            coursesRepository.Add(newCourse);
            coursesRepository.SaveChanges();
        }
        //============================================
        public void Dispose()
        {
            coursesRepository?.Dispose();
            courseMeetingsRepository?.Dispose();
            courseMeetingVideosRepository?.Dispose();
            courseSampleVideosRepository?.Dispose();
            courseMeetingBookletsRepository?.Dispose();
            courseBookletsRepository?.Dispose();
            homeworksRepository?.Dispose();
            courseDescriptionVideosRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
