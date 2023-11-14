using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class FAQComponent : IDisposable
    {
        private Repository<FAQModel> faqRepository;
        public FAQComponent()
        {
            this.faqRepository = new  Repository<FAQModel> ();
        }
        //==============================================================================================
        public IQueryable<FAQModel> Read()
        {
            var result = faqRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IQueryable<FAQModel> ReadForCourse()
        {
            var result = faqRepository.Where(c=> !c.IsWebSite);
            return result;
        }
        //==============================================================================================
        public void Add(FAQModel model)
        { 
            faqRepository.Add(model);
            faqRepository.SaveChanges();
        }
        //==============================================================================================
        public FAQModel Find(int Id)
        {
            var result = faqRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(FAQModel model)
        {
            //**********************************************
            var data = faqRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.IsWebSite = model.IsWebSite;
            data.QuestionContext = model.QuestionContext;
            data.AnswerContext   = model.AnswerContext;
            data.Inx = model.Inx;
            data.IsActive = model.IsActive; 
             
            data.ModDateTime = DateTime.UtcNow;
            faqRepository.Update(data);
            faqRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<FAQModel> model)
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
