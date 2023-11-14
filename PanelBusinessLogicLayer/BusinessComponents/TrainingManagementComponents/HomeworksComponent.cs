using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class HomeworksComponent : IDisposable
    {
        private Repository<HomeworksModel> homeworksRepository;
        //======================================================
        public HomeworksComponent()
        {
            homeworksRepository = new Repository<HomeworksModel>();
        }
        //===================================================
        public IQueryable<HomeworksModel> Read(int CourseMeetingId)
        {
            var result = homeworksRepository.Where(c => c.CourseMeetingId == CourseMeetingId, c => c.CourseMeeting);
            return result;
        }
        //=====================================================
        public void Add(HomeworksModel model)
        {
            model.FilePath = FileComponentProvider.Save(FileFolder.HomeworkFiles, model.FilePath);
            homeworksRepository.Add(model);
            homeworksRepository.SaveChanges();
        }
        //===================================================
        public HomeworksModel Find(int Id)
        {
            var result = homeworksRepository.Where(c => c.Id == Id, c => c.CourseMeeting).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(HomeworksModel model, int currentUserId)
        {
            var result = homeworksRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.FilePath = FileComponentProvider.Save(FileFolder.HomeworkFiles, model.FilePath);
            result.Title = model.Title;
            result.Description = model.Description;
            result.CourseMeetingId = model.CourseMeetingId;
            result.IsActive = model.IsActive;
            result.ExpiredDate= model.ExpiredDate;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            homeworksRepository.Update(result);
            homeworksRepository.SaveChanges();
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            homeworksRepository.Delete(c => Ids.Contains(c.Id));
            homeworksRepository.SaveChanges();
        }
        
        //=================================================== Disposing
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
            homeworksRepository?.Dispose();
        }
        #endregion
    }
}
