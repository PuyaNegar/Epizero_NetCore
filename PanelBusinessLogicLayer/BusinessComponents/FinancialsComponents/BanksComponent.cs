using DataAccessLayer.Repositories; 
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Common.Functions;
using Common.Objects;
using DataModels.FinancialsModels;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class BanksComponent : IDisposable
    {
        private Repository<BanksModel> banksRepository;
        //============================================================
        public BanksComponent()
        {
            banksRepository = new Repository<BanksModel>();
        }
        //============================================================
        public void Add(BanksModel model)
        {
            banksRepository.Add(model);
            banksRepository.SaveChanges();
        }
        //============================================================
        public IQueryable<BanksModel> Read()
        {
            var result = banksRepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public void Update(BanksModel model)
        {
            var data = banksRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            data.ModUserId = model.ModUserId;
            data.Name = model.Name;
            data.ModDateTime = model.ModDateTime;
            banksRepository.Update(data);
            banksRepository.SaveChanges();
        }
        //============================================================
        public BanksModel Find(int Id)
        {
            var result = banksRepository.SingleOrDefault(c => c.Id == Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<BanksModel> model)
        {
            banksRepository.DeleteRange(model);
            banksRepository.SaveChanges();
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
            banksRepository?.Dispose();
        }
        #endregion
    }
}
