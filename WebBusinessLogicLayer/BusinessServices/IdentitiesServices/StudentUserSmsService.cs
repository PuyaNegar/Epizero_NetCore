using Common.Objects;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentUserSmsService : IDisposable
    {
        private StudentUserSmsOptionsComponent studentUserSmsOptionsComponent;
        public StudentUserSmsService()
        {
            studentUserSmsOptionsComponent = new StudentUserSmsOptionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<StudentUserSmsViewModel> Read(int studentUserId)
        {
            var studentUserCreditTask = GetStudentUserCreditTask(studentUserId);
            var userSmsCreditTask = GetUserSmsCreditTask(studentUserId);
            var studentUserSmsOptionsTask = GetStudentUserSmsOptionsTask(studentUserId);
            Task.WaitAll(studentUserCreditTask, userSmsCreditTask, studentUserSmsOptionsTask);
            var model = new StudentUserSmsViewModel()
            {
                StudentUserCredit = studentUserCreditTask.Result,
                StudentUserSmsOptions = studentUserSmsOptionsTask.Result,
                UserSmsCredit = userSmsCreditTask.Result,
            };
            return new SysResult<StudentUserSmsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(List<int> smsOptionIds, int studentUserId)
        {
            var model = smsOptionIds.Select(c => new StudentUserSmsOptionsModel()
            {
                RegDateTime = DateTime.UtcNow,
                ModUserId = studentUserId,
                SmsOptionId = c,
                StudentUserId = studentUserId,
            }).ToList();
            studentUserSmsOptionsComponent.Add(studentUserId, model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult IncreaseCredit (int studentUserId  , int amount )
        {
            using(var userSmsCreditsComponent = new UserSmsCreditsComponent())
            {
                userSmsCreditsComponent.Increase(studentUserId, amount);
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully }; 
            }
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<int> GetStudentUserCreditTask(int studentUserId)
        {
            var task = new Task<int>(() =>
            {
                using (var studentUserFinincesComponent = new StudentUserFinincesComponent())
                {
                    var result = studentUserFinincesComponent.GetBalance(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<int> GetUserSmsCreditTask(int studentUserId)
        {
            var task = new Task<int>(() =>
            {
                using (var userSmsCreditsComponent = new UserSmsCreditsComponent())
                {
                    var result = userSmsCreditsComponent.GetBalance(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<List<StudentUserSmsOptionsViewModel>> GetStudentUserSmsOptionsTask(int studentUserId)
        {
            var task = new Task<List<StudentUserSmsOptionsViewModel>>(() =>
            {
                using (var studentUserSmsOptionsComponent = new StudentUserSmsOptionsComponent())
                {
                    var result = studentUserSmsOptionsComponent.Read(studentUserId);
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Dispise
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
                studentUserSmsOptionsComponent?.Dispose();
                return;
            }
        }
        #endregion
    }
}
