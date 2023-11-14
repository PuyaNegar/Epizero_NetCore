using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using System.Linq;
using Common.Extentions;
using Common.Objects;
using DataModels.OrdersModels;
using DataModels.FinancialsModels;
using WebViewModels.OrdersViewModel;
using WebBusinessLogicLayer.BusinessComponents.OrdersComponents;
using DataModels.TrainingManagementModels;
using Common.Functions;
using WebBusinessLogicLayer.UtilityComponents.SmsComponents;
using System.Collections.Generic;
using DataModels.BasicDefinitionsModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class OrderSuccessPaymentComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private List<SalePartnerUserSmsViewModel> SalePartnerUserSms_list; 
        public OrderSuccessPaymentComponent()
        {
            SalePartnerUserSms_list = new List<SalePartnerUserSmsViewModel>();
            mainDBContext = new MainDBContext();
        }
        //====================================================================================================
        public void Opration(int orderId, int studentUserId, ref string InvoiceNo)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var order = GetOrder(orderId, studentUserId); 
                    if(order.Score != null) 
                        ConvertScoreToCredit(studentUserId, order); 
                    var invoice = CreateOrderInvoice(studentUserId, order.OrderInfo.PaymentAmount, orderId , InvoiceType.Order);
                    FinalizeOrder(invoice, order);
                    CreateFininceTransaction(order.OrderId, invoice);
                    AppendCourseMeetingStudents(order, studentUserId, invoice.InvoiceNo);
                    new StudentUserScoresComponent(mainDBContext).Reward(studentUserId, ScoringTariffs.Purchase , order.OrderInfo.PaymentAmount);
                    transaction.Commit();
                    InvoiceNo = invoice.InvoiceNo;
                    
                    try { StudentRegisterInCourseSmsComponent.Operation(order.OrderInfo.OrderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.Course).ToList(), studentUserId  ,  order.OrderInfo.DiscountCode); } catch (Exception ex) { }
                    try { StudentRegisterInCourseMeetingSmsComponent.Operation(order.OrderInfo.OrderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting).ToList(), studentUserId , order.OrderInfo.DiscountCode); } catch (Exception ex) { }
                    try { SalePartnerUserSmsComponent.Operation( SalePartnerUserSms_list ,  studentUserId   ); } catch (Exception ex) { }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }     
        //======================================================================================================= 
        private void ConvertScoreToCredit(  int studentUserId, OrdersViewModel order)
        {
            var baseInfoRepository = new Repository<BaseInfosModel>();
            var baseInfo = baseInfoRepository.SelectAllAsQuerable().First();
            new StudentUserScoresComponent(mainDBContext).Withdraw(studentUserId, order.Score.Value, "", studentUserId, UserScoreType.DecreaseDueConvertCoinToCredit);
            var invoice  = CreateOrderInvoice(studentUserId, baseInfo.EpizeroCoinPrice * order.Score.Value, null, InvoiceType.IncreaseDueConvertCoinToCredit);
            ScoreConvertToCreditFininceTransaction(invoice);
        } 
        //=======================================================================================================
        InvoicesModel CreateOrderInvoice(int userId, int TotalPayment, int? OrderId , InvoiceType invoiceType)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceTypeId = (int)invoiceType,
                    InvoiceStatusTypeId = (int)InvoiceStatusType.SuccessPayment,
                    InvoiceNo = userId.InvoiceNo(),
                    TotalPrice = TotalPayment,
                    StudentUserId = userId,
                    OrderId = OrderId,
                };
                invoicesRepository.Add(model);
                invoicesRepository.SaveChanges();
                return model;
            }
        }
        //=======================================================================================================
        void FinalizeOrder(InvoicesModel Invoices, OrdersViewModel order)
        {
            using (var ordersRepository = new Repository<OrdersModel>(mainDBContext))
            {
                var result = ordersRepository.SingleOrDefault(c => c.Id == order.OrderId && c.OrderStatusTypeId != (int)OrderStatusType.Finalized);
                if (result == null)
                    throw new Exception(SystemCommonMessage.DataWasNotFound);
                result.ModDateTime = DateTime.UtcNow;
                result.OrderStatueDateTime = DateTime.UtcNow;
                result.OrderStatusTypeId = (int)OrderStatusType.Finalized;
                result.PaymentAmount = order.OrderInfo.PaymentAmount;
                result.SubTotal = order.OrderInfo.SubTotal;
                result.FinalInvoiceId = Invoices.Id;
                ordersRepository.Update(result);
                ordersRepository.SaveChanges();
            }
            UpdateOrderDetailProducts(order);
        }
        //===========================================================================
        void AppendCourseMeetingStudents(OrdersViewModel order, int studentUserId, string InvoiceNo)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>(mainDBContext))
            {
                foreach (var orderDetail in order.OrderInfo.OrderDetails)
                {
                    var salePartnerPrice = SalePartnerUserShareCalculate(order.OrderInfo.DiscountCodeId, orderDetail, studentUserId);
                    if (orderDetail.AcademyProductTypeId == (int)AcademyProductType.Course)
                    {
                        var model = new CourseMeetingStudentsModel()
                        {
                            CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.Course,
                            CourseId = orderDetail.AcademyProductId,
                            IsActive = true,
                            RawPrice = orderDetail.Price,
                            RegDateTime = DateTime.UtcNow,
                            StudentUserId = studentUserId,
                            IsTemporaryRegistration = false , 
                            ModUserId = studentUserId,
                            IsOnlineRegistrated = true,
                            OrderId = order.OrderId,
                            SalePartnerPrice = salePartnerPrice ,
                            Price = (orderDetail.FinalPrice - salePartnerPrice < 0) ? 0 : orderDetail.FinalPrice - salePartnerPrice,
                            DiscountAmount = orderDetail.DiscountCodeAmount < 0 ? 0 : orderDetail.DiscountCodeAmount
                        };
                        orderDetail.SalePartnerPrice = salePartnerPrice;
                        courseMeetingStudentsRepository.Add(model);
                        courseMeetingStudentsRepository.SaveChanges();
                        if (orderDetail.FinalPrice > 0)
                            AddStudentFinancialDebts(model.Id, studentUserId);
                    }
                    if (orderDetail.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting)
                    {
                        var model = new CourseMeetingStudentsModel()
                        {
                            CourseMeetingStudentTypeId = (int)CourseMeetingStudentType.CourseMeeting,
                            CourseMeetingId = orderDetail.AcademyProductId,
                            IsActive = true, 
                            RawPrice = orderDetail.Price , 
                            IsTemporaryRegistration = false , 
                            CourseId = orderDetail.CourseId.Value,
                            RegDateTime = DateTime.UtcNow,
                            StudentUserId = studentUserId,
                            ModUserId = studentUserId,
                            IsOnlineRegistrated = true,
                            OrderId = order.OrderId,
                            SalePartnerPrice = salePartnerPrice,
                            Price = (orderDetail.FinalPrice - salePartnerPrice < 0) ? 0 : orderDetail.FinalPrice -  salePartnerPrice ,
                            DiscountAmount = orderDetail.DiscountCodeAmount < 0 ? 0 : orderDetail.DiscountCodeAmount , 
                        };
                        courseMeetingStudentsRepository.Add(model);
                        courseMeetingStudentsRepository.SaveChanges();
                        if (orderDetail.FinalPrice > 0)
                            AddStudentFinancialDebts(model.Id, studentUserId);
                    }
                }
                AddStudentFinancialPayments(order.OrderInfo.OrderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.Course || c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting).Sum(c => c.FinalPrice), studentUserId, InvoiceNo);
            }
        }
        //===================================================================================
        void UpdateOrderDetailProducts(OrdersViewModel order)
        {
            using (var orderDetailsRepository = new Repository<OrderDetailsModel>(mainDBContext))
            {
                var orderDetailProducts = orderDetailsRepository.Where(c => c.Order.Id == order.OrderId).ToList();
                foreach (var orderDetailProduct in orderDetailProducts)
                {
                    orderDetailProduct.DiscountPercent = order.OrderInfo.OrderDetails.Single(c => c.Id == orderDetailProduct.Id).DiscountPercent;
                    orderDetailProduct.DiscountCodeAmount = order.OrderInfo.OrderDetails.Single(c => c.Id == orderDetailProduct.Id).DiscountCodeAmount;
                    orderDetailProduct.Price = order.OrderInfo.OrderDetails.Single(c => c.Id == orderDetailProduct.Id).Price;
                    orderDetailProduct.AcademyProductName = order.OrderInfo.OrderDetails.Single(c => c.Id == orderDetailProduct.Id).AcademyProductName;
                    orderDetailsRepository.Update(orderDetailProduct);
                }
                orderDetailsRepository.SaveChanges();
            }
        }
        //========================================================
        int SalePartnerUserShareCalculate(int? discountCodeId, OrderDetailsViewModel orderDetail, int studentUserId)
        {
            if (orderDetail.DiscountCodeAmount == 0)
                return 0;
            if (discountCodeId == null)
                return 0;
            using (var discountCodesRepository = new Repository<DiscountCodesModel>(mainDBContext))
            {
                var result = discountCodesRepository.SingleOrDefault(c => c.Id == discountCodeId.Value);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                if (result.SalePartnerUserId == null)
                    return 0;
                var price =  orderDetail.PriceWithDiscount;
                if (result.SalesPartnerShareTypeId == (int)SalesPartnerShareType.Amount)
                    price = price < result.SalePartnerAmountOrPercent.Value ? price : result.SalePartnerAmountOrPercent.Value;
                else
                {
                  if(result.SalePartnerIsPrePayment.Value)
                    {
                      price =  price * result.SalePartnerAmountOrPercent.Value / 100;
                    }
                    else
                    {
                        price = Convert.ToInt32( (price - (price * result.AmountOrPercent / 100)) * ((decimal)result.SalePartnerAmountOrPercent.Value / 100));
                    }
              
                }
                AddSalesPartnerShares(orderDetail, studentUserId, result, price);
                return price;
            }
        }
        //=========================================================
        void AddSalesPartnerShares(OrderDetailsViewModel orderDetail, int studentUserId, DiscountCodesModel result, int price)
        {
            using (var salesPartnerSharesRepository = new Repository<SalesPartnerUserSharesModel>(mainDBContext))
            {
                salesPartnerSharesRepository.Add(new SalesPartnerUserSharesModel()
                {
                    OrderDetailId = orderDetail.Id,
                    Amount = price,
                    RegDateTime = DateTime.UtcNow,
                    SalePartnerUserId = result.SalePartnerUserId.Value,
                    ModUserId = studentUserId,
                });
                salesPartnerSharesRepository.SaveChanges();
                SalePartnerUserSms_list.Add(new SalePartnerUserSmsViewModel { AcademyProductName = orderDetail.AcademyProductName, SalePartnerUserShareAmount = price , SalePartnerUserId =  result.SalePartnerUserId.Value });
            }
        }
        //===================================================================================
        OrdersViewModel GetOrder(int orderId, int customerId)
        {
            using (var ordersComponent = new OrdersComponent())
            {
                var result = ordersComponent.ReadWithCalculations(orderId, customerId);
                return result;
            }
        }
        //====================================================================================
        void CreateFininceTransaction(int OrderId, InvoicesModel invoicesModel)
        {
            using (var studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext))
            {
                studentUserFinincesComponent.Withdraw(OrderId, invoicesModel.Id, invoicesModel.StudentUserId, invoicesModel.TotalPrice);
            }
        }
        //===================================================================================
        void AddStudentFinancialDebts(int courseMeetingStudentId, int studentUserId)
        {
            using (var studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(mainDBContext))
            {
                studentFinancialDebtsRepository.Add(new StudentFinancialDebtsModel()
                {
                    CourseMeetingStudentId = courseMeetingStudentId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = studentUserId,  
                });
                studentFinancialDebtsRepository.SaveChanges();
            }
        }
        //====================================================================================
        void AddStudentFinancialPayments(int amountPaid, int studentUserId, string InvoiceNo)
        {
            if (amountPaid > 0)
            {
                using (var studentFinancialPaymentsModelRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext))
                {
                    studentFinancialPaymentsModelRepository.Add(new StudentFinancialPaymentsModel()
                    {
                        StudentUserId = studentUserId,
                        StudentFinancialPaymentTypeId = (int)StudentFinancialPaymentTypes.OnlinePayment,
                        RegDateTime = DateTime.UtcNow,
                        ModDateTime = DateTime.UtcNow, 
                        ModUserId = studentUserId,
                        AmountPaid = amountPaid,
                        Description = "خرید آنلاین به شماره صورتحساب" + InvoiceNo,
                    });
                    studentFinancialPaymentsModelRepository.SaveChanges();
                }
            }
        }


        //====================================================================================
        void  ScoreConvertToCreditFininceTransaction(InvoicesModel invoicesModel)
        {
            using (var studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext))
            {
                studentUserFinincesComponent.Deposit(invoicesModel.Id, invoicesModel.StudentUserId, invoicesModel.TotalPrice);
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
