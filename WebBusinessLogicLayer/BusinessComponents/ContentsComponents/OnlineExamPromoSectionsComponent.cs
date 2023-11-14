using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Functions;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using DataModels.IdentitiesModels;
using WebViewModels.ContentsViewModels;
using DataModels.FinancialsModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentManagement
{
    public class OnlineExamPromoSectionsComponent : IDisposable
    {
        private Repository<OnlineExamPromosModel> onlineExamPromosRepository;
        //===========================================================
        public OnlineExamPromoSectionsComponent()
        {
            onlineExamPromosRepository = new Repository<OnlineExamPromosModel>();
        }
        //===========================================================
        public List<OnlineExamPromoSectionsViewModel> Read()
        {
            var RootCdnPath = AppConfigProvider.CdnUrl();
            var result = onlineExamPromosRepository.Where(c => c.OnlineExamPromoSection.IsActive && c.Course.IsActive && c.Course.IsVisibleOnSite, c => c.Course.TeacherUser, c => c.OnlineExamPromoSection)
                .Select(c => new OnlineExamPromosModel()
                {
                    Inx = c.Inx,
                    OnlineExamPromoSection = new OnlineExamPromoSectionsModel() { Id = c.OnlineExamPromoSection.Id, Inx = c.OnlineExamPromoSection.Inx, Title = c.OnlineExamPromoSection.Title },
                    Course = new CoursesModel()
                    {
                        Id = c.Course.Id,
                        Name = c.Course.Name,
                        BannerPicPath = string.IsNullOrEmpty(c.Course.BannerPicPath) ? string.Empty : RootCdnPath + c.Course.BannerPicPath,
                        LogoPicPath = string.IsNullOrEmpty(c.Course.LogoPicPath) ? string.Empty : RootCdnPath + c.Course.LogoPicPath,
                        DiscountPercent = c.Course.DiscountPercent,
                        Price = c.Course.Price,
                        TeacherUserId = c.Course.TeacherUserId,
                        IsMultiTeacher = c.Course.IsMultiTeacher,
                        TeacherUser = new UsersModel()
                        {
                            FirstName = c.Course.TeacherUser.FirstName,
                            LastName = c.Course.TeacherUser.LastName,
                            PersonalPicPath = string.IsNullOrEmpty(c.Course.TeacherUser.PersonalPicPath) ? string.Empty : RootCdnPath + c.Course.TeacherUser.PersonalPicPath,
                        }
                    }
                }).ToList();
            if (result.Where(c => c.Course.IsMultiTeacher).Any())
                return CreateSection(result, GetCourseDedicatedTeacher(result));
            else
                return CreateSection(result, null);
        }
        //===========================================================
        List<CourseDedicatedTeachersViewModel> GetCourseDedicatedTeacher(List<OnlineExamPromosModel> result)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var courseIds = result.Where(d => d.Course.IsMultiTeacher).Select(c => c.Course.Id).ToList();
            using (var courseMultiTeacherShares = new Repository<CourseMultiTeacherSharesModel>())
            {
                var data = courseMultiTeacherShares.Where(c => courseIds.Contains(c.CourseId), c => c.TeacherUser).Select(c => new CourseMultiTeacherSharesModel()
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
        }
        //===========================================================
        private List<OnlineExamPromoSectionsViewModel> CreateSection(List<OnlineExamPromosModel> model, List<CourseDedicatedTeachersViewModel> viewModel)
        {
            var result = model.GroupBy(c => new
            {
                c.OnlineExamPromoSection.Id,
                c.OnlineExamPromoSection.Title,
                c.OnlineExamPromoSection.Inx
            }).Select(c => new OnlineExamPromoSectionsViewModel()
            {
                Id = c.Key.Id,
                Title = c.Key.Title,
                Inx = c.Key.Inx,
                CoursePromos = c.OrderBy(d => d.Inx).Select(d => new CoursePromosViewModel()
                {
                    Id = d.Course.Id,
                    Name = d.Course.Name,
                    BannerPicPath = d.Course.BannerPicPath,
                    LogoPicPath = d.Course.LogoPicPath,
                    DiscountPrice = Convert.ToInt32( d.Course.Price - (d.Course.Price * d.Course.DiscountPercent / 100)),
                    DiscountPercent = d.Course.DiscountPercent,
                    Price = d.Course.Price,
                    IsMultiTeacher = d.Course.IsMultiTeacher,
                    TeacherUserId = d.Course.TeacherUserId,
                    TeacherFullName = d.Course.TeacherUser.FirstName + " " + d.Course.TeacherUser.LastName,
                    TeacherPersonalPicPath = d.Course.TeacherUser.PersonalPicPath,
                    CourseDedicatedTeachers = viewModel == null ? new List<CourseDedicatedTeachersViewModel>() : viewModel.Where(x => x.CourseId == d.Course.Id).OrderBy(g => Guid.NewGuid()).ToList()
                }).ToList()
            }).OrderBy(c => c.Inx).ToList();
            return result;
        }
        //=========================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamPromosRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //============================================================
    }
}
