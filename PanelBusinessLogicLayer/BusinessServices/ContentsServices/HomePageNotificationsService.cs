using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class HomePageNotificationsService : IDisposable
    {
        private HomePageNotificationsComponent homePageNotificationsComponent;
        public HomePageNotificationsService()
        {
            this.homePageNotificationsComponent = new HomePageNotificationsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read()
        {
            var result = homePageNotificationsComponent.Read();
            var viewModel = result.Select(c => new HomePageNotificationsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                Link = c.Link,
                Description = c.Description
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<HomePageNotificationsViewModel> Find()
        {
            var result = homePageNotificationsComponent.Find();
            var viewModel = new HomePageNotificationsViewModel()
            {
                Id = result.Id,
                Description = result.Description,
                PicPath = result.PicPath,
                IsActive = result.IsActive.ToActiveStatus(),
                Link = result.Link
            };
            return new SysResult<HomePageNotificationsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value=viewModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(HomePageNotificationsViewModel viewModel, int UserId)
        {
            var model = new HomePageNotificationsModel()
            {
                ModUserId = UserId,
                Id = viewModel.Id,
                Description = viewModel.Description,
                Link = viewModel.Link,
                IsActive = viewModel.IsActive.ToBoolean(),
                PicPath = viewModel.PicPath
            };
            homePageNotificationsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObjects
        public void Dispose()
        {
            homePageNotificationsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
