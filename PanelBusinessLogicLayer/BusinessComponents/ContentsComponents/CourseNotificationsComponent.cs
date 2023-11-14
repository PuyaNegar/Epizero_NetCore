using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class CourseNotificationsComponent : IDisposable
    {
        MainDBContext mainDBContext;
        private Repository<CourseNotificationsModel> courseNotificationsRepository;
        private Repository<NotificationsModel> notificationsRepository;
        //============================================================
        public CourseNotificationsComponent()
        {
            mainDBContext = new MainDBContext();
            courseNotificationsRepository = new Repository<CourseNotificationsModel>(mainDBContext);
           notificationsRepository = new Repository<NotificationsModel>(mainDBContext);
        }
        //============================================================
        public void Add(NotificationsModel model)
        {
            notificationsRepository.Add(model);
            notificationsRepository.SaveChanges();
        }
        //============================================================
        public IQueryable<NotificationsModel> Read()
        {
            var result = notificationsRepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public NotificationsModel Find(int id)
        {
            var result = notificationsRepository.SingleOrDefault(c => c.Id == id, c => c.CourseNotifications);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Update(NotificationsModel model)
        {
             
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var data = notificationsRepository.SingleOrDefault(c => c.Id == model.Id);
                    if (data == null) { throw new Exception("این رکورد در سیستم موجود نمی باشد"); }
                    //*********************************************
                    data.Title = model.Title;
                    data.Description = model.Description;
                    data.FromDate = model.FromDate;
                    data.ToDate = model.ToDate;
                    data.IsActive = model.IsActive;
                    data.CourseNotifications = model.CourseNotifications;
                    data.ModDateTime = DateTime.UtcNow;
                    data.CourseNotifications = model.CourseNotifications;

                    courseNotificationsRepository.Delete(c => c.NotificationId == model.Id);
                    courseNotificationsRepository.SaveChanges();
                 
                    notificationsRepository.Update(data);
                    notificationsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //============================================================
 

        public void Delete(List<NotificationsModel> model)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var list = model.Select(c => c.Id).ToList();
                    courseNotificationsRepository.Delete(c => list.Contains(c.NotificationId));
                    courseNotificationsRepository.SaveChanges();
                    notificationsRepository.Delete(c => list.Contains(c.Id));
                    notificationsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }
        //============================================================================
        public NotificationsModel FindDescription(int Id)
        {
            var result = notificationsRepository.Where(c => c.Id == Id).Select(c => new NotificationsModel()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description
            }).SingleOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //================================================================================
        public void UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            var data = notificationsRepository.SingleOrDefault(c => c.Id == Id);
            if (data == null)
                throw new Exception(SystemCommonMessage.DataWasNotFound);

            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = CurrentUserId;
            data.Description = Description;
            notificationsRepository.Update(data);
            notificationsRepository.SaveChanges();
        }
        //============================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseNotificationsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
