using Common.Extentions;
using Common.Objects;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
   public class UserMessageReceiverService :IDisposable
    {
        private UserMessageReceiverComponent userMessagesComponent;
        public UserMessageReceiverService()
        {
            this.userMessagesComponent = new UserMessageReceiverComponent();
        }
        //===================================================================================================
        public SysResult<List<UserMessagesViewModel>> Read(int userId , UserMessageReceiverRequestFilterViewModel viewModel)
        {

            DateTime? startDate = string.IsNullOrEmpty(viewModel.StartDate) ?  (DateTime?) null : viewModel.StartDate.CharacterAnalysis().ToDate().ToUtcDateTime();
            DateTime? endDate = string.IsNullOrEmpty(viewModel.EndDate) ? (DateTime?) null : viewModel.EndDate.CharacterAnalysis().ToDate().ToUtcDateTime();
            if (startDate > endDate)
                throw new Exception("تاریخ شروع نمی تواند از تاریخ پایان بزرگتر باشد");
            var tagIds = viewModel.TagIds.Select(item => new TagsModel
            {
                Id = Convert.ToInt32(item),
            }).Select(c=> c.Id).ToList<int>();
           
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            var model = userMessagesComponent.Read(userId, startDate, endDate, tagIds)
                .OrderByDescending(c => c.Message.RegDateTime);
              var f =  model.Select(c => new UserMessagesViewModel()
            {
                Id = c.Id,
                Message = c.Message.Message,
                Title = c.Message.Title,
                RegDateTime = c.Message.RegDateTime.ToLocalDateTimeLongFormatString(),
                IsRead = c.IsRead,
                ReadDateTime =(c.ReadDateTime != null) ? c.ReadDateTime.Value.ToLocalDateTimeLongFormatString() : null
            }).ToList();
            return new SysResult<List<UserMessagesViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = f };
        }
        //===================================================================================================
        public SysResult<UserMessagesViewModel> Update(int Id)
        {
            var result = userMessagesComponent.Update(Id);
            return new SysResult<UserMessagesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully };
        }
        //==================================================================================================
        public SysResult<int> CountUnreadMessage(int userId) 
        {
            var result = userMessagesComponent.CountUnreadMessage(userId);
            return new SysResult<int>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //==================================================================================================== Dispise
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
                userMessagesComponent?.Dispose();
                return;
            }
        }
        #endregion
    }
}
