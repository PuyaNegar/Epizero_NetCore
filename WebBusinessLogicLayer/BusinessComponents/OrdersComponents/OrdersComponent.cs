using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.OrdersModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.OrdersViewModel;

namespace WebBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class OrdersComponent : IDisposable
    {
        private Repository<OrderDetailsModel> orderDetailsRepository;
        //=============================================================================
        public OrdersComponent()
        {
            this.orderDetailsRepository = new Repository<OrderDetailsModel>();
        }
        //=============================================================================
        public OrdersComponent(MainDBContext mainDbContext)
        {
            this.orderDetailsRepository = new Repository<OrderDetailsModel>(mainDbContext);
        }
        //=============================================================================
        public void AddItem(ref int OrderId, int academyProductId, int? CurrentUserId, AcademyProductType academyProductType)
        {
            var orderId = OrderId;
            List<OrderDetailsModel> orderDetail = null;
            if (OrderId != 0)
            {
                orderDetail = orderDetailsRepository.Where(c => c.Order.Id == orderId && c.Order.OrderStatusTypeId != (int)OrderStatusType.Finalized, c => c.Order).ToList();
                if (orderDetail.Any() && orderDetail.First().Order.OrderStatusTypeId == (int)OrderStatusType.Block)
                    return;
                if (!orderDetail.Any())
                    orderDetail = null;
            }
            if (orderDetail == null)
            {
                using (var ordersRepository = new Repository<OrdersModel>())
                {
                    var OrderModel = new OrdersModel()
                    {
                        StudentUserId = CurrentUserId,
                        OrderStatusTypeId = (int)OrderStatusType.Active,
                        ModDateTime = DateTime.UtcNow,
                        OrderStatueDateTime = DateTime.UtcNow,
                        RegDateTime = DateTime.UtcNow,
                        PaymentAmount = 0,
                    };
                    OrderModel.OrderDetails.Add(new OrderDetailsModel()
                    {
                        OrderId = OrderId,
                        Price = 0,
                        CourseId = academyProductType == AcademyProductType.Course ? academyProductId : (int?)null,
                        CourseMeetingId = academyProductType == AcademyProductType.CourseMeeting ? academyProductId : (int?)null,
                        OnlineExamId = academyProductType == AcademyProductType.OnlineExam ? academyProductId : (int?)null,
                        ProductId = academyProductType == AcademyProductType.Product ? academyProductId : (int?)null,
                        AcademyProductTypeId = (int)academyProductType,
                    });
                    ordersRepository.Add(OrderModel);
                    ordersRepository.SaveChanges();
                    OrderId = OrderModel.Id;
                }
            }
            else
            {
                var data = orderDetail.SingleOrDefault(MackOrderDetailFindQuery(academyProductType, academyProductId));
                if (data == null)
                {

                    orderDetailsRepository.Add(new OrderDetailsModel()
                    {
                        OrderId = OrderId,
                        Price = 0,
                        CourseId = academyProductType == AcademyProductType.Course ? academyProductId : (int?)null,
                        CourseMeetingId = academyProductType == AcademyProductType.CourseMeeting ? academyProductId : (int?)null,
                        OnlineExamId = academyProductType == AcademyProductType.OnlineExam ? academyProductId : (int?)null,
                        ProductId = academyProductType == AcademyProductType.Product ? academyProductId : (int?)null,
                        AcademyProductTypeId = (int)academyProductType,
                    });
                    orderDetailsRepository.SaveChanges();
                    using (var ordersRepository = new Repository<OrdersModel>())
                    {
                        var order = ordersRepository.SingleOrDefault(c => c.Id == orderId);
                        order.ModDateTime = DateTime.UtcNow;
                        order.StudentUserId = CurrentUserId;
                        ordersRepository.Update(order);
                        ordersRepository.SaveChanges();
                    }
                }
                else
                {
                    throw new CustomException("این دوره قبلا به سبد خرید افزوده شده است");
                }
            }
        }
        //=============================================================================
        public void RemoveItem(int OrderId, int OrderDetailId, int? UserId)
        {
            using (var ordersRepository = new Repository<OrdersModel>())
            {
                var result = ordersRepository.SingleOrDefault(c => c.Id == OrderId && c.OrderStatusTypeId == (int)OrderStatusType.Active);
                if (result != null)
                {
                    result.ModDateTime = DateTime.UtcNow;
                    ordersRepository.Update(result);
                    ordersRepository.SaveChanges();
                }
            }
            orderDetailsRepository.Delete(c => c.Order.Id == OrderId && c.Id == OrderDetailId && c.Order.OrderStatusTypeId == (int)OrderStatusType.Active);
            orderDetailsRepository.SaveChanges();
        }
        //===================================================================================
        List<OrderDetailsModel> Read(int OrderId)
        {
            var result = orderDetailsRepository.Where(c => c.OrderId == OrderId && c.Order.OrderStatusTypeId != (int)OrderStatusType.Finalized, c => c.Order.StudentUser, c => c.Course, c => c.CourseMeeting.Course, c => c.Product).Select(c => new OrderDetailsModel()
            {
                Id = c.Id,
                OrderId = c.OrderId,
                AcademyProductTypeId = c.AcademyProductTypeId,
                CourseMeetingId = c.CourseMeetingId,
                ProductId = c.ProductId,
                CourseId = c.CourseId,
                OnlineExamId = c.OnlineExamId,
                Price = c.Price,
                Order = new OrdersModel()
                {
                    Id = c.OrderId,
                    Score = c.Order.Score,
                    StudentUserId = c.Order.StudentUserId,
                    OrderStatusTypeId = c.Order.OrderStatusTypeId,
                    DiscountCodeId = c.Order.DiscountCodeId,
                    DiscountCode = c.Order.DiscountCode == null ? null : new DiscountCodesModel() { Id = c.Order.DiscountCode.Id, Code = c.Order.DiscountCode.Code },
                },
                Course = c.AcademyProductTypeId == (int)AcademyProductType.Course ? new CoursesModel()
                {
                    Id = c.Course.Id,
                    Name = c.Course.Name,
                    LogoPicPath = c.Course.LogoPicPath,
                    Price = c.Course.Price,
                    TeacherUser = new UsersModel() { FirstName = c.Course.TeacherUser.FirstName, LastName = c.Course.TeacherUser.LastName },
                    DiscountPercent = c.Course.DiscountPercent,
                    BannerPicPath = c.Course.BannerPicPath
                } : null,
                CourseMeeting = c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting ? new CourseMeetingsModel()
                {
                    Id = c.CourseMeeting.Id,
                    CourseId = c.CourseMeeting.CourseId,
                    Name = c.CourseMeeting.Name,
                    Price = c.CourseMeeting.Price,
                    TeacherUser = new UsersModel() { FirstName = c.CourseMeeting.TeacherUser.FirstName, LastName = c.CourseMeeting.TeacherUser.LastName },
                    DiscountPercent = c.CourseMeeting.DiscountPercent,
                    Course = new CoursesModel() { Name = c.CourseMeeting.Course.Name, BannerPicPath = c.CourseMeeting.Course.BannerPicPath }
                } : null,

            }).ToList();
            return result;
        }
        //===================================================================================
        public OrdersViewModel ReadWithCalculations(int OrderId)
        {

            var result = this.Read(OrderId);
            if (result == null || !result.Any())
                return new OrdersViewModel() { HashOrderId = OrderId.ToString().EncriptWithDESAlgoritm(), IsEmptyOrder = true, OrderInfo = null };
            var Order = result.First().Order;
            var CdnUrl = AppConfigProvider.CdnUrl();

            //=========
            var courseIds = result.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.Course).Select(c => c.CourseId.Value).ToList<int>();
            var buyed_courseMeetings = GetBuyedCourseMeetings(Order, courseIds, Order.StudentUserId);
            var total_courseMeetings = GetCourseMeetings(courseIds, Order.StudentUserId);
            //=========

            var model = new OrdersViewModel()
            {
                HashOrderId = result.First().OrderId.ToString().EncriptWithDESAlgoritm(),
                OrderId = Order.Id,
                Score = Order.Score,
                IsEmptyOrder = false,
                DiscountCodeId = Order.DiscountCodeId,
                OrderStatusTypes = (OrderStatusType)Order.OrderStatusTypeId,
                OrderInfo = new OrderInfoViewModel()
                {
                    UserId = Order.StudentUserId,
                    IsDiscountCodeApplied = Order.DiscountCodeId == null ? false : true,
                    DiscountCodeId = Order.DiscountCode == null ? (int?)null : Order.DiscountCode.Id,
                    DiscountCode = Order.DiscountCode == null ? string.Empty : Order.DiscountCode.Code,
                    OrderDetails = result.Select(c => new OrderDetailsViewModel()
                    {
                        Id = c.Id,
                        CourseId = c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting ? c.CourseMeeting.CourseId : (int?)null,
                        AcademyProductName = GetAcademyProductName(c, (AcademyProductType)c.AcademyProductTypeId),
                        AcademyProductTypeId = c.AcademyProductTypeId,
                        TecherFullName = GetTeacherFullName(c, (AcademyProductType)c.AcademyProductTypeId),
                        AcademyProductId = GetAcademyProductId(c, (AcademyProductType)c.AcademyProductTypeId),
                        Price = GetAcademyProductPrice(c, (AcademyProductType)c.AcademyProductTypeId, total_courseMeetings, buyed_courseMeetings),
                        DiscountPercent = GetAcademyProductDiscountPercent(c, (AcademyProductType)c.AcademyProductTypeId),
                        PriceWithDiscount = Convert.ToInt32(GetAcademyProductPrice(c, (AcademyProductType)c.AcademyProductTypeId, total_courseMeetings, buyed_courseMeetings) - (GetAcademyProductPrice(c, (AcademyProductType)c.AcademyProductTypeId, total_courseMeetings, buyed_courseMeetings) * GetAcademyProductDiscountPercent(c, (AcademyProductType)c.AcademyProductTypeId) / 100)),
                        AcademyProductPicPath = GetAcademyProductPicPath(c, (AcademyProductType)c.AcademyProductTypeId)
                    }).ToList(),
                }
            };
            using (var discountCodeCalculatorComponent = new DiscountCodeCalculatorComponent())
            {
                if (model.DiscountCodeId != null)
                    discountCodeCalculatorComponent.Calculate(model.OrderInfo.OrderDetails, model.DiscountCodeId.Value);
                for (int i = 0; i < model.OrderInfo.OrderDetails.Count; i++)
                {
                    model.OrderInfo.OrderDetails[i].DiscountCodeAmount = model.DiscountCodeId != null ? discountCodeCalculatorComponent.GetAcademyProductDiscountPrice(model.OrderInfo.OrderDetails[i].Id) : 0;
                    model.OrderInfo.OrderDetails[i].FinalPrice = model.OrderInfo.OrderDetails[i].PriceWithDiscount - model.OrderInfo.OrderDetails[i].DiscountCodeAmount;
                    model.OrderInfo.OrderDetails[i].FinalPrice = (model.OrderInfo.OrderDetails[i].FinalPrice < 0) ? 0 : model.OrderInfo.OrderDetails[i].FinalPrice;
                }
            }
            model.OrderInfo.OrderDetailsCount = model.OrderInfo.OrderDetails.Count();
            model.OrderInfo.SubTotal = model.OrderInfo.OrderDetails.Sum(c => c.Price);
            model.OrderInfo.TotalPriceWithDiscount = model.OrderInfo.OrderDetails.Sum(c => c.PriceWithDiscount);
            model.OrderInfo.TotalDiscountCodeAmount = model.OrderInfo.OrderDetails.Sum(c => c.DiscountCodeAmount);
            model.OrderInfo.PaymentAmount = model.OrderInfo.OrderDetails.Sum(c => c.FinalPrice);
            return model;
        }
        //==================================================================================
        List<CourseMeetingsModel> GetCourseMeetings(List<int> courseIds, int? studentUserId)
        {
            if (studentUserId == null)
                return new List<CourseMeetingsModel>();
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var total_courseMeetings = courseMeetingsRepository.Where(c => courseIds.Contains(c.CourseId)).ToList();
                return total_courseMeetings;
            }
        }
        //==================================================================================
        List<CourseMeetingStudentsModel> GetBuyedCourseMeetings(OrdersModel Order, List<int> courseIds, int? studentUserId)
        {
            if (studentUserId == null)
                return new List<CourseMeetingStudentsModel>();
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
            {
                var buyed_courseMeetings = courseMeetingStudentsRepository.Where(c => c.IsActive && c.Price > 0 && !c.IsTemporaryRegistration && courseIds.Contains(c.CourseId) && c.StudentUserId == Order.StudentUserId.Value && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting).ToList();
                return buyed_courseMeetings;
            }
        }
        //===================================================================================
        void UpdateUserId(int OrderId, int? CurrentUserId)
        {
            {
                using (var ordersRepository = new Repository<OrdersModel>())
                {
                    var data = ordersRepository.SingleOrDefault(c => c.Id == OrderId);
                    if (data == null)
                        throw new Exception("سفارش یافت نشد");
                    data.ModDateTime = DateTime.UtcNow;
                    data.StudentUserId = CurrentUserId;
                    ordersRepository.Update(data);
                    ordersRepository.SaveChanges();
                }
            }
        }
        //===================================================================================
        public OrdersViewModel ReadWithCalculations(int OrderId, int? CurrentUserId, bool IsUpdateUserId = true)
        {
            var result = ReadWithCalculations(OrderId);
            if (result.IsEmptyOrder == false && result.OrderInfo.UserId != CurrentUserId)
            {
                if (IsUpdateUserId)
                    UpdateUserId(OrderId, CurrentUserId);
                return ReadWithCalculations(OrderId);
            }
            return result;
        }
        //===================================================================================
        int GetAcademyProductId(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType)
        {
            int academyProductTypeId = 0;
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    academyProductTypeId = orderDetailsModel.CourseId.Value;
                    break;
                case AcademyProductType.CourseMeeting:
                    academyProductTypeId = orderDetailsModel.CourseMeetingId.Value;
                    break;
                case AcademyProductType.OnlineExam:
                    academyProductTypeId = orderDetailsModel.OnlineExamId.Value;
                    break;
                case AcademyProductType.Product:
                    academyProductTypeId = orderDetailsModel.ProductId.Value;
                    break;
            }
            return academyProductTypeId;
        }
        //==============================================================
        string GetTeacherFullName(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType)
        {
            string teacherFullName = string.Empty;
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    teacherFullName = orderDetailsModel.Course.TeacherUser.FirstName + " " + orderDetailsModel.Course.TeacherUser.LastName;
                    break;
                case AcademyProductType.CourseMeeting:
                    teacherFullName = orderDetailsModel.CourseMeeting.TeacherUser.FirstName + " " + orderDetailsModel.CourseMeeting.TeacherUser.LastName;
                    break;
                case AcademyProductType.OnlineExam:
                    teacherFullName = "----";
                    break;
                case AcademyProductType.Product:
                    teacherFullName = "----";
                    break;
            }
            return teacherFullName;
        }
        //===================================================================================
        public int CountOrderDetailItems(int orderId)
        {
            var result = orderDetailsRepository.Where(c => c.OrderId == orderId && c.Order.OrderStatusTypeId != (int)OrderStatusType.Finalized).Count();
            return result;
        }
        //===================================================================================
        int GetAcademyProductPrice(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType, List<CourseMeetingsModel> total_courseMeetings, List<CourseMeetingStudentsModel> buyed_courseMeetingStudents)
        {
            int price = 0;
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    price = CalculateCoursePrice(orderDetailsModel, total_courseMeetings, buyed_courseMeetingStudents);
                    break;
                case AcademyProductType.CourseMeeting:
                    price = orderDetailsModel.CourseMeeting.Price;
                    break;
                case AcademyProductType.Product:
                    price = orderDetailsModel.Product.Price;
                    break;
            }
            return price;
        }
        //======================================================
        int CalculateCoursePrice(OrderDetailsModel orderDetails, List<CourseMeetingsModel> total_courseMeetings, List<CourseMeetingStudentsModel> buyed_courseMeetings)
        {
            if (orderDetails.Order.StudentUserId == null)
                return orderDetails.Course.Price;
            int total_courseMeetingCount = 0, buyed_courseMeetingCount = 0;
            buyed_courseMeetingCount = buyed_courseMeetings.Where(c => c.CourseId == orderDetails.CourseId).Count();
            if (buyed_courseMeetingCount == 0)
                return orderDetails.Course.Price;
            total_courseMeetingCount = total_courseMeetings.Where(c => c.CourseId == orderDetails.CourseId).Count();
            if (total_courseMeetingCount == 0)
                return orderDetails.Course.Price;
            var notBuyed_courseMeetingCount = total_courseMeetingCount - buyed_courseMeetingCount;
            int result = (int)(orderDetails.Course.Price * (float)(notBuyed_courseMeetingCount / (float)total_courseMeetingCount));
            return result;
        }
        //===================================================================================
        float GetAcademyProductDiscountPercent(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType)
        {
            float discountPercent = 0;
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    discountPercent = orderDetailsModel.Course.DiscountPercent;
                    break;
                case AcademyProductType.CourseMeeting:
                    discountPercent = orderDetailsModel.CourseMeeting.DiscountPercent;
                    break;
                case AcademyProductType.Product:
                    discountPercent = orderDetailsModel.Product.DiscountPercent;
                    break;
            }
            return discountPercent;
        }
        //===================================================================================
        string GetAcademyProductName(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType)
        {
            string name = string.Empty;
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    name = orderDetailsModel.Course.Name;
                    break;
                case AcademyProductType.CourseMeeting:
                    name = orderDetailsModel.CourseMeeting.Name + " ( " + orderDetailsModel.CourseMeeting.Course.Name + " ) ";
                    break;
                case AcademyProductType.Product:
                    name = orderDetailsModel.Product.Name;
                    break;
            }
            return name;
        }
        //==============================================================================
        string GetAcademyProductPicPath(OrderDetailsModel orderDetailsModel, AcademyProductType academyProductType)
        {
            string name = string.Empty;
            var cdnUrl = AppConfigProvider.CdnUrl();
            switch (academyProductType)
            {
                case AcademyProductType.Course:
                    name = string.IsNullOrEmpty(orderDetailsModel.Course.BannerPicPath) ? string.Empty : cdnUrl + orderDetailsModel.Course.BannerPicPath;
                    break;
                case AcademyProductType.CourseMeeting:
                    name = string.IsNullOrEmpty(orderDetailsModel.CourseMeeting.Course.BannerPicPath) ? string.Empty : cdnUrl + orderDetailsModel.CourseMeeting.Course.BannerPicPath;
                    break;
                case AcademyProductType.Product:
                    name = string.IsNullOrEmpty(orderDetailsModel.Product.PicPath) ? string.Empty : cdnUrl + orderDetailsModel.Product.PicPath;
                    break;
            }
            return name;
        }
        //==============================================================================
        Func<OrderDetailsModel, bool> MackOrderDetailFindQuery(AcademyProductType academyProductType, int academyProductId)
        {
            if (academyProductType == AcademyProductType.Course)
                return c => c.CourseId == academyProductId;
            if (academyProductType == AcademyProductType.CourseMeeting)
                return c => c.CourseMeetingId == academyProductId;
            if (academyProductType == AcademyProductType.Product)
                return c => c.ProductId == academyProductId;
            throw new CustomException("پارمتر های ارسالی صحیح نمی باشد");
        }
        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            orderDetailsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
