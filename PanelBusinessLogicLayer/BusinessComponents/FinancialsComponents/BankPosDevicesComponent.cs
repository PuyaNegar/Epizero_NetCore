using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
   public class BankPosDevicesComponent : IDisposable
    {

        private Repository<BankPosDevicesModel> bankPosDevicesRepository;
        //============================================================
        public BankPosDevicesComponent()
        {
            bankPosDevicesRepository = new Repository<BankPosDevicesModel>();
        }
        //============================================================
        public IQueryable<BankPosDevicesModel> Read()
        {
            var result = bankPosDevicesRepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public void Add(BankPosDevicesModel model)
        {
            bankPosDevicesRepository.Add(model);
            bankPosDevicesRepository.SaveChanges();
        }
        //============================================================
        public void Update(BankPosDevicesModel model)
        {
            var data = bankPosDevicesRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            data.AccountNo = model.AccountNo;
            data.BankId = model.BankId;
            data.Description = model.Description;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = model.ModDateTime;
            bankPosDevicesRepository.Update(data);
            bankPosDevicesRepository.SaveChanges();
        }
        //============================================================
        public BankPosDevicesModel Find(int Id)
        {
            var result = bankPosDevicesRepository.SingleOrDefault(c => c.Id == Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<BankPosDevicesModel> model)
        {
            bankPosDevicesRepository.DeleteRange(model);
            bankPosDevicesRepository.SaveChanges();
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
            bankPosDevicesRepository?.Dispose();
        }
        #endregion
    }
}
