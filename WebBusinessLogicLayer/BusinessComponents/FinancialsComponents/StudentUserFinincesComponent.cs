using Common.Extentions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentUserFinincesComponent : IDisposable
    {
        Repository<FinancialTransactionsModel> financialTransactionsRepository; 
        //====================================================================================== 
        public StudentUserFinincesComponent()
        {
            this.financialTransactionsRepository = new Repository<FinancialTransactionsModel>();
        }
        //======================================================================================
        public StudentUserFinincesComponent(MainDBContext mainDBContext)
        {
            this.financialTransactionsRepository = new Repository<FinancialTransactionsModel>(mainDBContext);
        }
        //======================================================================================
        public int GetBalance(int StudentUserId)
        {
            var result = financialTransactionsRepository.Where(c => c.Invoice.StudentUserId == StudentUserId).OrderByDescending(c => c.RegDateTime).FirstOrDefault();
            if (result == null)
                return 0;
            return result.Balance;
        }
        //=======================================================================================
        public TransactionsResponseViewModel Read(int Page, int Count, int StudentUserId)
        {
            var model = new TransactionsResponseViewModel()
            {
                Page = Page + 1,
                TotalCount = financialTransactionsRepository.Where(c => c.Invoice.StudentUserId == StudentUserId).Count(),
                Transactions = GetFinancialTransactions(Page, Count, StudentUserId).Select(c => new TransactionsViewModel()
                {
                    Balance = c.Balance,
                    Withdraw = c.WithdrawalAmount,
                    Deposit = c.DepositAmount,
                    RegDateTime = c.RegDateTime.ToLocalDateTimeLongFormatString(),
                    PreviousBalance = c.PreviousBalance,
                     InvoiceNo = c.Invoice.InvoiceNo , 
                    FinancialTransactionTypes = c.Invoice.InvoiceType.Title,
                    OrderId = c.OrderId == null ? string.Empty : c.OrderId.ToString().EncriptWithDESAlgoritm(),
                }).ToList()
            };
            return model;
        }
        //=======================================================================================
        List<FinancialTransactionsModel> GetFinancialTransactions(int Page, int Count, int StudentUserId )
        {
            var result = financialTransactionsRepository.Where(c => c.Invoice.StudentUserId == StudentUserId, c => c.Invoice.InvoiceType)
               .Select(c => new FinancialTransactionsModel()
               {
                   Id = c.Id,
                   Balance = c.Balance,
                   DepositAmount = c.DepositAmount,
                   OrderId = c.OrderId,
                   PreviousBalance = c.PreviousBalance,
                   RegDateTime = c.RegDateTime,
                   WithdrawalAmount = c.WithdrawalAmount,
                   InvoiceId = c.InvoiceId,
                   Invoice = new InvoicesModel() { InvoiceNo = c.Invoice.InvoiceNo ,  InvoiceType = new InvoiceTypesModel() { Title = c.Invoice.InvoiceType.Title } }
               }).OrderByDescending(c => c.RegDateTime).Skip(Page * Count).Take(Count).ToList();
            return result;
        } 
        //======================================================================================= واریز
        public void Deposit(int InvoiceId, int studentUsetId, int DepositValue)
        {
            var CurrentBalance = GetBalance(studentUsetId);
            var model = new FinancialTransactionsModel()
            {
                RegDateTime = DateTime.UtcNow,
                DepositAmount = DepositValue,
                PreviousBalance = CurrentBalance,
                WithdrawalAmount = 0,
                Balance = CurrentBalance + DepositValue,
                InvoiceId = InvoiceId,
            };
            financialTransactionsRepository.Add(model);
            financialTransactionsRepository.SaveChanges();
        }
        //======================================================================================= برداشت
        public void Withdraw(int? OrderId, int InvoiceId, int UserId, int WithdrawValue)
        {
            var CurrentBalance = GetBalance(UserId);
            var model = new FinancialTransactionsModel()
            {
                RegDateTime = DateTime.UtcNow,
                DepositAmount = 0,
                PreviousBalance = CurrentBalance,
                WithdrawalAmount = WithdrawValue,
                Balance = CurrentBalance - WithdrawValue,
                InvoiceId = InvoiceId,
                OrderId = OrderId
            };
            if (model.Balance < 0)
                throw new Exception(SystemCommonMessage.NotEnoughInventory);
            financialTransactionsRepository.Add(model);
            financialTransactionsRepository.SaveChanges();
        }
        //======================================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            financialTransactionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
