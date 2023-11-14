using System;
using System.Collections.Generic;
using System.Linq;
using Common.Functions;
using Common.Objects;
 
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class AboutUsService : IDisposable
    {
        private AboutUsComponent aboutUsComponent;
        //============================================================
        public AboutUsService()
        {
            aboutUsComponent = new AboutUsComponent();
        }
        //===============================================================================
        public SysResult<AboutUsViewModel> Read()
        {
            var result = aboutUsComponent.Read();
            var viewModel = new AboutUsViewModel();
            var cdnUrl = AppConfigProvider.CdnUrl();
            if (result != null)
            {
                viewModel = new AboutUsViewModel()
                {
                    Id = result.Id,
                    SubTitle = result.SubTitle,
                    AltBannerPicPath = result.AltBannerPicPath,
                    Title = result.Title,
                    Description = result.Description,
                    BannerPicPath = string.IsNullOrEmpty(result.BannerPicPath) ? string.Empty : cdnUrl + result.BannerPicPath,
                };
            }
            else
                viewModel = null;
            return new SysResult<AboutUsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
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
            aboutUsComponent?.Dispose();
        }
        #endregion
    }
}
