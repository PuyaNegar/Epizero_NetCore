using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using System;
using System.Collections.Generic;
using System.Text;


namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class StudentOnlineExamResultsResetService : IDisposable
    {
        private StudentOnlineExamResultsResetComponent studentOnlineExamResultsResetComponent;
        //===================================================
        public StudentOnlineExamResultsResetService()
        {
            studentOnlineExamResultsResetComponent = new  StudentOnlineExamResultsResetComponent(); 
        }
        //===================================================
        public SysResult Operation(int onlineExamStudentId )
        {
            studentOnlineExamResultsResetComponent.Operation(onlineExamStudentId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully }; 
        }
        //===================================================
        public void Dispose()
        {
            studentOnlineExamResultsResetComponent?.Dispose(); 
        }
    }
}
