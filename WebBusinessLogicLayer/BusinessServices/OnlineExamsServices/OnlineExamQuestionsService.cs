using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamQuestionsService : IDisposable
    {
        private OnlineExamQuestionsComponent onlineExamQuestionsComponent;
        public OnlineExamQuestionsService()
        {
            onlineExamQuestionsComponent = new OnlineExamQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<List<OnlineExamQuestionsViewModel>> Read(int onlineExamId)
        {
            var result = onlineExamQuestionsComponent.Read(onlineExamId);
            var viewModel = result.Select(c => new OnlineExamQuestionsViewModel()
            {
                Id = c.Id,
                Option1 = c.OnlineExamMultipleChoiceQuestion.Option1,
                Option2 = c.OnlineExamMultipleChoiceQuestion.Option2,
                Option3 = c.OnlineExamMultipleChoiceQuestion.Option3,
                Option4 = c.OnlineExamMultipleChoiceQuestion.Option4,
                CorrentOption = c.OnlineExamMultipleChoiceQuestion.CorrectOption,
                DescriptiveAnswer = c.OnlineExamMultipleChoiceQuestion.DescriptiveAnswer,
                ContextQuestion = c.OnlineExamMultipleChoiceQuestion.OnlineExamQuestion.QuestionContext
           
            }).ToList();
            return new SysResult<List<OnlineExamQuestionsViewModel>> { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, Value = viewModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
                return;
            }
            onlineExamQuestionsComponent?.Dispose();
        }
        #endregion
    }
}
