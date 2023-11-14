using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels; 
using PanelBusinessLogicLayer.UtilityComponent;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class SlidersComponent : IDisposable
    {
        private Repository<SlidersModel> slidersRepository;
        public SlidersComponent()
        {
            this.slidersRepository = new Repository<SlidersModel>();
        }
        //==============================================================================================
        public IQueryable<SlidersModel> Read()
        {
            var result = slidersRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(SlidersModel model)
        {
            model.PicPath = FileComponentProvider.Save(FileFolder.Sliders, model.PicPath);
            slidersRepository.Add(model);
            slidersRepository.SaveChanges();
        }
        //==============================================================================================
        public SlidersModel Find(int Id)
        {
            var result = slidersRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(SlidersModel model)
        {
            //**********************************************
            var data = slidersRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.Title = model.Title;
            data.Alt = model.Alt;
            data.Link = model.Link;
            data.IsActive = model.IsActive;
            data.Description = model.Description;
            data.PicPath = FileComponentProvider.Save(FileFolder.Sliders, model.PicPath);
            data.ModDateTime = DateTime.UtcNow;
            slidersRepository.Update(data);
            slidersRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<SlidersModel> model)
        {
            slidersRepository.DeleteRange(model);
            slidersRepository.SaveChanges();
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
            slidersRepository?.Dispose();
        }
        #endregion
    }
}
