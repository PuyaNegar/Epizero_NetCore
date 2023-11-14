using Common.Extentions;
using Common.Functions;
using DataAccessLayer.Repositories;
using System;
using System.Linq;
using System.IO;
using DataModels.ContentsModels;
using X.Web.Sitemap;
using DataModels.TrainingManagementModels;
using DataModels.OnlineExamModels;
using DataModels.IdentitiesModels;

namespace WebBusinessLogicLayer.BusinessComponents.Systems
{
    public class CreateSiteMapComponent : IDisposable
    {
        Repository<CoursesModel> coursesRepository;
        Repository<BlogsModel> blogsRepository;
        Repository<UsersModel> teachersRepository;
        Repository<OnlineExamsModel> onlineExamsRepository;
        //============================================================
        public CreateSiteMapComponent()
        {
            coursesRepository = new Repository<CoursesModel>();
            blogsRepository = new Repository<BlogsModel>();
            teachersRepository = new Repository<UsersModel>();
            onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //============================================================
        public void Operation()
        {
            using (var streamWriter = new StreamWriter(AppConfigProvider.GetSiteMapOutputPath() + @"\sitemap.xml"))
            {
                var courses = coursesRepository.Where(c => c.IsActive ).ToList();
                var blogs = blogsRepository.Where(c => c.BlogGroups.IsActive).ToList();
                var teachers = teachersRepository.Where(c=> c.IsActive).ToList();

                var sitemap = new Sitemap();

                foreach (var product in courses.Where(c => c.CourseCategoryTypeId == 2))
                {
                    sitemap.Add(new X.Web.Sitemap.Url
                    {
                        ChangeFrequency = ChangeFrequency.Weekly,
                        Location = AppConfigProvider.GetApplicationUrl() + "/Trainings/Courses/Index?CoursesId=#".Replace("#", product.Id.ToString()),
                        Priority = 0.5,
                        TimeStamp = DateTime.UtcNow.ToLocalDateTime(),
                    });
                }

                foreach (var product in courses.Where(c=> c.CourseCategoryTypeId == 1))
                {
                    sitemap.Add(new X.Web.Sitemap.Url
                    {
                        ChangeFrequency = ChangeFrequency.Weekly,
                        Location = AppConfigProvider.GetApplicationUrl() + "/Trainings/Courses/Index?CoursesId=#".Replace("#", product.Id.ToString()),
                        Priority = 0.5,
                        TimeStamp = DateTime.UtcNow.ToLocalDateTime(),
                    });
                }

                foreach (var suggestionTeacher in teachers.Where(c => c.UserGroupId == 2))
                {
                    sitemap.Add(new X.Web.Sitemap.Url
                    {
                        ChangeFrequency = ChangeFrequency.Weekly,
                        Location = AppConfigProvider.GetApplicationUrl() + "/Contents/TeacherIntroductions?teacherId=#".Replace("#", suggestionTeacher.Id.ToString()),
                        Priority = 0.5,
                        TimeStamp = DateTime.UtcNow.ToLocalDateTime(),
                    });
                }
               
                foreach (var suggestionTeacher in teachers.Where(c=> c.UserGroupId == 6))
                {
                    sitemap.Add(new X.Web.Sitemap.Url
                    {
                        ChangeFrequency = ChangeFrequency.Weekly,
                        Location = AppConfigProvider.GetApplicationUrl() + "/Contents/TeacherIntroductions?teacherId=#".Replace("#", suggestionTeacher.Id.ToString()),
                        Priority = 0.5,
                        TimeStamp = DateTime.UtcNow.ToLocalDateTime(),
                    });
                }

                foreach (var blog in blogs)
                {
                    sitemap.Add(new X.Web.Sitemap.Url
                    {
                        ChangeFrequency = ChangeFrequency.Weekly,
                        Location = AppConfigProvider.GetApplicationUrl() + "/Contents/SingleBlog?Id=#".Replace("#", blog.Id.ToString()),
                        Priority = 0.5,
                        TimeStamp = DateTime.UtcNow.ToLocalDateTime(),
                    });
                }



                var xml = sitemap.ToXml();
                streamWriter.Write(xml);
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
