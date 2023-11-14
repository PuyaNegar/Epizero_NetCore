using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
   public class SmsOptionsComponent : IDisposable
    {
        private Repository<SmsOptionsModel> smsOptionsRepository;
        //======================================================================== 
        public SmsOptionsComponent()
        {
            smsOptionsRepository = new Repository<SmsOptionsModel>();
        }
        //=========================================================================
        public IQueryable<SmsOptionsModel> Read()
        {
            var result = smsOptionsRepository.SelectAllAsQuerable();
            return result;
        }
        //========================================================================= 
        public void Update(SmsOptionsModel model)
        {
            //**********************************************
            var data = smsOptionsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این تنظیمات در سیستم موجود نمی باشد"); }
            var query = smsOptionsRepository.FirstOrDefault(c => c.Id != model.Id && c.Title == model.Title);
            if (query != null) { throw new Exception("این تنظیمات در سیستم موجود می باشد"); }
            //**********************************************
            data.IsActive = model.IsActive;
            data.Price = model.Price;
            smsOptionsRepository.Update(data);
            smsOptionsRepository.SaveChanges();

        }
        //==================================================================== 
        public SmsOptionsModel Find(int Id)
        {
            var result = smsOptionsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //===================================================================== 
        public void Delete(List<int> Ids)
        {
            smsOptionsRepository.Delete(c => Ids.Contains(c.Id));
            smsOptionsRepository.SaveChanges();
        }
        //========================================================================   
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
            smsOptionsRepository?.Dispose();
        }
        #endregion
    }
}
