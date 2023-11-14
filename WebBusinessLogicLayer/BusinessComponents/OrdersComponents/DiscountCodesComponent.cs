using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OrdersModels;
using System;

namespace WebBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class DiscountCodesComponent : IDisposable
    {
        private Repository<OrdersModel> ordersRepository; 
        //====================================================
        public DiscountCodesComponent()
        {
            ordersRepository = new Repository<OrdersModel>(); 
        }
        //====================================================
        public void AppendToOrder(string code, int? studentUserId, int orderId)
        { 
                int discountCodeId = ValidateDiscountCode(code, studentUserId);
                var result = ordersRepository.SingleOrDefault(c => c.Id == orderId && c.OrderStatusTypeId != (int)OrderStatusType.Finalized);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                result.DiscountCodeId = discountCodeId;
                result.ModDateTime = DateTime.UtcNow;
                ordersRepository.Update(result);
                ordersRepository.SaveChanges(); 
        }
        //===========================================================
        public void DeleteFromOrder(int orderId )
        {
            var result = ordersRepository.SingleOrDefault(c => c.Id == orderId);
            if (result == null)
                throw new CustomException("کد تخفیف یافت نشد");

            result.DiscountCodeId = (int?) null ;
            result.ModDateTime = DateTime.UtcNow;
            ordersRepository.Update(result);
            ordersRepository.SaveChanges();
        }
        //===========================================================
        int ValidateDiscountCode(string code, int? studentUserId)
        {
            int discountCodeId;
            using (var discountCodeValidationsComponent = new DiscountCodeValidationsComponent())
            {
                discountCodeId = discountCodeValidationsComponent.Validate(code, studentUserId);
            } 
            return discountCodeId;
        } 
        //====================================== 
        #region DisposeObject
        public void Dispose()
        {
            ordersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
