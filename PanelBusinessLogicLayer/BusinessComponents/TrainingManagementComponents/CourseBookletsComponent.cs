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
    public class CourseBookletsComponent : IDisposable
    {
        private Repository<CourseBookletsModel> courseBookletsRepository;
        //======================================================
        public CourseBookletsComponent()
        {
            courseBookletsRepository = new Repository<CourseBookletsModel>();
        }
        //===================================================
        public IQueryable<CourseBookletsModel> Read(int CourseMeetingId)
        {
            var result = courseBookletsRepository.Where(c => c.CourseId == CourseMeetingId, c => c.Courses ,c=> c.ModUser);
            return result;
        }
        //=====================================================
        public void Add(CourseBookletsModel model)
        {
            if (!string.IsNullOrEmpty(model.FilePath))
                model.FilePath = FileComponentProvider.Save(FileFolder.CourseMeetingBooklets, model.FilePath);
           
            courseBookletsRepository.Add(model);
            courseBookletsRepository.SaveChanges();
        }
        //===================================================
        public CourseBookletsModel Find(int Id)
        {
            var result = courseBookletsRepository.Where(c => c.Id == Id, c => c.Courses).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(CourseBookletsModel model, int currentUserId)
        {
            var result = courseBookletsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (!string.IsNullOrEmpty(model.FilePath))
                result.FilePath = FileComponentProvider.Save(FileFolder.CourseMeetingBooklets, model.FilePath);
            result.Title = model.Title;
            result.EmbedLink = model.EmbedLink;
            result.Description = model.Description;
            result.IsActive = model.IsActive;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            courseBookletsRepository.Update(result);
            courseBookletsRepository.SaveChanges();
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            courseBookletsRepository.Delete(c => Ids.Contains(c.Id));
            courseBookletsRepository.SaveChanges();
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
            courseBookletsRepository?.Dispose();
        }
        #endregion
    }
}
