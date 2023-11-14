using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
  public class LevelGroupsComponent : IDisposable
    {

        private Repository<LevelGroupsModel> levelGroupsRepository;
        //====================================================================
        public LevelGroupsComponent()
        {
            this.levelGroupsRepository = new Repository<LevelGroupsModel>();
        }
        //====================================================================
        public IQueryable<LevelGroupsModel> Read()
        {
            var result = levelGroupsRepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public LevelGroupsModel Find(int id)
        {
            var result = levelGroupsRepository.SingleOrDefault(c => c.Id == id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Update(LevelGroupsModel model)
        {
            var result = levelGroupsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            result.Description = model.Description;
            levelGroupsRepository.Update(result);
            levelGroupsRepository.SaveChanges();
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            levelGroupsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
