using Common.Objects;
using System;
using System.Collections.Generic;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using WebViewModels.OnlineExamsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentOnlineExamQuestionsService : IDisposable
    {
        private StudentOnlineExamQuestionsComponent studentOnlineExamQuestionsComponent;
        public StudentOnlineExamQuestionsService()
        {
            this.studentOnlineExamQuestionsComponent = new StudentOnlineExamQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<List<StudentOnlineExamQuestionsViewModel>> Read(int onlineExamId, int studentUserId)
        {
            var result = studentOnlineExamQuestionsComponent.Read(onlineExamId, studentUserId);
            return new SysResult<List<StudentOnlineExamQuestionsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            studentOnlineExamQuestionsComponent?.Dispose();
        }
        #endregion
    }
}
