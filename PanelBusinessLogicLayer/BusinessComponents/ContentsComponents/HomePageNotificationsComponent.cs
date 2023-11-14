using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class HomePageNotificationsComponent : IDisposable
    {
        private Repository<HomePageNotificationsModel> homePageNotificationsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public HomePageNotificationsComponent()
        {
            this.homePageNotificationsRepository = new Repository<HomePageNotificationsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<HomePageNotificationsModel> Read()
        {
            var result = homePageNotificationsRepository.SelectAllAsQuerable();
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public HomePageNotificationsModel Find()
        {
            var result = homePageNotificationsRepository.SelectAllAsQuerable().First();
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(HomePageNotificationsModel model)
        {
             
            var data = homePageNotificationsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این اطلاعات در سیستم موجود نمی‌باشد"); }

            data.PicPath = FileComponentProvider.Save(FileFolder.HomePageNotifications, model.PicPath);
            data.IsActive = model.IsActive;
            data.Link = model.Link;
            data.Description = model.Description;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = DateTime.UtcNow;
             
            homePageNotificationsRepository.Update(data);
            homePageNotificationsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing 
        #region DisposeObject
        public void Dispose()
        {
            homePageNotificationsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
