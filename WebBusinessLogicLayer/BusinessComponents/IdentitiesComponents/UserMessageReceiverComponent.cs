using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserMessageReceiverComponent : IDisposable
    {
        private Repository<MessageReceiverUsersModel> messageReceiverUsersRepository;
        private Repository<MessageTagsModel> messageTagsRepository;
        public UserMessageReceiverComponent()
        {
            messageReceiverUsersRepository = new Repository<MessageReceiverUsersModel>();
            messageTagsRepository = new Repository<MessageTagsModel>();
        }
        //======================================================
        public IQueryable<MessageReceiverUsersModel> Read(int userId, DateTime? startDate, DateTime? endDate, List<int> TagIds)
        {
            IQueryable<MessageReceiverUsersModel> query;
            query = messageReceiverUsersRepository.Where(c => c.UserId == userId, c => c.Message);
            if (TagIds.Count() > 0)
            {
                var messageIds = messageTagsRepository.Where(c => TagIds.Contains(c.TagId)).
                    Select(c => c.MessageId).ToList();
                query = query.Where(c => messageIds.Contains(c.MessageId));
            }
            if (startDate != null && endDate != null) 
                query = query.Where(r => r.Message.RegDateTime >= startDate && r.Message.RegDateTime <= endDate);
            return query;
        }
        //======================================================
        public int CountUnreadMessage(int userId)
        {
            var count = messageReceiverUsersRepository.Where(c => c.UserId == userId && !c.IsRead).Count();
            return count;
        }
        //======================================================
        public MessageReceiverUsersModel Update(int Id)
        {
            var result = messageReceiverUsersRepository.SingleOrDefault(c => c.Id == Id, c => c.Message);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (result.IsRead == false)
            {
                result.IsRead = true;
                result.ReadDateTime = DateTime.UtcNow;
                messageReceiverUsersRepository.Update(result);
                messageReceiverUsersRepository.SaveChanges();
            }
            return result;
        }
        //============================================================ Dispise
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
            messageReceiverUsersRepository?.Dispose();
        }
        #endregion
    }

}

