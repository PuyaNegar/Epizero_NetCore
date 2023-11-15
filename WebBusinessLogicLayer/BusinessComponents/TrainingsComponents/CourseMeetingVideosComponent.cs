using Common.Functions;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModels.TrainingManagementModels;
using WebViewModels.TrainingsViewModels;
using Common.Objects;
using DataModels.ContentsModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseMeetingVideosComponent : IDisposable
    {
        private Repository<CourseMeetingVideosModel> courseMeetingVideosRepository;
        //===========================================
        public CourseMeetingVideosComponent()
        {
            courseMeetingVideosRepository = new Repository<CourseMeetingVideosModel>();
        }
        //===========================================
        public List<CourseMeetingVideosViewModel> Read(int studentUserId, int courseMeetingId)
        {
            StudentCourseMeetingsComponent.Validate(studentUserId, courseMeetingId);
            var result = courseMeetingVideosRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.IsActive).Select(c => new CourseMeetingVideosViewModel()
            {
                Id = c.Id,
                BannerPicPath = string.IsNullOrEmpty(c.BannerPicPath) ? string.Empty : AppConfigProvider.CdnUrl() + c.BannerPicPath,
                Title = c.Title,
                Description = c.Description,
                Link = c.Link,
                //VideoUniqueId = c.VideoUniqueId,
            }).ToList();
            return result;
        }
        //===========================================
        public CourseMeetingVideosViewModel Find(int id)
        {
            var result = courseMeetingVideosRepository.SingleOrDefault(c => c.Id == id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            var model = new CourseMeetingVideosViewModel()
            {
                Id = result.Id,
                BannerPicPath = string.IsNullOrEmpty(result.BannerPicPath) ? string.Empty : AppConfigProvider.CdnUrl() + result.BannerPicPath,
                Title = result.Title,
                Description = result.Description,
                Link = result.Link,
            };
            return model;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingVideosRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
