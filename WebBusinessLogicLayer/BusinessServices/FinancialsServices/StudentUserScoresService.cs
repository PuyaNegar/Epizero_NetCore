using Common.Objects;
using System;
using Common.Extentions;
using System.Linq;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.FinancialsServices
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
        public SysResult Read(int userId)
        {
            var result = userScoresComponent.Read(userId);
            var viewModel = result.Select(c => new StudentUserScoresViewModel()
            {
                Id = c.Id,
                CustomerScoreTypeName = c.UserScoreType.Name,
                Description = c.Description,
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                Score = c.Score,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================================================
        public SysResult<ScoreBalanceViewModel> GetBalance(int studentUserId)
        {
            var result = userScoresComponent.GetBalance(studentUserId);
            var viewModel = new ScoreBalanceViewModel()
            {
                StudentUserId = studentUserId,
                Balance = result != 0 ? result : 0,
            };
            return new SysResult<ScoreBalanceViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //========================================================= 
        public void Dispose()
        {
            userScoresComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
