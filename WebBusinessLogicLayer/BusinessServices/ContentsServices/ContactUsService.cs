using Common.Objects;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
   public class ContactUsService : IDisposable
    {
        private ContactUsComponent contactUsComponent;
        //=================================================================================
        public ContactUsService()
        {
            contactUsComponent = new ContactUsComponent();
        }
        //================================================================================= 
        public SysResult Add(ContactUsViewModel viewModel)
        {
            var model = new ContactUsModel()
            {
                Email = viewModel.Email,
                IsRead = false,
                FullName = viewModel.FullName,
                CourseId = viewModel.CoursesId,
                Description = viewModel.Description,
                MobNo = viewModel.MobNo,
                RegDateTime = DateTime.UtcNow,

            };
            contactUsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //====================================================================================================Disposing
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
            contactUsComponent?.Dispose();
        }
        #endregion
    }
}
