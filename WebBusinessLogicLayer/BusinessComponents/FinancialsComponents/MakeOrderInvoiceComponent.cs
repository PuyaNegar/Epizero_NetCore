using Common.Enums;
using Common.Extentions;
using Common.Functions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.OrdersComponents;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.OrdersViewModel;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class MakeOrderInvoiceComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        //=========================================================================================
        public MakeOrderInvoiceComponent()
        {
            mainDBContext = new MainDBContext();
        }
        //=========================================================================================
        public void Operation(int studentUserId, bool UseCredit, bool UseScore, int OrderId, ref string InvoiceNo, ref int FinalAmountPayable)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var order = GetOrder(OrderId, studentUserId);
                    int usedScore = 0;
                    FinalAmountPayable = GetFinalAmountPayable(order.OrderId, studentUserId, UseCredit, UseScore, order.OrderInfo.PaymentAmount);
                    ValidateOrder(order, studentUserId);
                    var InvoiceModel = new InvoicesModel() { InvoiceNo = string.Empty };
                    if (FinalAmountPayable > 0)
                        InvoiceModel = MakeInvoice(studentUserId, order.OrderId, FinalAmountPayable, usedScore);
                    transaction.Commit();
                    InvoiceNo = InvoiceModel.InvoiceNo;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=========================================================================================
        int GetFinalAmountPayable(int orderId, int CustomerId, bool UseCredit, bool useScore, int AmountPayable)
        {
            int usedScore = 0;
            int WalletBalance = 0;
            int scoreAmount = 0;
            if (UseCredit)
                using (var studentUserFinincesComponent = new StudentUserFinincesComponent())
                {
                    WalletBalance = studentUserFinincesComponent.GetBalance(CustomerId);
                }
            if (useScore)
            {
                var baseInfoRepository = new Repository<BaseInfosModel>();
                var baseInfo = baseInfoRepository.SelectAllAsQuerable().First();
                var scoreBalance = new StudentUserScoresComponent().GetBalance(CustomerId);
                scoreAmount = scoreBalance * baseInfo.EpizeroCoinPrice;
                if (scoreAmount >= AmountPayable)
                {
                    usedScore = Convert.ToInt32(Math.Ceiling(AmountPayable / (decimal)baseInfo.EpizeroCoinPrice));
                    scoreAmount = baseInfo.EpizeroCoinPrice * usedScore;
                }
                else
                {
                    usedScore = scoreBalance;
                }
            }
            UpdateOrderScore(orderId, usedScore);

            return AmountPayable - scoreAmount - WalletBalance;
        }
        //=========================================================================================
        void UpdateOrderScore(int orderId, int usedScore)
        {
            var ordersRepository = new Repository<OrdersModel>(mainDBContext);
            var order = ordersRepository.SingleOrDefault(c => c.Id == orderId);
            order.Score = usedScore == 0 ? (int?)null : usedScore;
            ordersRepository.Update(order);
            ordersRepository.SaveChanges();
        }

        //=========================================================================================
        OrdersViewModel GetOrder(int OrderId, int customerId)
        {
            using (var orderReadersComponents = new OrdersComponent())
            {
                var result = orderReadersComponents.ReadWithCalculations(OrderId, customerId);
                return result;
            }
        }
        //=========================================================================================
        private InvoicesModel MakeInvoice(int studentUserId, int orderId, int TotalPayment, int usedScore)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceTypeId = (int)InvoiceType.ChargeCredit,
                    InvoiceStatusTypeId = (int)InvoiceStatusType.SendToGateWay,
                    InvoiceNo = studentUserId.InvoiceNo(),
                    TotalPrice = TotalPayment,
                    StudentUserId = studentUserId,
                    OrderId = orderId,
                    // Score = usedScore != 0 ? usedScore : (int?)null,
                };
                invoicesRepository.Add(model);
                invoicesRepository.SaveChanges();
                return model;
            }
        }
        //===================================================================================
        void ValidateOrder(OrdersViewModel order, int studentUserId)
        {
            if (order.IsEmptyOrder)
                throw new CustomException("محتوای سبد خرید خالی می باشد امکان ایجاد صورت حساب وجود ندارد");

            if (!order.OrderInfo.UserId.HasValue)
                throw new CustomException("هیچ کاربری برای این  سبد خرید انتساب نیافته است");


            OrderAnalyze(order, studentUserId);
        }
        //===================================================================================
        void OrderAnalyze(OrdersViewModel order, int studentUserId)
        {
            var order_courseIds = order.OrderInfo.OrderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.Course).Select(c => c.AcademyProductId).ToList<int>();
            var order_courseMeetingIds = order.OrderInfo.OrderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting).Select(c => c.AcademyProductId).ToList<int>();
            var courseIds = new List<int>();
            if (order_courseMeetingIds.Any())
                using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
                {
                    courseIds = courseMeetingsRepository.Where(c => order_courseMeetingIds.Contains(c.Id)).Select(c => c.CourseId).Distinct().ToList<int>();
                }
            if (order_courseIds.Intersect(courseIds).Any())
                throw new CustomException("دوره و جلسه همان دوره نمی تواند بصورت همزمان در سبد خرید باشد لطفاً آن را اصلاح فرمایید");


            var buyed_courseMeetingIds = StudentCourseMeetingsComponent.Read(studentUserId).Select(c => c.Id).Distinct().ToList();

            if (buyed_courseMeetingIds.Intersect(order_courseMeetingIds).Any())
                throw new CustomException("شما قبلا در برخی از جلسات انتخابی ثبت نام کرده اید لطفاً آنها را اصلاح کنید");

            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
            {
                var buyed_CourseIds = courseMeetingStudentsRepository.Where(c => c.IsActive && c.StudentUserId == studentUserId && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).Select(c => c.CourseId).ToList();
                if (buyed_CourseIds.Intersect(order_courseIds).Any())
                    throw new CustomException("شما قبلا در برخی از دوره های انتخابی ثبت نام کرده اید لطفاً آنها را اصلاح کنید");
            }

            if (order.OrderInfo.IsDiscountCodeApplied)
            {
                using (var discountCodeValidationsComponent = new DiscountCodeValidationsComponent())
                {
                    discountCodeValidationsComponent.Validate(order.OrderInfo.DiscountCode, studentUserId);
                }
            }
        }

        //=================================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
        //===================================================================================
    }
}
