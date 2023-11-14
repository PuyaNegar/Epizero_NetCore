using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class LevelsComponent : IDisposable
    {
        private Repository<LevelsModel> levelsRepository;
        //====================================================================
        public LevelsComponent()
        {
            this.levelsRepository = new Repository<LevelsModel>();
        }
        //====================================================================
        public IQueryable<LevelsModel> ReadByLevelGroup(int LevelGroupId)
        {
            var result = levelsRepository.Where(c => c.LevelGroupId == LevelGroupId).OrderBy(c => c.Id);
            return result;
        }
        //============================================================
        public IQueryable<LevelsModel> Read()
        {
            var result = levelsRepository.Where(c=>c.IsActive);
            return result;
        } 
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            levelsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
