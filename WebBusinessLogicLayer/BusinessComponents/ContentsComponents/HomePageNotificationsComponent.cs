using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
  public  class HomePageNotificationsComponent : IDisposable
    {
        Repository<HomePageNotificationsModel> homePageNotificationsRepository;
        //==========================================
        public HomePageNotificationsComponent()
        {
            this.homePageNotificationsRepository = new Repository<HomePageNotificationsModel>();
        }
        //==========================================
        public HomePageNotificationsViewModel Read()
        {
            var CdnUrl = AppConfigProvider.CdnUrl();
            var result = homePageNotificationsRepository.SingleOrDefault(c=> c.IsActive);
            if (result == null)
               return null;
            var model = new HomePageNotificationsViewModel()
            {
                Description = result.Description,
                Link = result.Link,
                PicPath = string.IsNullOrEmpty(result.PicPath) ? string.Empty : CdnUrl + result.PicPath
            };
            return model;
        }
        //============================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            homePageNotificationsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
