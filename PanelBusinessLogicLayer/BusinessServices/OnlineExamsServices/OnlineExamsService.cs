using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamsService : IDisposable
    {
        private OnlineExamsComponent onlineExamsComponent;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamsService()
        {
            this.onlineExamsComponent = new  OnlineExamsComponent();
        }  
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<OnlineExamsViewModel> Find(int id)
        {
            var result = onlineExamsComponent.Find(id);
            var model = new OnlineExamsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                QuestionTypeId = result.QuestionTypeId,
                QuestionTypeName = result.QuestionType.Name,
                TeacherUserId = result.TeacherUserId,
                Duration = result.Duration,
                MaxGrade = result.MaxGrade,
                AllowedTimeToEnter = result.AllowedTimeToEnter,
                IsRandomOption = result.IsRandomOption.ToActiveStatus(),
                IsRandomQuestions = result.IsRandomQuestions.ToActiveStatus(),
                HasNegativePoint = result.HasNegativePoint.ToActiveStatus(),
            };
            return new SysResult<OnlineExamsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamsComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
