using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
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
        public SysResult Read()
        {
            var result = contactUsComponent.Read();
            var viewmodel = result.OrderByDescending(c=> c.RegDateTime).Select(c => new ContactUsViewModel()
            {
                Id = c.Id,
                CourseName = c.CourseId != null ? c.Course.Name : string.Empty,
                Description = c.Description,
                FullName = c.FullName,
                Email =string.IsNullOrEmpty(c.Email)? "ثبت نشده" : c.Email,
                MobNo = c.MobNo,
                IsReadName = c.IsRead ? "بلی" : "خیر",
                RegDateTime = c.RegDateTime.ToLocalDateTime().ToLocalDateTimeLongFormatString(),
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewmodel };

        }
        //=================================================================================
        public SysResult Update(ContactUsViewModel viewModel)
        {
            var model = new ContactUsModel()
            {
                Id = viewModel.Id,
                IsRead = viewModel.IsRead.ToBoolean(),
            };
            contactUsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult<ContactUsViewModel> Find(int Id)
        {
            var result = contactUsComponent.Find(Id);
            var viewModel = new ContactUsViewModel()
            {
                Id = result.Id,
                CourseName = result.CourseId != null ?  result.Course.Name : string.Empty,
                Description = result.Description,
                Email = result.Email,
                MobNo = result.MobNo,
                IsRead = result.IsRead.ToActiveStatus(),
                FullName = result.FullName,
            };
            return new SysResult<ContactUsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new ContactUsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            contactUsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //========================================================================== 
        public SysResult SendSms(StudentCustomSmsViewModel viewModel)
        {
            CourseStudentCustomSmsComponent.Operation(viewModel.MobNo, viewModel.Message);
            return new SysResult() { IsSuccess = true, Message = "پیامک با موفقیت به دانش آموزان ارسال گردید" };
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
