using Common.Functions;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModels.TrainingManagementModels;
using WebViewModels.TrainingsViewModels;

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
