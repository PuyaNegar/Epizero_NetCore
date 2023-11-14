using Common.Extentions;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class SendSMSTargetsService
    {
        private SendSMSTargetsComponent sendSMSTargetsComponent { get; set; }
        //========================================================================================
        public SendSMSTargetsService()
        {
            this.sendSMSTargetsComponent = new SendSMSTargetsComponent();
        }
        //========================================================================================
        public SysResult Add(SendSMSTargetsViewModel viewModel, int CurrentUserId)
        { 
                var model = new SendSMSTargetsModel()
                {
                    Title = viewModel.Title,
                    MobNo = viewModel.MobNo,
                    IsActive = viewModel.IsActive.ToBoolean(),
                    ModUserId = CurrentUserId,
                    RegDateTime = DateTime.UtcNow,
                };
                sendSMSTargetsComponent.Add(model);
                return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };
        }
        //========================================================================================
        public SysResult<SendSMSTargetsViewModel> Find(int Id)
        { 
                var result = sendSMSTargetsComponent.Find(Id);
                //**********************************************
                var viewModel = new SendSMSTargetsViewModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    MobNo = result.MobNo,
                    IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                    IsActive = result.IsActive.ToActiveStatus(),
                };
                return new SysResult<SendSMSTargetsViewModel>() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };
        }
        //========================================================================================
        public SysResult Update(SendSMSTargetsViewModel viewModel, int modUserId)
        { 
                var model = new SendSMSTargetsModel()
                {
                    Id = viewModel.Id,
                    Title = viewModel.Title,
                    MobNo = viewModel.MobNo,
                    IsActive = viewModel.IsActive.ToBoolean(),
                    ModUserId = modUserId,
                    ModDateTime = DateTime.UtcNow
                };
                sendSMSTargetsComponent.Update(model);
                return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };
            
        }
        //========================================================================================
        public SysResult Read()
        { 
                var result = sendSMSTargetsComponent.Read();
                var viewModel = result.Select(c => new SendSMSTargetsViewModel()
                {
                    Id = c.Id,
                    MobNo = c.MobNo,
                    Title = c.Title,
                    IsActiveName = c.IsActive ? "فعال" : "غیر فعال"
                }).ToList();
                return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };
        }
        //========================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        { 
                //**********************************************  عملیات نگاشت
                var model = viewModel.Select(a => new SendSMSTargetsModel()
                {
                    Id = a.Id.Value
                }).ToList();
                sendSMSTargetsComponent.Delete(model);
                //**********************************************
                return new SysResult() { IsSuccess = true, Message = "عملیات حذف با موفقیت انجام شد" };
             
        }
        //========================================================================================Disposing
        #region DisposeObjects
        public void Dispose()
        {
            sendSMSTargetsComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
