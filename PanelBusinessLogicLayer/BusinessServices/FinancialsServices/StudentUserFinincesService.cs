using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentUserFinincesService : IDisposable
    {
        StudentUserFinincesComponent customerFinincesComponent;
        //========================================================================
        public StudentUserFinincesService()
        {
            this.customerFinincesComponent = new StudentUserFinincesComponent();
        }
        //========================================================================
        public SysResult Read(string TelNo)
        {

            var result = customerFinincesComponent.Read(TelNo);
            var viewModel = result.Select(c => new StudentUserFinancialTransactionsViewModel()
            {
                Balance = c.Balance,
                Withdraw = c.WithdrawalAmount,
                Deposit = c.DepositAmount,
                RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                PreviousBalance = c.PreviousBalance,
                FinancialTransactionTypeName = string.Format("{0}", c.Invoice.InvoiceType.Title),
                OrderId = c.OrderId == null ? string.Empty : c.OrderId.ToString().EncriptWithDESAlgoritm(),
                Comment = c.Invoice.Comment,
                InvoiceNo = c.Invoice.InvoiceNo ,
                ModUserFullName = c.Invoice.ModUser  != null ?  c.Invoice.ModUser.FirstName + " "  + c.Invoice.ModUser.LastName : "ثبت نشده"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult<BalanceViewModel> GetBalance(string username)
        {
            using (var studentUsersComponent = new StudentUsersComponent())
            {
                var CustomerId = studentUsersComponent.GetCustomerId(username);
                var result = customerFinincesComponent.GetBalance(CustomerId);
                var viewModel = new BalanceViewModel()
                {
                    StudentUserId = CustomerId,
                    Balance = result != 0 ? result : 0,
                };
                return new SysResult<BalanceViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
            }
        }
        //========================================================================================
        public SysResult ChangeCredit(ChangeCreditViewModel viewModel ,  int modUserId)
        {
            customerFinincesComponent.ChangeCredit(viewModel , modUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = null };
        }
        //========================================================================================
        #region DisposeObject
        public void Dispose()
        {
            customerFinincesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
