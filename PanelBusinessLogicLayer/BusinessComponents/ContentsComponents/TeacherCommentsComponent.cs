using Common.Enums;
using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.StoresComponents
{
    public class TeacherCommentsComponent : IDisposable
    {
        private Repository<TeacherCommentsModel> TeacherCommentsRepository;
        //private Repository<StoreProductsModel> storeProductsRepository;
        public TeacherCommentsComponent()
        {
            this.TeacherCommentsRepository = new Repository<TeacherCommentsModel>();
        }
        //=================================================================
        public IQueryable<TeacherCommentsModel> Read(ConfirmStatusType confirmStatusType)
        {
            var query = TeacherCommentsRepository.SelectAllAsQuerable();
            if (confirmStatusType == ConfirmStatusType.Padding)
                query = query.Where(c => c.IsConfirmed == null);
            if (confirmStatusType == ConfirmStatusType.Confirmed)
                query = query.Where(c => c.IsConfirmed.Value);
            if (confirmStatusType == ConfirmStatusType.Rejected)
                query = query.Where(c => !c.IsConfirmed.Value);
            return query;
        }
        //=================================================================
        public IQueryable<TeacherCommentsModel> ReadByUserTeacher(int UserTeacherId)
        {
            var result = TeacherCommentsRepository.Where(c => c.IsConfirmed != null && c.TeacherUserId == UserTeacherId);
            return result;
        }
        //==============================================================================================
        public TeacherCommentsModel Find(int Id)
        {
            var result = TeacherCommentsRepository.SingleOrDefault(c => c.Id == Id, c => c.TeacherUser, c => c.StudentUser);
            return result;
        }
        //==============================================================================================
        public void Update(TeacherCommentsModel model)
        {
            //**********************************************
            var data = TeacherCommentsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این نظر در سیستم موجود نمی‌باشد"); }
            //********************************************** 
            //data.IsActive = model.IsActive;
            data.IsConfirmed = model.IsConfirmed;
            data.ConfirmedDateTime = model.ConfirmedDateTime;
            data.Comment = model.Comment;
            TeacherCommentsRepository.Update(data);
            TeacherCommentsRepository.SaveChanges();
        }
        //==============================================================================================
        public void Delete(List<TeacherCommentsModel> model)
        {
            TeacherCommentsRepository.DeleteRange(model);
            TeacherCommentsRepository.SaveChanges();
        }

        //===============================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            TeacherCommentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
