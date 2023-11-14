using Common.Enums;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentPaymentLinksService : IDisposable
    {
        private StudentPaymentLinksComponent studentPaymentLinksComponent;
        public StudentPaymentLinksService()
        {
            studentPaymentLinksComponent = new StudentPaymentLinksComponent();
        } 
        //==========================================================
        public SysResult Read(int currentUserId)
        {
            var result = studentPaymentLinksComponent.Read(currentUserId);
            var viewModel = result.Select(c => new StudentPaymentLinksViewModel()
            {
                Id = c.Id,
                StudentFullName = c.CourseMeetingStudent.StudentUsers.FirstName + " " + c.CourseMeetingStudent.StudentUsers.LastName,
                CourseMeetingName = c.CourseMeetingStudent.CourseMeeting.Name,
                CourseName = c.CourseMeetingStudent.Course.Name,
                AmountPayable = c.AmountPayable,
                IsPaidName = c.IsPaid ? "پرداخت شده" : "پرداخت نشده",
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=====================================================================================
        public SysResult ChargeCredit(PaymentGateway paymentGateway, string InvoiceNo, string TrackingNo, int CustomerId)
        {
            try
            {
                using (var creditPaymentComponent = new CreditPaymentComponent())
                {
                    creditPaymentComponent.OnSuccessPayment(paymentGateway, InvoiceNo, CustomerId, TrackingNo);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }
        //=====================================================================================
        public SysResult ComplatePayment(string studentPaymentLinkIds, int CustomerId, ref string InvoiceNo)
        {
            try
            {
                using (var studentPaymentLinksSuccessPaymentComponent = new StudentPaymentLinksSuccessPaymentComponent())
                {
                    studentPaymentLinksSuccessPaymentComponent.Opration(studentPaymentLinkIds.Split(',').Select(Int32.Parse).ToList(), CustomerId, ref InvoiceNo);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }
        //=====================================================================================
        public SysResult FailurePayment(string InvoiceId)
        {
            try
            {
                using (var OrderErrorPaymentComponent = new OrderErrorPaymentComponent())
                {
                    OrderErrorPaymentComponent.Opration(InvoiceId);
                }
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = SystemCommonMessage.OperationStoppedByError };
            }
        }
        //========================================================= Desposing
        #region DisposeObject
        public void Dispose()
        {
            studentPaymentLinksComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
