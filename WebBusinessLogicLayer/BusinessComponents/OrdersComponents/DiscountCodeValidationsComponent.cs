using Common.Enums;
using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class DiscountCodeValidationsComponent : IDisposable
    {
        private Repository<DiscountCodesModel> discountCodesRepository;
        public DiscountCodeValidationsComponent()
        {
            discountCodesRepository = new Repository<DiscountCodesModel>();
        }
        //========================================= 
        public int Validate(string code , int?  studentUserId )
        {
            var result = discountCodesRepository.FirstOrDefault(c => c.Code == code && c.IsActive);
            if (result == null)
                throw new CustomException("کد تخفیف یافت نشد");
            var dateTime = DateTime.UtcNow;
            if (result.StartDate > dateTime)
                throw new CustomException("زمان استفاده از کد تخفیف آغاز نشده است");
            if (result.EndDate != null && result.EndDate < dateTime)
                throw new CustomException("کد تخفیف منقضی شده است");
            if (UsedDiscountCodeCount(code) >= result.NumberOfTotalUse)
                throw new CustomException("حد نصاب استفاده از این کد تکمیل شده است");
            if (!IsStudentAbleToUseCode(code, studentUserId))
                throw new CustomException("شما قبلا از این کد تخفیف استفاده نموده اید");
            return result.Id; 
        }
        //========================================================
        int UsedDiscountCodeCount(string code)
        {
            using (var orderRepository = new Repository<OrdersModel>())
            {
                var result = orderRepository.Where(c => c.OrderStatusTypeId == (int)OrderStatusType.Finalized && c.DiscountCode.Code == code).Count();
                return result;
            }
        }
        //========================================================
        bool IsStudentAbleToUseCode (string code , int?  studentUserId)
        {
            if (studentUserId == null)
                return true;
            using (var a = new Repository<OrdersModel>())
            {
                var result = a.Where(c => c.OrderStatusTypeId == (int)OrderStatusType.Finalized && c.DiscountCode.Code == code && c.StudentUserId == studentUserId.Value  ).Any();
                return !result;
            }
        }
        //====================================== 
        #region DisposeObject
        public void Dispose()
        { 
            discountCodesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
