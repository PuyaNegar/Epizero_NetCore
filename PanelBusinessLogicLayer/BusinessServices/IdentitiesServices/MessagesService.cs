using Common.Enums;
using Common.Objects;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class MessagesService : IDisposable
    {
        private MessagesComponent messagesComponent;
        //=================================================================================
        public MessagesService()
        {
            this.messagesComponent = new MessagesComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = messagesComponent.Read();
            var viewModel = result.Select(c => new MessagesViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Message = c.Message,
                StudentRecivedMessageCount = MessageTypes.Public == (MessageTypes)c.MessageTypeId ? "همه" : c.MessageReceiverUsers.Count().ToString(),
                MessageTypeId = c.MessageTypeId,
                MessageTypeName = c.MessageType.Name,
                TagsName =  c.TagsExpression
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(MessagesViewModel viewModel, int CurrentUserId)
        {
            viewModel.ReceiverUsersId = viewModel.ReceiverUsersId ?? new List<int>();
            viewModel.MessageTagsId = viewModel.MessageTagsId ?? new List<string>();
            var model = new MessagesModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Message = viewModel.Message,
                MessageTypeId = viewModel.MessageTypeId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            var ReceiverUsersModel = viewModel.ReceiverUsersId.Select(item => new MessageReceiverUsersModel()
            {
                UserId = Convert.ToInt32(item),
                ReadDateTime = null,
                IsRead = false,
                MessageId = model.Id
            }).ToList();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            var messageTagsModel = viewModel.MessageTagsId.Select(item => new MessageTagsModel
            {
                MessageId = model.Id,
                TagId = Convert.ToInt32(item),
                ModDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
                Inx = 1
            }).ToList();
            model.MessageTags = messageTagsModel;
            model.MessageReceiverUsers = ReceiverUsersModel;
            messagesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<MessagesViewModel> Find(int Id)
        {
            var result = messagesComponent.Find(Id);
            var _MessageTagsId = result.MessageTags.Select(c => c.TagId.ToString()).ToList<string>();
            var _ReceiverUsersId = result.MessageReceiverUsers.Select(c => c.UserId.ToString()).ToList<string>();
            var viewModel = new MessagesViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Message = result.Message,
                MessageTypeName = result.MessageType.Name,
                MessageTypeId = result.MessageTypeId,
                ReceiverUserIds = _ReceiverUsersId,
                MessageTagsId = _MessageTagsId
            };
            return new SysResult<MessagesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new MessagesModel()
            {
                Id = a.Id.Value,
            }).ToList();
            messagesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
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
            messagesComponent?.Dispose();
        }
        #endregion
    }
}
