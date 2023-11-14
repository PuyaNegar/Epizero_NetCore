using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class PaidChequesService : IDisposable
    {
        private PaidChequesComponent paidChequesComponent;
        //====================================================
        public PaidChequesService()
        {
            paidChequesComponent = new PaidChequesComponent();
        }
        //====================================================
        public SysResult Add(PaidChequesViewModel viewModel, int currentUserId)
        {
            var model = new PaidChequesModel()
            {
                AmountPaid = viewModel.AmountPaid,
                BankId = viewModel.BankId,
                ChequesStatusTypeId = viewModel.ChequesStatusTypeId,
                ChequesNo = viewModel.ChequeNo,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate.ToDate(),
                RegDateTime = DateTime.UtcNow,
                IssueDate = viewModel.IssueDate.ToDate(),
                ModUserId = currentUserId,
                RemainingAmount = viewModel.AmountPaid,

                BranchName = viewModel.BranchName,
                FishingCode = viewModel.FishingCode,
                AccountNumber = viewModel.AccountNumber,
                BranchCode = viewModel.BranchCode,
                NameAccountHolder = viewModel.NameAccountHolder,
            };
            paidChequesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, };
        }
        //====================================================
        public SysResult Update(PaidChequesViewModel viewModel, int currentUserId)
        {
            var model = new PaidChequesModel()
            {
                Id = viewModel.Id,
                ModDateTime = DateTime.UtcNow,
                AmountPaid = viewModel.AmountPaid,
                BankId = viewModel.BankId,
                ChequesStatusTypeId = viewModel.ChequesStatusTypeId,
                ChequesNo = viewModel.ChequeNo,
                Description = viewModel.Description,
                DueDate = viewModel.DueDate.ToDate().ToUtcDateTime(),
                IssueDate = viewModel.IssueDate.ToDate().ToUtcDateTime(),

                NameAccountHolder = viewModel.NameAccountHolder,
                BranchCode  = viewModel.BranchCode,
                AccountNumber = viewModel.AccountNumber,
                FishingCode = viewModel.FishingCode,
                BranchName = viewModel.BranchName,

                ModUserId = currentUserId,
            };
            paidChequesComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, };
        }
        //====================================================
        public SysResult<PaidChequesViewModel> Find(int id)
        {
            var result = paidChequesComponent.Find(id);
            var viewModel = new PaidChequesViewModel()
            {
                Id = result.Id,
                AmountPaid = result.AmountPaid,
                BankId = result.BankId,
                RemainingAmount = result.RemainingAmount,
                IssueDate = result.IssueDate.ToLocalDateTime().ToDateShortFormatString(),
                DueDate = result.DueDate.ToLocalDateTime().ToDateShortFormatString(),
                ChequeNo = result.ChequesNo,
                ChequesStatusTypeId = result.ChequesStatusTypeId,
                AccountNumber = result.AccountNumber,
                BranchName = result.BranchName,
                BranchCode = result.BranchCode,
                NameAccountHolder = result.NameAccountHolder,
                FishingCode = result.FishingCode,
                Description = result.Description,
            };
            return new SysResult<PaidChequesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================
        public SysResult Read(int chequesStatusTypeId)
        {
            var result = paidChequesComponent.Read(chequesStatusTypeId).Select(c => new PaidChequesViewModel()
            {
                Id = c.Id,
                AmountPaid = c.AmountPaid,
                IssueDate = c.IssueDate.ToLocalDateTime().ToDateShortFormatString(),
                BankName = c.Bank.Name,
                ChequeNo = c.ChequesNo,
                BankId = c.BankId,
                ChequesStatusTypeId = c.ChequesStatusTypeId,
                Description = c.Description,
                DueDate = c.DueDate.ToLocalDateTime().ToDateShortFormatString(),
                ChequesStatusTypeName = c.ChequesStatusType.Name,
                RemainingAmount = c.RemainingAmount,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //====================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {

            var result = paidChequesComponent.Read(0);

            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}", " چک به شماره ", c.ChequesNo + " ،", " مبلغ ", string.Format("{0:N0}", c.AmountPaid), " تومان " + " ،", " بانک ", c.Bank.Name, " با وضعیت ", c.ChequesStatusType.Name),
                Data = string.Format("{0:N0}", c.RemainingAmount),
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new PaidChequesModel()
            {
                Id = c.Id.Value
            }).ToList();
            paidChequesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //====================================================
        public SysResult<string> GetRemainingAmount(int Id)
        {
            var result = paidChequesComponent.GetRemainingAmount(Id);
            return new SysResult<string>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = string.Format("{0:N0}", result) };
        }
        //====================================================
        public void Dispose()
        {
            paidChequesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
