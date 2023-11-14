using System;
using System.Linq;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class AboutUsComponent : IDisposable
    {
        private Repository<AboutUsModel> aboutUsrepository;
        //============================================================
        public AboutUsComponent()
        {
            aboutUsrepository = new Repository<AboutUsModel>();
        }
        //============================================================
        public AboutUsModel Read()
        {
            var result = aboutUsrepository.SelectAllAsQuerable().First();
            return result;
        }
        //============================================================
        public static AboutUsModel Find()
        {
            using (var aboutUsrepository = new Repository<AboutUsModel>())
            {
                var result = aboutUsrepository.SelectAllAsQuerable().First();
                result.BannerPicPath = AppConfigProvider.CdnUrl() + result.BannerPicPath;
                return result;
            }

        }
        //=============================================================================== Disposing
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
            aboutUsrepository?.Dispose();
        }
        #endregion
    }
}
