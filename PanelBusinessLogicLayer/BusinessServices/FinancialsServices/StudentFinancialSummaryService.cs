using Common.Objects;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using System.Threading.Tasks;
using DataAccessLayer.ApplicationDatabase;
using DataModels.FinancialsModels;
using Common.Extentions;
using Common.Enums;
using Common.Functions;
using PanelViewModels.BaseViewModels;
using DataModels.IdentitiesModels;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
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
        public SysResult<StudentFinanciaSummaryViewModel> Read(int studentUserId)
        {
            if (studentUserId == -1)
                return new SysResult<StudentFinanciaSummaryViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = new StudentFinanciaSummaryViewModel() { } };

            var studentFinancialPaymentsTask = GetStudentFinancialPaymentsTask(studentUserId);
            var studentFinancialDebtsTask = GetStudentFinancialDebtsTask(studentUserId);
            var studentFinancialManualDebtsTask = GetStudentFinancialManualDebtsTask(studentUserId);
            var studentFinesTask = GetStudentFinesTask(studentUserId);
            var studentFinancialReturnPaymentsTask = GetStudentFinancialReturnPaymentsTask(studentUserId);
            var userTask = GetUserTask(studentUserId);
            Task.WaitAll(studentFinancialPaymentsTask, studentFinancialDebtsTask, userTask , studentFinesTask, studentFinancialReturnPaymentsTask);
            var model = new StudentFinanciaSummaryViewModel()
            {
                StudentFullName = userTask.Result.FirstName + " " + userTask.Result.LastName , 
                StudentFinancialDebts = studentFinancialDebtsTask.Result,
                StudentFinancialManualDebts = studentFinancialManualDebtsTask.Result,
                StudentFinancialPayments = studentFinancialPaymentsTask.Result,
                TotalDebts = studentFinancialDebtsTask.Result.Where(c=> !c.IsCanceled).Sum(c => c.DebtAmount),
                StudentFines = studentFinesTask.Result,
                StudentFinancialReturnPayments = studentFinancialReturnPaymentsTask.Result,
                TotalFines = studentFinesTask.Result.Sum(c => c.Amount),
                TotalReturn = studentFinancialReturnPaymentsTask.Result.Sum(c => c.ReturnAmount),
                TotalPayments = studentFinancialPaymentsTask.Result .Sum(c => c.AmountPaid),
                TotalManualDebts = studentFinancialManualDebtsTask.Result.Sum(c=>c.DebtAmount) , 
            };
            model.TotalSum = (model.TotalPayments   - model.TotalReturn) - (model.TotalDebts + model.TotalFines + model.TotalManualDebts);
            if (model.TotalSum >= 0)
                model.IsDebt = false;
            else
                model.IsDebt = true; 
            return new SysResult<StudentFinanciaSummaryViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //============================================
        public SysResult Add(AddStudentFinancialPaymentsViewModel viewModel, int currentUserId)
        {
            var model = new StudentFinancialPaymentsModel()
            {
                AmountPaid = viewModel.AmountPaid,
                RequestReferenceNumber = viewModel.RequestReferenceNumber,  
                Description = viewModel.Description,
                RegDateTime = viewModel.RegDateTime.ToDate().ToUtcDateTime(),
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                CourseMeetingStudentId = viewModel.CourseMeetingStudentId , 
                StudentUserId = viewModel.StudentUserId,
                StudentFinancialPaymentTypeId = viewModel.StudentFinancialPaymentTypeId,
            };
            studentFinancialPaymentsComponent.Add(model , (PaymentType) viewModel.PaymentTypeId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }  //==================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        {
            var model = new StudentFinancialPaymentsModel()
            {
                Id = viewModel.Id.Value,
            };
            studentFinancialPaymentsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================================  
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
        Task<UsersModel> GetUserTask(int? studentUserId)
        {
            var task = new Task<UsersModel>(() =>
            {
                if (studentUserId == null)
                    return new UsersModel() { };
                using (var studentUsersComponent = new StudentUsersComponent())
                {
                    var result = studentUsersComponent.Find(studentUserId.Value);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //================================================  
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
        //================================================  
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
