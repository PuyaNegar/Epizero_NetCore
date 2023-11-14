using System;
using System.Linq;
using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.ContentsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.ContentManagementServices
{
    public class AboutUsService : IDisposable
    {
        private AboutUsComponent aboutUsComponent;
        //===============================================================================
        public AboutUsService()
        {
            aboutUsComponent = new AboutUsComponent();
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = aboutUsComponent.Read();
            var viewModel = result.Select(c => new AboutUsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<AboutUsViewModel> Find(int id)
        {
            var result = aboutUsComponent.Find(id);
            var viewModel = new AboutUsViewModel()
            {
                Id = result.Id,
                SubTitle = result.SubTitle,
                KeyWordsMetaTag = result.KeyWordsMetaTag,
                MetaDescription = result.MetaDescription,
                MetaTitle = result.MetaTitle,
                CanonicalHref = result.CanonicalHref,
                AltBannerPicPath = result.AltBannerPicPath,
                BannerPicPath = result.BannerPicPath,
             
                Title = result.Title,
            };
            return new SysResult<AboutUsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(AboutUsViewModel request, int currentUserId)
        {
            var model = new AboutUsModel()
            {
                Id = request.Id,
                ModDateTime = DateTime.UtcNow,
                Title = request.Title,
                SubTitle = request.SubTitle,
                MetaDescription = request.MetaDescription,
                MetaTitle = request.MetaTitle,
                CanonicalHref = request.CanonicalHref,
                KeyWordsMetaTag = request.KeyWordsMetaTag,
                BannerPicPath = request.BannerPicPath,
                AltBannerPicPath = request.AltBannerPicPath,
                ModUserId = currentUserId,
      
            };
            aboutUsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //================================================================
        public SysResult<AboutUsViewModel> FindDescription(int Id)
        {
            var result = aboutUsComponent.FindDescription(Id);
            var viewModel = new AboutUsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description
            };
            return new SysResult<AboutUsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================================
        public SysResult UpdateDescription(int Id, string Text, int CurrentUserId)
        {
            aboutUsComponent.UpdateDescription(Id, Text.CharacterAnalysis(), CurrentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
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
