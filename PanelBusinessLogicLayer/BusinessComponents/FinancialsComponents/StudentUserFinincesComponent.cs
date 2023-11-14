using Common.Enums;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using System;
using System.Linq;
using Common.Extentions;
using System.Data;
using Microsoft.EntityFrameworkCore;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using DataModels.BasicDefinitionsModels;
using PanelViewModels.FinancialsViewModels;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentUserFinincesComponent : IDisposable
    {
        Repository<FinancialTransactionsModel> financialTransactionsRepository;
        MainDBContext mainDBContext;
        //=======================================================================================
        public StudentUserFinincesComponent()
        {
            mainDBContext = new MainDBContext();
            this.financialTransactionsRepository = new Repository<FinancialTransactionsModel>();
        }
        //=======================================================================================
        public StudentUserFinincesComponent(MainDBContext _mainDBContext)
        {
            this.mainDBContext = _mainDBContext;
            this.financialTransactionsRepository = new Repository<FinancialTransactionsModel>(mainDBContext);
        }
        //=======================================================================================
        public IQueryable<FinancialTransactionsModel> Read(string userName)
        {

            using (var studentUsersRepository = new Repository<UsersModel>())
            {
                var studentUser = studentUsersRepository.Where(c => c.UserName == userName && c.UserGroupId == (int)UserGroup.Student).Select(c => new { c.Id, c.UserName }).FirstOrDefault();
                if (studentUser == null)
                    throw new Exception("نام کاربری یافت نشد");
                var result = financialTransactionsRepository.Where(c => c.Invoice.StudentUserId == studentUser.Id, c => c.Invoice.InvoiceType)
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
                        Invoice = new InvoicesModel() { Comment = c.Invoice.Comment, InvoiceNo = c.Invoice.InvoiceNo, InvoiceType = new InvoiceTypesModel() { Title = c.Invoice.InvoiceType.Title } ,ModUser = c.Invoice.ModUser !=null ? new UsersModel() { FirstName = c.Invoice.ModUser.FirstName , LastName = c.Invoice.ModUser.LastName} : null }
                        
                    }).OrderByDescending(c => c.RegDateTime);
                return result;
            }
        }
        //======================================================================================
        public int GetBalance(int studentUserId)
        {
            var result = financialTransactionsRepository.Where(c => c.Invoice.StudentUserId == studentUserId && c.Invoice.StudentUser.UserGroupId == (int)UserGroup.Student).OrderByDescending(c => c.RegDateTime).FirstOrDefault();
            if (result == null)
                return 0;
            return result.Balance;
        }
        //======================================================================================= واریز
        public void Deposit(int? OrderId, int InvoiceId, int studentUserId, int DepositValue)
        {
            var CurrentBalance = GetBalance(studentUserId);
            var model = new FinancialTransactionsModel()
            {
                RegDateTime = DateTime.UtcNow,
                DepositAmount = DepositValue,
                PreviousBalance = CurrentBalance,
                WithdrawalAmount = 0,
                Balance = CurrentBalance + DepositValue,
                InvoiceId = InvoiceId,
                OrderId = OrderId,
            };
            financialTransactionsRepository.Add(model);
            financialTransactionsRepository.SaveChanges();
        }
        //======================================================================================= برداشت
        public void Withdraw(int? OrderId, int InvoiceId, int StudentUserId, int WithdrawValue)
        {
            var CurrentBalance = GetBalance(StudentUserId);
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
                throw new Exception("موجودی کافی نیست");
            financialTransactionsRepository.Add(model);
            financialTransactionsRepository.SaveChanges();
        }
        //=================================================================
        public void ChangeCredit(ChangeCreditViewModel viewModel, int modUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var invoiceRepository = new Repository<InvoicesModel>())
                    {
                        var invoiceModel = CreateChangeCreditInvoice(viewModel, modUserId);
                        invoiceRepository.Add(invoiceModel);
                        invoiceRepository.SaveChanges();
                        if (viewModel.QuantityControl == QuantityControl.Increase)
                            this.Deposit(null, invoiceModel.Id, viewModel.StudentUserId, viewModel.Amount);
                        else
                            this.Withdraw(null, invoiceModel.Id, viewModel.StudentUserId, viewModel.Amount);
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=================================================================
        InvoicesModel CreateChangeCreditInvoice(ChangeCreditViewModel viewModel, int modUserId)
        {
            return new InvoicesModel()
            {
                ModUserId = modUserId,
                StudentUserId = viewModel.StudentUserId,
                InvoiceNo = viewModel.StudentUserId.InvoiceNo(),
                InvoiceStatusDateTime = DateTime.UtcNow,
                InvoiceStatusTypeId = (int)InvoiceStatusType.SuccessPayment,
                TotalPrice = viewModel.Amount,
                InvoiceTypeId = viewModel.QuantityControl == QuantityControl.Increase ? (int)InvoiceType.IncreaseCreditsByAdmin : (int)InvoiceType.DecreaseCreditsByAdmin,
                IssuedDateTime = DateTime.UtcNow,
                Comment = viewModel.Comment
            };
        }

        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            financialTransactionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
