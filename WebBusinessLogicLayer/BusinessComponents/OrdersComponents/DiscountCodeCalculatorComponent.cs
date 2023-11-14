using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using WebViewModels.OrdersViewModel;
using System.Linq;
using Common.Enums;

namespace WebBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class DiscountCodeCalculatorComponent : IDisposable
    {
        private Repository<DiscountCodesModel> discountCodesRepository;
        private Repository<DiscountCodeAcademyProductsModel> discountCodeAcademyProductsRepository;
        private List<OrderDetailsViewModel> orderDetails;
        public DiscountCodeCalculatorComponent()
        {
            discountCodesRepository = new Repository<DiscountCodesModel>();
            discountCodeAcademyProductsRepository = new Repository<DiscountCodeAcademyProductsModel>();
        }
        //======================================  
        public void Calculate(List<OrderDetailsViewModel> _orderDetails, int discountCodeId)
        {
            var result = discountCodesRepository.SingleOrDefault(c => c.Id == discountCodeId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            _orderDetails = FilterOrderDetails(_orderDetails, result.Id);
            if (!result.IsUseableForDiscountAcademyProduct)
                orderDetails = _orderDetails.Where(c => c.DiscountPercent == 0).OrderByDescending(c => c.PriceWithDiscount).Take(result.NumberOfStudentCanBeUse).ToList();
            else
                orderDetails = _orderDetails.OrderByDescending(c => c.PriceWithDiscount).Take(result.NumberOfStudentCanBeUse).ToList();

            if (result.DiscountCodeTypeId == (int)DiscountCodeType.Amount)
                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.DiscountCodeAmount = result.AmountOrPercent;
                }
            else
                foreach (var orderDetail in orderDetails)
                {
                    var calculatedDiscountPrice = orderDetail.PriceWithDiscount * result.AmountOrPercent / 100;
                    orderDetail.DiscountCodeAmount = (calculatedDiscountPrice > result.MaxDiscountAmount) ? result.MaxDiscountAmount : calculatedDiscountPrice;
                }
        }
        //===================================================
        public int GetAcademyProductDiscountPrice(int orderDetailId)
        {
            var result = orderDetails.SingleOrDefault(c => c.Id == orderDetailId);
            if (result == null)
                return 0;
            return result.DiscountCodeAmount;

        }
        //=======================================================
        List<OrderDetailsViewModel> FilterOrderDetails(List<OrderDetailsViewModel> orderDetail, int discountCodeId)
        {
            var result = discountCodeAcademyProductsRepository.Where(c => c.DiscountCodeId == discountCodeId).ToList().Select(c =>    
                c.AcademyProductTypeId.ToString() + "-" +
                (c.OnlineExamId == null ? string.Empty : c.OnlineExamId.ToString()) +
                (c.CourseId == null ? string.Empty : c.CourseId.ToString()) +
                (c.CourseMeetingId == null ? string.Empty : c.CourseMeetingId.ToString()) +
                (c.ProductId == null ? string.Empty : c.ProductId.ToString())
             ).ToList();

            var model = orderDetail.Where(c => result.Contains(c.AcademyProductTypeId + "-" + c.AcademyProductId)).ToList();
            return model; 
        }

        //====================================== 
        #region DisposeObject
        public void Dispose()
        {
            discountCodesRepository?.Dispose();
            discountCodeAcademyProductsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
