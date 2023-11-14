using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class TeacherSampleVideosComponent : IDisposable
    {
        private Repository<TeacherSampleVideosModel> teacherSampleVideosRepository;
        public TeacherSampleVideosComponent()
        {
            this.teacherSampleVideosRepository = new Repository<TeacherSampleVideosModel>();
        }
        //==============================================================================================
        public IQueryable<TeacherSampleVideosModel> Read(int TeacherId)
        {
            var result = teacherSampleVideosRepository.Where(c =>c.TeacherId == TeacherId && c.Teacher.UserGroupId == (int)UserGroup.Teacher,c=> c.Teacher);
            return result;
        }
        //==============================================================================================
        public void Add(TeacherSampleVideosModel model)
        {
            teacherSampleVideosRepository.Add(model);
            teacherSampleVideosRepository.SaveChanges();
        }
        //==============================================================================================
        public TeacherSampleVideosModel Find(int Id)
        {
            var result = teacherSampleVideosRepository.SingleOrDefault(c => c.Id == Id, c => c.Teacher);
            return result;
        }
        //==============================================================================================
        public void Update(TeacherSampleVideosModel model)
        {
            //**********************************************
            var data = teacherSampleVideosRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این  فیلم تبلیغاتی در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.TeacherId = model.TeacherId;
            data.Title = model.Title;
            data.Link = model.Link;
            data.IsActive = model.IsActive;
            data.ModDateTime = DateTime.UtcNow;
            teacherSampleVideosRepository.Update(data);
            teacherSampleVideosRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<TeacherSampleVideosModel> model)
        {
            teacherSampleVideosRepository.DeleteRange(model);
            teacherSampleVideosRepository.SaveChanges();
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
            teacherSampleVideosRepository?.Dispose();
        }
        #endregion
    }
}
