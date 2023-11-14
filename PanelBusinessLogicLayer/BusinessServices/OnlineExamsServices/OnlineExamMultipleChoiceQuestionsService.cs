using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamMultipleChoiceQuestionsService : IDisposable
    {
        private OnlineExamMultipleChoiceQuestionsComponent onlineExamMultipleChoiceQuestionsComponent;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamMultipleChoiceQuestionsService()
        {
            this.onlineExamMultipleChoiceQuestionsComponent = new OnlineExamMultipleChoiceQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(OnlineExamMultipleChoiceQuestionsViewModel request, int currentUserId)
        {
            var model = new OnlineExamMultipleChoiceQuestionsModel()
            {
                Id = request.Id,

                Option1_CkFormat = request.Option1_CkFormat ,
                Option2_CkFormat = request.Option2_CkFormat,
                Option3_CkFormat = request.Option3_CkFormat,
                Option4_CkFormat = request.Option4_CkFormat ,

                Option1 = request.Option1,
                Option2 = request.Option2,
                Option3 = request.Option3,
                Option4 = request.Option4,

                IsTextOption1 = request.IsTextOption1.ToBoolean(),
                IsTextOption2 = request.IsTextOption2.ToBoolean(),
                IsTextOption3 = request.IsTextOption3.ToBoolean(),
                IsTextOption4 = request.IsTextOption4.ToBoolean(),
              
                DescriptiveAnswer = request.DescriptiveAnswer,
                DescriptiveAnswer_CkFormat = request.DescriptiveAnswer_CkFormat , 
                  

                CorrectOption = request.CorrectOption,
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow,
                OnlineExamQuestion = new OnlineExamQuestionsModel()
                {
                    QuestionContext = request.QuestionContext,
                    QuestionContext_CkFormat = request.QuestionContext_CkFormat,
                    IsTextQuestionContext = request.IsTextQuestionContext.ToBoolean(),
                    ModUserId = currentUserId,
                    ModDateTime = DateTime.UtcNow,
                },
            };
            onlineExamMultipleChoiceQuestionsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<OnlineExamMultipleChoiceQuestionsViewModel> Find(int id /*, int currentUserId*/ )
        {
            var result = onlineExamMultipleChoiceQuestionsComponent.Find(id /*, currentUserId*/ );
            var model = new OnlineExamMultipleChoiceQuestionsViewModel()
            {
                Id = result.Id,
                DescriptiveAnswer_CkFormat = result.DescriptiveAnswer_CkFormat,
                QuestionContext_CkFormat = result.OnlineExamQuestion.QuestionContext_CkFormat,
                Option1_CkFormat = result.Option1_CkFormat,
                Option2_CkFormat = result.Option2_CkFormat,
                Option3_CkFormat = result.Option3_CkFormat,
                Option4_CkFormat = result.Option4_CkFormat,
                 
                IsTextOption1 = result.IsTextOption1.ToActiveStatus(),
                IsTextOption2 = result.IsTextOption2.ToActiveStatus(),
                IsTextOption3 = result.IsTextOption3.ToActiveStatus(),
                IsTextOption4 = result.IsTextOption4.ToActiveStatus(),
                CorrectOption = result.CorrectOption,
                IsTextQuestionContext = result.OnlineExamQuestion.IsTextQuestionContext.ToActiveStatus(),
            };
            return new SysResult<OnlineExamMultipleChoiceQuestionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
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
            onlineExamMultipleChoiceQuestionsComponent?.Dispose();
        }
        #endregion
    }
}
