using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.ApplicationDatabase;
using Common.Extentions;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebViewModels.FinancialsViewModels;
using Common.Enums;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentFinancialSummaryService : IDisposable
    {
        private StudentFinancialPaymentsComponent studentFinancialPaymentsComponent;
        //=================================================
        public StudentFinancialSummaryService()
        {
            studentFinancialPaymentsComponent = new StudentFinancialPaymentsComponent();
        }
        //================================================  
        public SysResult Read(int studentUserId)
        {
            var studentFinancialPaymentsTask = GetStudentFinancialPaymentsTask(studentUserId);
            var studentFinancialDebtsTask = GetStudentFinancialDebtsTask(studentUserId);
            var studentFinancialManualDebtsTask = GetStudentFinancialManualDebtsTask(studentUserId);
            var studentFinesTask = GetStudentFinesTask(studentUserId);
            var studentFinancialReturnPaymentsTask = GetStudentFinancialReturnPaymentsTask(studentUserId);
            Task.WaitAll(studentFinancialPaymentsTask, studentFinancialDebtsTask, studentFinesTask, studentFinancialReturnPaymentsTask);
            var model = new StudentFinanciaSummaryViewModel()
            {
                StudentFinancialDebts = studentFinancialDebtsTask.Result,
                StudentFinancialManualDebts = studentFinancialManualDebtsTask.Result,
                StudentFinancialPayments = studentFinancialPaymentsTask.Result,
                TotalDebts = studentFinancialDebtsTask.Result.Where(c=>!c.IsCanceled).Sum(c => c.DebtAmount),
                StudentFines = studentFinesTask.Result,
                StudentFinancialReturnPayments = studentFinancialReturnPaymentsTask.Result,
                TotalFines = studentFinesTask.Result.Sum(c => c.Amount),
                TotalReturn = studentFinancialReturnPaymentsTask.Result.Sum(c => c.ReturnAmount),
                TotalPayments = studentFinancialPaymentsTask.Result.Sum(c => c.AmountPaid),
                TotalManualDebts = studentFinancialManualDebtsTask.Result.Sum(c => c.DebtAmount),
            };
            model.TotalSum = (model.TotalPayments   - model.TotalReturn) - (model.TotalDebts + model.TotalFines + model.TotalManualDebts);
            if (model.TotalSum >= 0)
                model.IsDebt = false;
            else 
                model.IsDebt = true; 
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=======================================================
        public SysResult<StudentFinancialPaymentsViewModel> Find(int Id, int studentUserId)
        {
            var result = studentFinancialPaymentsComponent.Find(Id, studentUserId);
            var viewModel = new StudentFinancialPaymentsViewModel()
            {
                AmountPaid = result.AmountPaid,
                StudentFinancialPaymentType = result.StudentFinancialPaymentType.Name,
                Description = result.Description,
                AmountPaidDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                Id = result.Id
            };
            return new SysResult<StudentFinancialPaymentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=======================================================
        public SysResult<StudentFinancialChequePaymentsViewModel> FindCheque(int chequeId, int studentUserId)
        {
            var result = studentFinancialPaymentsComponent.FindCheque(chequeId, studentUserId);
            var viewModel = new StudentFinancialChequePaymentsViewModel()
            {
                AmountPaid = result.StudentFinancialPayment.AmountPaid,
                Bank = result.PaidCheque.Bank.Name,
                ChequeNo = result.PaidCheque.ChequesNo,
                RegDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                Description = result.StudentFinancialPayment.Description,
                DueDate = result.PaidCheque.DueDate.ToLocalDateTime().ToDateShortFormatString(),
                StudentUserId = result.StudentFinancialPayment.StudentUserId,
            };
            return new SysResult<StudentFinancialChequePaymentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        } 
        //=======================================================
        public SysResult<StudentFinancialPosPaymentsViewModel> FindPosPayment(int posPaymentId, int studentUserId)
        {
            var result = studentFinancialPaymentsComponent.FindPosPayment(posPaymentId, studentUserId);
            var viewModel = new StudentFinancialPosPaymentsViewModel()
            {
                AmountPaid = result.StudentFinancialPayment.AmountPaid,
                //BankId = result.BankId, 
                RegDateTime = result.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                TrackingNo = result.TrackingNo, 
                Description = result.StudentFinancialPayment.Description,  
                StudentUserName = result.StudentFinancialPayment.StudentUser.FirstName + " " + result.StudentFinancialPayment.StudentUser.LastName,
            };
            return new SysResult<StudentFinancialPosPaymentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        } 
        //================================================  
        Task<List<StudentFinancialPaymentsViewModel>> GetStudentFinancialPaymentsTask(int studentUserId)
        {
            var task = new Task<List<StudentFinancialPaymentsViewModel>>(() =>
            {
                using (var studentFinancialPaymentsComponent = new StudentFinancialPaymentsComponent())
                {
                    var result = studentFinancialPaymentsComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //================================================  
        Task<List<StudentFinancialDebtsViewModel>> GetStudentFinancialDebtsTask(int studentUserId)
        {
            var task = new Task<List<StudentFinancialDebtsViewModel>>(() =>
            {
                using (var studentFinancialDebtsComponent = new StudentFinancialDebtsComponent(new MainDBContext()))
                {
                    var result = studentFinancialDebtsComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //================================================  
        Task<List<StudentFinancialManualDebtsViewModel>> GetStudentFinancialManualDebtsTask(int studentUserId)
        {
            var task = new Task<List<StudentFinancialManualDebtsViewModel>>(() =>
            {
                using (var studentFinancialManualDebtsComponent = new StudentFinancialManualDebtsComponent())
                {
                    var result = studentFinancialManualDebtsComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=======================================================
        Task<List<StudentFinesViewModel>> GetStudentFinesTask(int studentUserId)
        {
            var task = new Task<List<StudentFinesViewModel>>(() =>
            {
                using (var studentFinesComponent = new StudentFinesComponent())
                {
                    var result = studentFinesComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=======================================================
        Task<List<StudentFinancialReturnPaymentsViewModel>> GetStudentFinancialReturnPaymentsTask(int studentUserId)
        {
            var task = new Task<List<StudentFinancialReturnPaymentsViewModel>>(() =>
            {
                using (var studentFinancialReturnPaymentsComponent = new StudentFinancialReturnPaymentsComponent())
                {
                    var result = studentFinancialReturnPaymentsComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //========================================================================================
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialPaymentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
