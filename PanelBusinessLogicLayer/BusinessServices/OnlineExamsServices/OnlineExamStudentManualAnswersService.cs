using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamStudentManualAnswersService : IDisposable
    {
        private OnlineExamStudentManualAnswersComponent onlineExamStudentManualAnswersComponent;
        //======================================================
        public OnlineExamStudentManualAnswersService()
        {
            onlineExamStudentManualAnswersComponent = new OnlineExamStudentManualAnswersComponent();
        }
        //======================================================
        public SysResult Read(int onlineExamStudentId, int currentUserId)
        {
            var result = onlineExamStudentManualAnswersComponent.Read(onlineExamStudentId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, Value = result };
        }
        //======================================================
        public SysResult Add(int onlineExamStudentId, List<OnlineExamStudentManualAnswerSelectedOptionsViewModel> manualAnswers, int currentUserId)
        {
            onlineExamStudentManualAnswersComponent.Add(onlineExamStudentId, manualAnswers, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamStudentManualAnswersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
