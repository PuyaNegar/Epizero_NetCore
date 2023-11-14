using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class SalesPartnerUserOptionsComponent : IDisposable
    {
        private Repository<SalesPartnerUserOptionsModel> salesPartnerUserOptionsRepository;
        //===============================================================================
        public SalesPartnerUserOptionsComponent()
        {
            salesPartnerUserOptionsRepository = new Repository<SalesPartnerUserOptionsModel>();
        }
        //===============================================================================
        public void Add(SalesPartnerUserOptionsModel model)
        {
            var result = salesPartnerUserOptionsRepository.SingleOrDefault(c => c.SalesPartnerUserId == model.SalesPartnerUserId && c.CourseId == model.CourseId);
            if (result != null)
                throw new CustomException("سهم همکار فروش این کاربر قبلا در بانک اطلاعاتی ثبت شده است");
            salesPartnerUserOptionsRepository.Add(model);
            salesPartnerUserOptionsRepository.SaveChanges();
        }

        //===============================================================================
        public SalesPartnerUserOptionsModel Find(int id)
        {
            var result = salesPartnerUserOptionsRepository.SingleOrDefault(c => c.Id == id , c=>c.Course);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        } 
        //===============================================================================
        public IQueryable<SalesPartnerUserOptionsModel> Read(int salePartnerUsersId)
        {
            var result = salesPartnerUserOptionsRepository.Where(c=>c.SalesPartnerUserId == salePartnerUsersId , c=>c.Course);
            return result;
        }
        //===============================================================================
        public void Update(SalesPartnerUserOptionsModel model)
        {
            var result = salesPartnerUserOptionsRepository.SingleOrDefault(c => c.Id == model.Id  );
            if (result == null) { throw new Exception(SystemCommonMessage.DataWasNotFound); }

            result.SalesPartnerUserId = model.SalesPartnerUserId;
            result.SalePartnerIsPrepayment = model.SalePartnerIsPrepayment;
            result.Amount = model.Amount;
            result.Percent = model.Percent; 
            salesPartnerUserOptionsRepository.Update(result);
            salesPartnerUserOptionsRepository.SaveChanges();
        }
        //=====================================================================
        public void Delete(List<SalesPartnerUserOptionsModel> model)
        {
            salesPartnerUserOptionsRepository.DeleteRange(model);
            salesPartnerUserOptionsRepository.SaveChanges();
        } 
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            salesPartnerUserOptionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
