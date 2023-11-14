using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class CourseSampleVideosComponent : IDisposable
    {
        private Repository<CourseSampleVideosModel> courseSampleVideosRepository;
        public CourseSampleVideosComponent()
        {
            this.courseSampleVideosRepository = new Repository<CourseSampleVideosModel>();
        }
        //==============================================================================================
        public IQueryable<CourseSampleVideosModel> Read(int CourseId)
        {
            var result = courseSampleVideosRepository.Where(c => c.CourseId == CourseId , c => c.Course, c => c.ModUser);
            return result;
        }
        //==============================================================================================
        public void Add(CourseSampleVideosModel model)
        {
            courseSampleVideosRepository.Add(model);
            courseSampleVideosRepository.SaveChanges();
        }
        //==============================================================================================
        public CourseSampleVideosModel Find(int Id)
        {
            var result = courseSampleVideosRepository.SingleOrDefault(c => c.Id == Id, c => c.Course);
            return result;
        }
        //==============================================================================================
        public void Update(CourseSampleVideosModel model)
        {
            //**********************************************
            var data = courseSampleVideosRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این  فیلم در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.CourseId = model.CourseId;
            data.Title = model.Title;
            data.Link = model.Link;
            data.IsActive = model.IsActive;
            data.ModDateTime = DateTime.UtcNow;
            courseSampleVideosRepository.Update(data);
            courseSampleVideosRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<CourseSampleVideosModel> model)
        {
            courseSampleVideosRepository.DeleteRange(model);
            courseSampleVideosRepository.SaveChanges();
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
            courseSampleVideosRepository?.Dispose();
        }
        #endregion
    }
}
