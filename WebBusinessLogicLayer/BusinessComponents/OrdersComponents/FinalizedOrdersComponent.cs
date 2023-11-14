using Common.Enums;
using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class FinalizedOrdersComponent : IDisposable
    {
        private Repository<OrdersModel> ordersRepository;
        private Repository<OrderDetailsModel> orderDetailsRepository;
        //==============================================================
        public FinalizedOrdersComponent()
        {
            ordersRepository = new Repository<OrdersModel>();
            orderDetailsRepository = new Repository<OrderDetailsModel>();
        }
        //==============================================================
        public IQueryable<FinalizedOrderReadViewModel> Read(int studentUserId)
        {
            var result = ordersRepository.Where(c => c.OrderStatusTypeId == (int)OrderStatusType.Finalized && c.StudentUserId == studentUserId, c => c.StudentUser, c => c.Invoices).OrderByDescending(c => c.RegDateTime)
                .Select(c => new FinalizedOrderReadViewModel()
                {
                    Id = c.Id,
                    UserName = c.StudentUser.UserName,
                    RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                    StudentUserId = c.StudentUserId.Value,
                    InvoiceNo = c.FinalInvoice.InvoiceNo,
                    PaymentAmount = c.PaymentAmount,
                    StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                });
            return result;
        }
        //======================================================
        List<OrderDetailsModel> Find(int OrderId, int studentUserId)
        {
            var result = orderDetailsRepository.Where(c => c.OrderId == OrderId && c.Order.StudentUserId == studentUserId, c => c.Order.Invoices, c => c.Order.StudentUser.StudentUserProfile, c => c.AcademyProductType).Select(c => new OrderDetailsModel()
            {
                Id = c.Id,
                OrderId = c.OrderId,

                AcademyProductName = c.AcademyProductName,
                DiscountPercent = c.DiscountPercent,
                DiscountCodeAmount = c.DiscountCodeAmount,
                Price = c.Price,
                AcademyProductTypeId = c.AcademyProductTypeId,
                AcademyProductType = new AcademyProductTypesModel() { Name = c.AcademyProductType.Name },
                Order = new OrdersModel()
                {
                    RegDateTime = c.Order.RegDateTime,
                    Id = c.OrderId,
                    StudentUserId = c.Order.StudentUserId,
                    DiscountCode = c.Order.DiscountCode,
                    PaymentAmount = c.Order.PaymentAmount,
                    SubTotal = c.Order.SubTotal,
                    FinalInvoice = c.Order.FinalInvoice,
                    StudentUser = new UsersModel() { UserName = c.Order.StudentUser.UserName, FirstName = c.Order.StudentUser.FirstName, LastName = c.Order.StudentUser.LastName },
                },
            }).ToList();
            return result;
        }
        //======================================================
        public FinalizedOrdersViewModel FindWithCalculations(int OrderId, int studentUserId)
        {
            var result = Find(OrderId, studentUserId);
            if (result == null || !result.Any())
                throw new Exception("سفارش یافت نشد");
            var Order = result.First().Order;
            var model = new FinalizedOrdersViewModel()
            {
                Id = Order.Id,
                InvoiceNo = Order.FinalInvoice.InvoiceNo,
                OrderRegDateTime = Order.RegDateTime.ToLocalDateTimeLongFormatString(),
                StudentUserFullName = string.Format("{0} {1}", Order.StudentUser.FirstName, Order.StudentUser.LastName),
                SubTotal = Order.SubTotal,
                PaymentAmount = Order.PaymentAmount,
                DiscountCode = Order.DiscountCode == null ? "ثبت نشده" : Order.DiscountCode.Code,
                UserName = Order.StudentUser.UserName,
                OrderDetails = result.Select(c => new FinalizedOrderDetailsViewModel()
                {
                    Id = c.Id,
                    AcademyProductName = c.AcademyProductName,
                    AcademyProductTypeName = c.AcademyProductType.Name,
                    Price = c.Price,
                    DiscountPercent = c.DiscountPercent,
                    FinalPrice = Convert.ToInt32( ((c.Price - (c.Price * c.DiscountPercent / 100)) - c.DiscountCodeAmount < 0) ? 0 : (c.Price - (c.Price * c.DiscountPercent / 100)) - c.DiscountCodeAmount),
                    PriceWithDiscount =Convert.ToInt32( c.Price - (c.Price * c.DiscountPercent / 100)),
                    DiscountCodeAmount = c.DiscountCodeAmount,
                }).ToList(),
            };
            model.SubTotal = model.OrderDetails.Sum(c => c.Price);
            model.TotalPriceWithDiscount = model.OrderDetails.Sum(c => c.PriceWithDiscount);
            model.TotalDiscountCodeAmount = model.OrderDetails.Sum(c => c.DiscountCodeAmount);
            return model;
        }
        //====================================== 
        #region DisposeObject
        public void Dispose()
        {
            orderDetailsRepository?.Dispose();
            ordersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
