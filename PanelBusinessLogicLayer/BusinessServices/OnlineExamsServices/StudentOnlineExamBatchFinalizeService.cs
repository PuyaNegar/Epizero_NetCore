using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using System;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class StudentOnlineExamBatchFinalizeService : IDisposable
    {
        private StudentOnlineExamBatchFinalizeComponent studentOnlineExamBatchFinalizeComponent;
        //=======================================================
        public StudentOnlineExamBatchFinalizeService()
        {
            studentOnlineExamBatchFinalizeComponent = new StudentOnlineExamBatchFinalizeComponent();
        }
        //=======================================================
        public SysResult Operation(int onlineExamId)
        {

            studentOnlineExamBatchFinalizeComponent.Operation(onlineExamId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentOnlineExamBatchFinalizeComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
