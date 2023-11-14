using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
    public class BaseInfosComponent : IDisposable
    {
        private Repository<BaseInfosModel> baseInfosRepository; 
        //==============================================================================================
        public BaseInfosComponent()
        { 
            this.baseInfosRepository = new Repository<BaseInfosModel>();
        }
        //============================================================================================== 
        public IQueryable< BaseInfosModel> Read()
        {
            var result = baseInfosRepository.SelectAllAsQuerable() ;
            return result;
        }
        //==============================================================================================
        public BaseInfosModel Find()
        {
            var result = baseInfosRepository.SelectAllAsQuerable().First();
            return result;
        } 
        //==============================================================================================
        public void Update(BaseInfosModel model, int currentUserId)
        { 
            var data = baseInfosRepository.SelectAllAsQuerable().First();
            if (data == null) { throw new CustomException("این اطلاعات در سیستم موجود نمی‌باشد"); } 
            data.EpizeroCoinPrice = model.EpizeroCoinPrice; 
            data.ModUserId = currentUserId;
            data.ModDateTime = DateTime.UtcNow;
            baseInfosRepository.Update(data);
            baseInfosRepository.SaveChanges();
        }  
        //============================================================================================== Disposing 
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
            baseInfosRepository?.Dispose();
        }
        #endregion
    }
}
