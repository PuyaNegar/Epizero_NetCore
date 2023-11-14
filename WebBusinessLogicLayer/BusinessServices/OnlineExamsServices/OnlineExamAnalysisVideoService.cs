using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using System;
using System.Collections.Generic;
using System.Text;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
   public class OnlineExamAnalysisVideoService : IDisposable
    {

        private OnlineExamAnalysisVideoComponent onlineExamAnalysisVideoComponent;
        //=======================================
        public OnlineExamAnalysisVideoService()
        {
            onlineExamAnalysisVideoComponent = new OnlineExamAnalysisVideoComponent();
        }
        //=======================================
 
        public SysResult<OnlineExamsViewModel> Find(int id)
        {
            var result = onlineExamAnalysisVideoComponent.Find(id);
            var model = new OnlineExamsViewModel()
            {
                //Id = result.Id,
                //Name = result.Name,
                //StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                //StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                //QuestionTypeId = result.QuestionTypeId,
                //QuestionTypeName = result.QuestionType.Name,
                //TeacherUserId = result.TeacherUserId,
                //Duration = result.Duration,
                //MaxGrade = result.MaxGrade,
                //AllowedTimeToEnter = result.AllowedTimeToEnter,
                //IsRandomOption = result.IsRandomOption.ToActiveStatus(),
                //IsRandomOptionName = result.IsRandomOption ? "بلی" : "خیر",
                //IsRandomQuestions = result.IsRandomQuestions.ToActiveStatus(),
                //IsRandomQuestionsName = result.IsRandomQuestions ? "بلی" : "خیر",
                //HasNegativePoint = result.HasNegativePoint.ToActiveStatus(),
                //HasNegativePointName = result.HasNegativePoint ? "بلی" : "خیر",
                //OnlineExamType = (OnlineExamType)result.OnlineExamTypeId,
                AnalysisVideoLink = result.AnalysisVideoLink
            };
            return new SysResult<OnlineExamsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamAnalysisVideoComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
