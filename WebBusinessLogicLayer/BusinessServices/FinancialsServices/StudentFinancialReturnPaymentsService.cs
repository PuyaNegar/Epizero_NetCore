using Common.Objects; 
using System;
using Common.Extentions;
using WebViewModels.FinancialsViewModels;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinancialReturnPaymentsService : IDisposable
    {
        private StudentFinancialReturnPaymentsComponent studentFinancialReturnPaymentsComponent;
        public StudentFinancialReturnPaymentsService()
        {
            studentFinancialReturnPaymentsComponent = new StudentFinancialReturnPaymentsComponent();
        }
        //=============================================
        public SysResult Find(int Id , int studentUserId )
        {
            var result = studentFinancialReturnPaymentsComponent.Find(Id , studentUserId );
            var viewModel = new StudentFinancialReturnPaymentsViewModel()
            {
                Id = result.Id,
                Description = result.Description,
                AmountPaidDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StudentUserId = result.StudentUserId,
                ReturnAmount = result.ReturnAmount,
                ReturnPaymentTypeId = result.ReturnPaymentTypeId,
                StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully , Value = viewModel };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialReturnPaymentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
