using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamStudentAnswersService : IDisposable
    {
        private OnlineExamStudentAnswersComponent onlineExamStudentAnswersComponent;
        //===============================================================
        public OnlineExamStudentAnswersService()
        {
            onlineExamStudentAnswersComponent = new OnlineExamStudentAnswersComponent(); 
        }
        //===============================================================
        public SysResult<OnlineExamStudentAnswersViewModel> Read(int onlineExamStudentId)
        {
            var result = onlineExamStudentAnswersComponent.Read(onlineExamStudentId);
            return new SysResult<OnlineExamStudentAnswersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamStudentAnswersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
