using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentPaymentLinksService : IDisposable
    {
        private StudentPaymentLinksComponent studentPaymentLinksComponent;
        //================================================
        public StudentPaymentLinksService()
        {
            studentPaymentLinksComponent = new StudentPaymentLinksComponent();
        }
        //================================================
        public SysResult Read(bool IsPaid)
        {
            var result = studentPaymentLinksComponent.Read(IsPaid).Select(c => new ReadStudentPaymentLinksViewModel()
            {
                Id = c.Id,
                IsPaid = c.IsPaid,
                IsPaidName = c.IsPaid ? "پرداخت شده" : "پرداخت نشده",
                AmountPayable = c.AmountPayable,
                CourseName = c.CourseMeetingStudent.Course.Name,
                PaymentDateTime = c.PaymentDateTime.HasValue ? c.PaymentDateTime.Value.ToLocalDateTimeLongFormatString() : "ثبت نشده",
                StudentFullName = c.CourseMeetingStudent.StudentUsers.FirstName + " " + c.CourseMeetingStudent.StudentUsers.LastName,
                InvoiceNo = c.Invoice == null ? "ثبت نشده" : c.Invoice.InvoiceNo,

            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================Dispose
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            studentPaymentLinksComponent?.Dispose();
        }
        #endregion
    }
}
