using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class SendSMSTargetsComponent : IDisposable
    {
        Repository<SendSMSTargetsModel> sendSMSTargetsRepository;
        //==============================================================================================
        public SendSMSTargetsComponent()
        {
            sendSMSTargetsRepository = new Repository<SendSMSTargetsModel>();
        }
        //==============================================================================================
        public void Add(SendSMSTargetsModel model)
        {
            var query = sendSMSTargetsRepository.FirstOrDefault(c => c.MobNo == model.MobNo);
            if (query != null) { throw new Exception("این شماره موبایل قبلاً ثبت شده است"); }
            //**********************************************
            var data = new SendSMSTargetsModel()
            {
                Title = model.Title,
                MobNo = model.MobNo,
                IsActive = model.IsActive,
                ModUserId = model.ModUserId,
                RegDateTime = model.RegDateTime
            };
            sendSMSTargetsRepository.Add(data);
            sendSMSTargetsRepository.SaveChanges();
        }
        //==============================================================================================
        public IQueryable<SendSMSTargetsModel> Read()
        {
            var result = sendSMSTargetsRepository.SelectAllAsQuerable().Select(c => new SendSMSTargetsModel()
            {
                Id = c.Id,
                Title = c.Title,
                MobNo = c.MobNo,
                IsActive = c.IsActive
            }).OrderBy(s => s.Id);
            return result;
        }
        //==============================================================================================
        public void Update(SendSMSTargetsModel model)
        {
            //**********************************************
            var data = sendSMSTargetsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("شناسه مورد نظر در سیستم موجود نمی‌باشد"); }
            var query = sendSMSTargetsRepository.FirstOrDefault(c => c.Id != model.Id && (c.MobNo == model.MobNo));
            if (query != null) { throw new Exception("این شماره موبایل قبلاً ثبت شده است"); }
            //**********************************************
            data.Title = model.Title;
            data.MobNo = model.MobNo;
            data.IsActive = model.IsActive;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = model.ModDateTime;
            sendSMSTargetsRepository.Update(data);
            sendSMSTargetsRepository.SaveChanges();
        }
        //================================================================================
        public SendSMSTargetsModel Find(int Id)
        {
            var result = sendSMSTargetsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //================================================================================
        public void Delete(List<SendSMSTargetsModel> model)
        {
            sendSMSTargetsRepository.DeleteRange(model);
            sendSMSTargetsRepository.SaveChanges();
        }
        //================================================================================= Disposing 
        #region DisposeObject
        public void Dispose()
        {
            sendSMSTargetsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
       

    }
}
