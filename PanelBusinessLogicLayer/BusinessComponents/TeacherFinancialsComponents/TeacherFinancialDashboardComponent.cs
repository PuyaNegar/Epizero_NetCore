using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using DataAccessLayer.StoredProcedures;
using PanelViewModels.TeacherFinancialsViewModels;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents
{
    public class TeacherFinancialDashboardComponent : IDisposable
    {
        private Repository<TeacherSattlementSchedulesModel> teacherSattlementSchedulesRepository;
        //===========================================
        public TeacherFinancialDashboardComponent()
        {
            teacherSattlementSchedulesRepository = new Repository<TeacherSattlementSchedulesModel>();
        }
        //===========================================
        public TeacherFinancialDashboardViewModel Read(int teacherUserId)
        {
            TeacherPaymentMethodBatchUpdater.Execute(teacherUserId);
            var balanceTask = GetBalanceTask(teacherUserId);
            var teacherSattlementsTask = GetTeacherSattlementsTask(teacherUserId);
            var teacherSattlementSchedulesTask = GetTeacherSattlementSchedulesTask(teacherUserId);
            Task.WaitAll(balanceTask, teacherSattlementsTask, teacherSattlementSchedulesTask);
            var viewModel = new TeacherFinancialDashboardViewModel()
            {
                Balance = balanceTask.Result,
                LastSettledAmount = teacherSattlementsTask.Result == null ? 0 : teacherSattlementsTask.Result.SettledAmount,
                LastSettledDate = teacherSattlementsTask.Result == null ? "ثبت نشده" : teacherSattlementsTask.Result.Date.ToLocalDateTime().ToDateShortFormatString(),
                NextSettledDate = teacherSattlementSchedulesTask.Result == null ? "ثبت نشده" : teacherSattlementSchedulesTask.Result.Date.ToLocalDateTime().ToDateShortFormatString(),
            };
            return viewModel;
        }
        //===========================================
        Task<TeacherSattlementsModel> GetTeacherSattlementsTask(int teacherUserId)
        {
            var task = new Task<TeacherSattlementsModel>(() =>
            {
                using (var teacherSattlementsRepository = new Repository<TeacherSattlementsModel>())
                {
                    var result = teacherSattlementsRepository.Where(c => c.TeacherSattlementSchedules.TeacherPaymentMethod.TeacherUserId == teacherUserId)
                       .OrderByDescending(c => c.Date).FirstOrDefault();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===========================================
        Task<TeacherSattlementSchedulesModel> GetTeacherSattlementSchedulesTask(int teacherUserId)
        {
            var task = new Task<TeacherSattlementSchedulesModel>(() =>
            {
                using (var teacherSattlementSchedulesRepository = new Repository<TeacherSattlementSchedulesModel>())
                {
                    var result = teacherSattlementSchedulesRepository.Where(c => c.TeacherPaymentMethod.TeacherUserId == teacherUserId && !c.IsSettled)
                       .OrderBy(c => c.Date).FirstOrDefault();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //============================================
        Task<long> GetBalanceTask(int teacherUserId)
        {
            var task = new Task<long>(() =>
            {
                using (var teacherPaymentMethodsRepository = new Repository<TeacherPaymentMethodsModel>())
                {
                    var result = teacherPaymentMethodsRepository.Where(c => c.TeacherUserId == teacherUserId).GroupBy(c => c.TeacherUserId).Select(c => new
                    {
                        Balance = c.Sum(d => d.TotalDebtAmount) - c.Sum(d => d.TotalSattledAmount)
                    }).FirstOrDefault();
                    return result == null ? 0 : result.Balance;
                }
            });
            task.Start();
            return task;
        }
        //=========================================== 
        #region DisposeObject
        public void Dispose()
        {
            teacherSattlementSchedulesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
