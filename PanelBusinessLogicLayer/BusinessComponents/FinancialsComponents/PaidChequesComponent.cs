using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class PaidChequesComponent : IDisposable
    {
        private Repository<PaidChequesModel> paidChequesRepository;
        //=================================================
        public PaidChequesComponent()
        {
            paidChequesRepository = new Repository<PaidChequesModel>();
        }
        //=================================================
        public void Add(PaidChequesModel model)
        {
            var query = paidChequesRepository.FirstOrDefault(c=> c.FishingCode == model.FishingCode);
            if (query != null) { throw new Exception("کد صیادی وارد شده در سیستم موجود می باشد"); }
            var query2 = paidChequesRepository.FirstOrDefault(c => c.ChequesNo == model.ChequesNo);
            if (query2 != null) { throw new Exception("شماره چک وارد شده در سیستم موجود می باشد"); }
            paidChequesRepository.Add(model);
            paidChequesRepository.SaveChanges();
        }
        //=================================================
        public IQueryable<PaidChequesModel> Read(int chequesStatusTypeId)
        {
            IQueryable<PaidChequesModel> query;
            if (chequesStatusTypeId != 0)
                query = paidChequesRepository.Where(c => c.ChequesStatusTypeId == chequesStatusTypeId, c => c.Bank, c => c.ChequesStatusType);
            else
                query = paidChequesRepository.SelectAllAsQuerable(c => c.Bank, c => c.ChequesStatusType);
            return query;
        }
        //=================================================
        public PaidChequesModel Find(int Id)
        {
            var result = paidChequesRepository.SingleOrDefault(c => c.Id == Id, c => c.Bank, c => c.ChequesStatusType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=================================================
        public void Update(PaidChequesModel model, int currentUserId)
        {
            using (var studentChequesRepository = new Repository<StudentChequesModel>())
            {
                var sumOfStudentCheques = studentChequesRepository.Where(c => c.PaidChequeId == model.Id, c => c.StudentFinancialPayment).Sum(c => c.StudentFinancialPayment.AmountPaid);
                var remainingAmount = model.AmountPaid - sumOfStudentCheques;
                if (remainingAmount < 0)
                    throw new CustomException("مبلغ چک نبایستی از مبالغ خرج شده چک کمتر باشد");
                 
                var result = paidChequesRepository.SingleOrDefault(c => c.Id == model.Id);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);

                var query = paidChequesRepository.FirstOrDefault(c => c.Id != model.Id && c.FishingCode == model.FishingCode);
                if (query != null) { throw new Exception("کد صیادی وارد شده در سیستم موجود می باشد"); }

                var query2 = paidChequesRepository.FirstOrDefault(c => c.Id != model.Id && c.ChequesNo == model.ChequesNo);
                if (query2 != null) { throw new Exception("شماره چک وارد شده در سیستم موجود می باشد"); }

                result.ModDateTime = DateTime.UtcNow;
                result.ModUserId = currentUserId;
                result.AmountPaid = model.AmountPaid;
                result.IssueDate = model.IssueDate;
                result.Description = model.Description;
                result.ChequesStatusTypeId = (int)model.ChequesStatusTypeId;
                result.DueDate = model.DueDate;
                result.BankId = model.BankId;
                result.RemainingAmount = remainingAmount;
                result.ChequesNo = model.ChequesNo;

                result.AccountNumber = model.AccountNumber;
                result.BranchName = model.BranchName;
                result.BranchCode   = model.BranchCode;
                result.FishingCode = model.FishingCode; 
                result.NameAccountHolder = model.NameAccountHolder;


                paidChequesRepository.Update(result);
                paidChequesRepository.SaveChanges();

            }
        }
        //============================================================
        public void Delete(List<PaidChequesModel> model)
        {
            paidChequesRepository.DeleteRange(model);
            paidChequesRepository.SaveChanges();
        }
        //============================================================
        public int GetRemainingAmount(int Id)
        {
            var result = paidChequesRepository.SingleOrDefault(c => c.Id == Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result.RemainingAmount;
        }
        //============================================================
        public static void Validate(int paidChequeId, int amountPaid)
        {
            using (var paidChequesRepository = new Repository<PaidChequesModel>())
            {
                var result = paidChequesRepository.SingleOrDefault(c => c.Id == paidChequeId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                if (amountPaid > result.RemainingAmount)
                    throw new CustomException("مبلغ وارد شده بیشتر از باقیمانده چک می باشد لطفاً مبلغ را تصحیح نمایید ");
            }
        }
        //=================================================
        public void Dispose()
        {
            paidChequesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
