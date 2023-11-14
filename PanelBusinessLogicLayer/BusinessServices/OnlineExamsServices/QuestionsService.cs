using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class QuestionsService : IDisposable
    {
        private QuestionsComponent questionsComponent;
        public QuestionsService()
        {
            this.questionsComponent = new QuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int LessonId, QuestionType questionType, ActiveStatus isSelectAllTeacherQuestion, int  currentUserId)
        {
            var result = questionsComponent.Read(LessonId , questionType , isSelectAllTeacherQuestion , currentUserId).Select(c => new QuestionsViewModel()
            {
                Id = c.Id,
                QuestionContext = c.QuestionContext,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            questionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
