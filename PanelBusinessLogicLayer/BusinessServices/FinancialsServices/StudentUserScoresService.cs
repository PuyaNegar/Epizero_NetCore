using Common.Objects;
using System;
using Common.Extentions;
using System.Linq;
using WebDTOModels.IdentitiesDTOModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.FinancialsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class StudentUserScoresService : IDisposable
    {
        private StudentUserScoresComponent userScoresComponent;
        //=========================================================
        public StudentUserScoresService()
        {
            userScoresComponent = new StudentUserScoresComponent();
        }
        //=========================================================
        public SysResult Read(string userName)
        { 
            var result = userScoresComponent.Read(userName);
            var viewModel = result.Select(c => new StudentUserScoresViewModel()
            {
                Id = c.Id,
                CustomerScoreTypeName = c.UserScoreType.Name,
                Description = c.Description,
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                Score = c.Score,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult<BalanceViewModel> GetBalance(string username)
        {
            using (var studentUsersComponent = new StudentUsersComponent())
            {
                var studentUserId  = studentUsersComponent.GetCustomerId(username);
                var result = userScoresComponent.GetBalance(studentUserId);
                var viewModel = new BalanceViewModel()
                {
                    StudentUserId = studentUserId,
                    Balance = result != 0 ? result : 0,
                };
                return new SysResult<BalanceViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
            }
        }
        //========================================================================================
        public SysResult ChangeCredit(ChangeScoreViewModel viewModel, int modUserId)
        {
            userScoresComponent.ChangeCredit(viewModel, modUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully, Value = null };
        }
        //========================================================= 
        public void Dispose()
        {
            userScoresComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
