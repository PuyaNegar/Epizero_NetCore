using Common.Enums;
using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using DataModels.TrainingManagementModels;
using PanelViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OrdersComponents
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
        public IQueryable<FinalizedOrderReadViewModel> Read()
        {
            var result = orderDetailsRepository.Where(c => c.Order.OrderStatusTypeId == (int)OrderStatusType.Finalized, c => c.Order.StudentUser, c => c.Order.FinalInvoice, c => c.AcademyProductType)
                .OrderByDescending(c => c.Order.RegDateTime)
                .Select(c => new FinalizedOrderReadViewModel()
                {
                    Id = c.Order.Id,
                    UserName = c.Order.StudentUser.UserName,
                    RegDateTime = c.Order.RegDateTime.ToLocalDateTimeLongFormatString(),
                    StudentUserId = c.Order.StudentUserId.Value,
                    InvoiceNo = c.Order.FinalInvoice.InvoiceNo,
                    PaymentAmount = c.Order.PaymentAmount,
                    StudentUserFullName = c.Order.StudentUser.FirstName + " " + c.Order.StudentUser.LastName,
                    AcademyProductTypeName = c.AcademyProductType.Name,
                    DiscountCodeAmount = c.DiscountCodeAmount,
                    AcademyProductName = c.AcademyProductName,
                });
            return result;
        }
        //======================================================
        List<OrderDetailsModel> Find(int OrderId)
        {
            var result = orderDetailsRepository.Where(c => c.OrderId == OrderId, c => c.Order.Invoices, c => c.Order.StudentUser.StudentUserProfile, c => c.AcademyProductType).Select(c => new OrderDetailsModel()
            {
                Id = c.Id,
                OrderId = c.OrderId,
                AcademyProductName = c.AcademyProductName,
                DiscountPercent = c.DiscountPercent,
                Price = c.Price,
                DiscountCodeAmount = c.DiscountCodeAmount,
                AcademyProductTypeId = c.AcademyProductTypeId,
                AcademyProductType = new AcademyProductTypesModel() { Name = c.AcademyProductType.Name },
                Order = new OrdersModel()
                {
                    DiscountCode = c.Order.DiscountCode,
                    RegDateTime = c.Order.RegDateTime,
                    Id = c.OrderId,
                    StudentUserId = c.Order.StudentUserId,
                    PaymentAmount = c.Order.PaymentAmount,
                    SubTotal = c.Order.SubTotal,
                    FinalInvoice = c.Order.FinalInvoice,
                    StudentUser = new UsersModel() { UserName = c.Order.StudentUser.UserName, FirstName = c.Order.StudentUser.FirstName, LastName = c.Order.StudentUser.LastName },
                },
            }).ToList();
            return result;
        }
        //======================================================
        public FinalizedOrdersViewModel FindWithCalculations(int OrderId)
        {
            var result = Find(OrderId);
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
                    FinalPrice = Convert.ToInt32(((c.Price - (c.Price * c.DiscountPercent / 100)) - c.DiscountCodeAmount < 0) ? 0 : (c.Price - (c.Price * c.DiscountPercent / 100)) - c.DiscountCodeAmount),
                    PriceWithDiscount = Convert.ToInt32(c.Price - (c.Price * c.DiscountPercent / 100)),
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
