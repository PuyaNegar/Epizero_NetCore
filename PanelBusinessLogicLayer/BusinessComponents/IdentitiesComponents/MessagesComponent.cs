using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataAccessLayer.StoredProcedures;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class MessagesComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<MessagesModel> messagesRepository;
        public MessagesComponent()
        {
            mainDBContext = new MainDBContext();
            this.messagesRepository = new Repository<MessagesModel>(mainDBContext);
        }
        //===============================================================================
        public IQueryable<MessagesModel> Read()
        {
            var result = messagesRepository.SelectAllAsQuerable(c => c.MessageReceiverUsers, c => c.MessageType , c=> c.MessageTags);
            return result;
        }
        //===============================================================================
        public void Add(MessagesModel model)
        {
            messagesRepository.Add(model);
            messagesRepository.SaveChanges();
            MessageTagsExpressionCreatorProcedure.Execute(model.Id);
        }
        //===============================================================================
        public MessagesModel Find(int Id)
        {
            var result = messagesRepository.FirstOrDefault(c => c.Id == Id, c => c.MessageReceiverUsers,c=> c.MessageTags, c => c.MessageType);
            return result;
        }
        //==============================================================================
        public void Delete(List<MessagesModel> model)
        {
           
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var messageReceiverUsersRepository = new Repository<MessageReceiverUsersModel>(mainDBContext))
                    {
                        messageReceiverUsersRepository.Delete(c => model.Select(c => c.Id).Contains(c.MessageId));
                        messageReceiverUsersRepository.SaveChanges();
                    }
                    messagesRepository.Delete(c=> model.Select(c => c.Id).Contains(c.Id));
                    messagesRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(SystemCommonMessage.OperationStoppedByError);
                }
            } 
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            messagesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
