using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class CourseMeetingBookletsComponent : IDisposable
    {
        private Repository<CourseMeetingBookletsModel> courseMeetingBookletsRepository;
        //======================================================
        public CourseMeetingBookletsComponent()
        {
            courseMeetingBookletsRepository = new Repository<CourseMeetingBookletsModel>();
        }
        //===================================================
        public IQueryable<CourseMeetingBookletsModel> Read(int CourseMeetingId)
        {
            var result = courseMeetingBookletsRepository.Where(c => c.CourseMeetingId == CourseMeetingId , c=> c.CourseMeeting , c=> c.ModUser);
            return result;
        }
        //=====================================================
        public void Add(CourseMeetingBookletsModel model)
        {
            model.FilePath = FileComponentProvider.Save(FileFolder.CourseMeetingBooklets, model.FilePath);
            courseMeetingBookletsRepository.Add(model);
            courseMeetingBookletsRepository.SaveChanges();
        }
        //===================================================
        public CourseMeetingBookletsModel Find(int Id)
        {
            var result = courseMeetingBookletsRepository.Where(c => c.Id == Id,c=> c.CourseMeeting).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(CourseMeetingBookletsModel model, int currentUserId)
        {
            var result = courseMeetingBookletsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.FilePath = FileComponentProvider.Save(FileFolder.CourseMeetingBooklets, model.FilePath);
            result.Title = model.Title;
            result.Description = model.Description;
            result.IsActive = model.IsActive;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            courseMeetingBookletsRepository.Update(result);
            courseMeetingBookletsRepository.SaveChanges();
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            courseMeetingBookletsRepository.Delete(c => Ids.Contains(c.Id));
            courseMeetingBookletsRepository.SaveChanges();
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
            courseMeetingBookletsRepository?.Dispose();
        }
        #endregion
    }
}
