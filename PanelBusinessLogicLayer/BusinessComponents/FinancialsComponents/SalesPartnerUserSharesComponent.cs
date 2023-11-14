using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class SalesPartnerUserSharesComponent : IDisposable
    {
        private Repository<SalesPartnerUserSharesModel> salesPartnerUserSharesRepository;
        //============================================
        public SalesPartnerUserSharesComponent()
        {
            salesPartnerUserSharesRepository = new Repository<SalesPartnerUserSharesModel>();
        }
        //============================================
        public IQueryable<SalesPartnerUserSharesViewModel> Read(int salesPartnerUserId)
        {
            var result = salesPartnerUserSharesRepository.Where(c => c.SalePartnerUserId == salesPartnerUserId, c => c.OrderDetail.Order.StudentUser, c => c.OrderDetail.Order.DiscountCode, c => c.OrderDetail.Order.DiscountCode.SalesPartnerShareType).OrderByDescending(c=>c.RegDateTime)
                 .GroupBy(c => new
                 {
                     c.OrderDetail.Order.DiscountCodeId,
                     c.OrderDetail.OrderId,
                     c.OrderDetail.Order.DiscountCode.Code,
                     c.OrderDetail.Order.DiscountCode.SalesPartnerShareTypeId , 
                     SalesPartnerShareTypeName = c.OrderDetail.Order.DiscountCode.SalesPartnerShareType.Name,
                     c.OrderDetail.Order.StudentUser.FirstName,
                     c.OrderDetail.Order.StudentUser.LastName,
                     c.OrderDetail.Order.DiscountCode.SalePartnerIsPrePayment,
                     c.OrderDetail.Order.DiscountCode.SalePartnerAmountOrPercent,
                 })
                 .Select(c => new SalesPartnerUserSharesViewModel()
                 {
                     Id = c.Key.OrderId,
                     DiscountCode = c.Key.Code,
                     StudentFullName = c.Key.FirstName + " " + c.Key.LastName,
                     SalesPartnerShareTypeName = c.Key.SalesPartnerShareTypeName,
                     LessonsUsedCount = c.Count(),
                     SumOfSalePartnerShares = c.Sum(d => d.Amount),
                     SalePartnerAmountOrPercent = c.Key.SalePartnerAmountOrPercent.Value,
                     SalePartnerIsPrePayment =  c.Key.SalesPartnerShareTypeId == (int)SalesPartnerShareType.Amount ?  "---" :  c.Key.SalePartnerIsPrePayment.Value ? "قبل از اعمال تخفیف" : "بعد از اعمال تخفیف"
                 });
            return result;
        }
        //============================================
        public SalesPartnerUserSharesModel Find(int Id)
        {
            var result = salesPartnerUserSharesRepository.SingleOrDefault(c => c.Id == Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================
        #region DisposeObject
        public void Dispose()
        {
            salesPartnerUserSharesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
