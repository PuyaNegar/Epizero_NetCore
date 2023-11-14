using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class TeacherResumesComponent : IDisposable
    {
        private Repository<TeacherResumesModel> teacherResumesRepository;
        public TeacherResumesComponent()
        {
            this.teacherResumesRepository = new Repository<TeacherResumesModel>();
        }
        //==============================================================================================
        public IQueryable<TeacherResumesModel> Read(int teacherUserId )
        {
            var result = teacherResumesRepository.Where( c=>c.TeacherUserId == teacherUserId, c=> c.TeacherUser);
            return result;
        }
        //==============================================================================================
        public void Add(TeacherResumesModel model)
        {
            teacherResumesRepository.Add(model);
            teacherResumesRepository.SaveChanges();
        }
        //==============================================================================================
        public TeacherResumesModel Find(int Id)
        {
            var result = teacherResumesRepository.SingleOrDefault(c => c.Id == Id, c=> c.TeacherUser);
            return result;
        }
        //==============================================================================================
        public void Update(TeacherResumesModel model)
        {
            //**********************************************
            var data = teacherResumesRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception(SystemCommonMessage.DataWasNotFound); }
            //********************************************** 
            data.Inx = model.Inx;
            data.Title = model.Title;
            //data.TeacherUserId = model.TeacherUserId;
            data.IsActive = model.IsActive;
            data.ModDateTime = DateTime.UtcNow;
            teacherResumesRepository.Update(data);
            teacherResumesRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<TeacherResumesModel> model)
        {
            teacherResumesRepository.DeleteRange(model);
            teacherResumesRepository.SaveChanges();
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
            teacherResumesRepository?.Dispose();
        }
        #endregion
    }
}
