using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;

namespace BusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class LessonsComponent
    {
        private Repository<LessonsModel> lessonsRepository;
        //============================================================
        public LessonsComponent()
        {
            lessonsRepository = new Repository<LessonsModel>();
        }
        //============================================================
        public void Add(LessonsModel model)
        {
            lessonsRepository.Add(model);
            lessonsRepository.SaveChanges();
        }
        //============================================================
        public IQueryable<LessonsModel> Read(int levelId, int? fieldId)
        {

            Expression<Func<LessonsModel, bool>> predicate = fieldId == null ?
            (Expression<Func<LessonsModel, bool>>)(c => c.LevelId == levelId) :
            (Expression<Func<LessonsModel, bool>>)(c => c.FieldId == fieldId && c.LevelId == levelId); 


            var result = lessonsRepository.Where(predicate).Select(c=> new LessonsModel()
            {
                Id = c.Id,
                LevelId = c.LevelId,
                Name = c.Name,
                FieldId = c.FieldId,
                UnitCount = c.UnitCount,
                Level = new LevelsModel() { Name = c.Level.Name },
                Field = new FieldsModel() { Id = c.Field.Id ,  Name = c.Field.Name },
            });
            return result;
        }
        //============================================================
        public void Update(LessonsModel model, int currentUserId)
        {
            var result = lessonsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            result.Name = model.Name;
            result.UnitCount = model.UnitCount;
            result.LevelId = model.LevelId;
            result.FieldId = model.FieldId;
            lessonsRepository.Update(result);
            lessonsRepository.SaveChanges();
        }
        //============================================================
        public LessonsModel Find(int id)
        {
            var result = lessonsRepository.Where(c => c.Id == id, c => c.Field, c => c.Level.LevelGroup).Select(c => new LessonsModel()
            {
                Id = c.Id,
                LevelId = c.LevelId,
                Name = c.Name,
                FieldId = c.FieldId,
                UnitCount = c.UnitCount,
                Level = new LevelsModel() { Name = c.Level.Name , LevelGroup = new LevelGroupsModel() { Name = c.Level.LevelGroup.Name} },
                Field = new FieldsModel() { Name = c.Field.Name },
            }).SingleOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<int> Ids)
        {
            lessonsRepository.Delete(c => Ids.Contains(c.Id));
            lessonsRepository.SaveChanges();
        }
        //=============================================================================== Disposing
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
            lessonsRepository?.Dispose();
        }
        #endregion

    }
}
