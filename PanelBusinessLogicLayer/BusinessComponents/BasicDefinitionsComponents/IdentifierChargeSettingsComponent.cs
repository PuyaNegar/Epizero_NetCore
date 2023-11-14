using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
    public class IdentifierChargeSettingsComponent : IDisposable
    {
        private Repository<IdentifierChargeSettingsModel> identifierChargeSettingsRepository;
        //========================================
        public IdentifierChargeSettingsComponent()
        {
            identifierChargeSettingsRepository = new Repository<IdentifierChargeSettingsModel>();
        }
        //==============================================================================================
        public IQueryable<IdentifierChargeSettingsModel> Read()
        {
            var result = identifierChargeSettingsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IdentifierChargeSettingsModel Find()
        { 
            var data = identifierChargeSettingsRepository.SelectAllAsQuerable( ).First(); 
            return data;
        }
        //==============================================================================================
        public void Update(IdentifierChargeSettingsModel model)
        {

            var data = identifierChargeSettingsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null)
                throw new Exception("این اطلاعات در سیستم موجود نمی‌باشد");

            data.IsActive = model.IsActive;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = DateTime.UtcNow;
            data.IdentifierChargeAmount = model.IdentifierChargeAmount;
            data.RegisteredUserChargeAmount = model.RegisteredUserChargeAmount;
            identifierChargeSettingsRepository.Update(data);
            identifierChargeSettingsRepository.SaveChanges();
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            identifierChargeSettingsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
