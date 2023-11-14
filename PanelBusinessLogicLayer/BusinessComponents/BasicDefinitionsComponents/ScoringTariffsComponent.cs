using Common.Extentions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class ScoringTariffsComponent :IDisposable
    {
        private Repository<ScoringTariffsModel> scoringTariffsRepository;
        //==============================================================================================
        public ScoringTariffsComponent()
        {
            this.scoringTariffsRepository = new Repository<ScoringTariffsModel>();
        }
        //==============================================================================================
        public IQueryable<ScoringTariffsModel> Read()
        {
            var result = scoringTariffsRepository.SelectAllAsQuerable();
            return result;
        } 
        //==============================================================================================
        public ScoringTariffsModel Find(int Id)
        {
            var result = scoringTariffsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(ScoringTariffsModel model)
        { 
            var data = scoringTariffsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) 
                throw new Exception(SystemCommonMessage.DataWasNotFound);   
            data.Score = model.Score;
            data.ModUserId = model.ModUserId; 
            data.ModDateTime = DateTime.UtcNow;
            scoringTariffsRepository.Update(data);
            scoringTariffsRepository.SaveChanges(); 
        } 
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            scoringTariffsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
