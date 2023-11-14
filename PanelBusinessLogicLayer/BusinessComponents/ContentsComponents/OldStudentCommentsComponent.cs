using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class OldStudentCommentsComponent : IDisposable
    {
        private Repository<OldStudentCommentsModel> faqRepository;
        public OldStudentCommentsComponent()
        {
            this.faqRepository = new Repository<OldStudentCommentsModel>();
        }
        //==============================================================================================
        public IQueryable<OldStudentCommentsModel> Read()
        {
            var result = faqRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IQueryable<OldStudentCommentsModel> ReadForCourse()
        {
            var result = faqRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(OldStudentCommentsModel model)
        {
       
            faqRepository.Add(model);
            faqRepository.SaveChanges();
        }
        //==============================================================================================
        public OldStudentCommentsModel Find(int Id)
        {
            var result = faqRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(OldStudentCommentsModel model)
        {
            //**********************************************
            var data = faqRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.IsActive = model.IsActive;
            data.StudentUserId = model.StudentUserId;
            data.CommentTypeId = model.CommentTypeId;
            data.CommentAudio = model.CommentAudio;
            data.CommentText = model.CommentText;
            data.CommentVideo = model.CommentVideo;
            data.Title = model.Title;
            data.ModDateTime = DateTime.UtcNow;
            faqRepository.Update(data);
            faqRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<OldStudentCommentsModel> model)
        {
            faqRepository.DeleteRange(model);
            faqRepository.SaveChanges();
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
            faqRepository?.Dispose();
        }
        #endregion
    }
}
