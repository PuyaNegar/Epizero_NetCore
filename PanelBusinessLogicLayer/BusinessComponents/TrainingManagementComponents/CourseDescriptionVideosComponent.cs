using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class CourseDescriptionVideosComponent : IDisposable
    {
        private Repository<CourseDescriptionVideosModel> courseDescriptionVideosRepository;
        public CourseDescriptionVideosComponent()
        {
            this.courseDescriptionVideosRepository = new Repository<CourseDescriptionVideosModel>();
        }
        //==============================================================================================
        public IQueryable<CourseDescriptionVideosModel> Read(int CourseId)
        {
            var result = courseDescriptionVideosRepository.Where(c => c.CourseId == CourseId , c => c.Course);
            return result;
        }
        //==============================================================================================
        public void Add(CourseDescriptionVideosModel model)
        {
            courseDescriptionVideosRepository.Add(model);
            courseDescriptionVideosRepository.SaveChanges();
        }
        //==============================================================================================
        public CourseDescriptionVideosModel Find(int Id)
        {
            var result = courseDescriptionVideosRepository.SingleOrDefault(c => c.Id == Id, c => c.Course);
            return result;
        }
        //==============================================================================================
        public void Update(CourseDescriptionVideosModel model)
        {
            //**********************************************
            var data = courseDescriptionVideosRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این  فیلم در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.CourseId = model.CourseId;
            data.Title = model.Title;
            data.Link = model.Link;
            data.IsActive = model.IsActive;
            data.ModDateTime = DateTime.UtcNow;
            courseDescriptionVideosRepository.Update(data);
            courseDescriptionVideosRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<CourseDescriptionVideosModel> model)
        {
            courseDescriptionVideosRepository.DeleteRange(model);
            courseDescriptionVideosRepository.SaveChanges();
        }
        //=================================================================Disposing
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
            courseDescriptionVideosRepository?.Dispose();
        }
        #endregion
    }
}
