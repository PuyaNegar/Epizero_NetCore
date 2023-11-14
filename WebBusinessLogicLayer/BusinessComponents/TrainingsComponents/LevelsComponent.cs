using System;
using System.Linq;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class LevelsComponent:IDisposable
    {
        private Repository<LevelsModel> levelsRepository;
        //============================================================
        public LevelsComponent()
        {
            levelsRepository = new Repository<LevelsModel>();
        } 
        //============================================================
        public IQueryable<LevelsModel> Read()
        {
            var result = levelsRepository.Where(c=>c.IsActive);
            return result;
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
            levelsRepository?.Dispose();
        }
        #endregion
    }
}
