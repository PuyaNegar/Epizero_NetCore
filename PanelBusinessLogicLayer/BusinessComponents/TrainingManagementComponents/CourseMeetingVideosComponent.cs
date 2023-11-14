using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class CourseMeetingVideosComponent : IDisposable
    {
        private Repository<CourseMeetingVideosModel> courseMeetingVideosRepository;
        //======================================================
        public CourseMeetingVideosComponent()
        {
            courseMeetingVideosRepository = new Repository<CourseMeetingVideosModel>();
        }
        //===================================================
        public IQueryable<CourseMeetingVideosModel> Read(int CourseMeetingId)
        {
            var result = courseMeetingVideosRepository.Where(c => c.CourseMeetingId == CourseMeetingId, c => c.CourseMeeting , c=> c.ModUser);
            return result;
        }
        //=====================================================
        public void Add(CourseMeetingVideosModel model)
        {
            model.BannerPicPath = FileComponentProvider.Save(FileFolder.CourseMeetingVideos, model.BannerPicPath);
            courseMeetingVideosRepository.Add(model);
            courseMeetingVideosRepository.SaveChanges();
        }
        //===================================================
        public CourseMeetingVideosModel Find(int Id)
        {
            var result = courseMeetingVideosRepository.Where(c => c.Id == Id, c => c.CourseMeeting).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(CourseMeetingVideosModel model, int currentUserId)
        {
            var result = courseMeetingVideosRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.BannerPicPath = FileComponentProvider.Save(FileFolder.CourseMeetingVideos, model.BannerPicPath);
            result.Title = model.Title;
            //result.VideoUniqueId = model.VideoUniqueId;
            result.Description = model.Description;
            result.Link = model.Link;
            result.IsActive = model.IsActive;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            courseMeetingVideosRepository.Update(result);
            courseMeetingVideosRepository.SaveChanges();
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            courseMeetingVideosRepository.Delete(c => Ids.Contains(c.Id));
            courseMeetingVideosRepository.SaveChanges();
        }
        //=================================================== Disposing
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
            courseMeetingVideosRepository?.Dispose();
        }
        #endregion
    }
}
