//using Common.Objects;
//using System;
//using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;

//namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
//{
//    public class OnlineExamStudentAnswerFilesService : IDisposable
//    {
//        private OnlineExamStudentAnswerFilesComponent onlineExamStudentAnswerFilesComponent;
//        public OnlineExamStudentAnswerFilesService()
//        {
//            this.onlineExamStudentAnswerFilesComponent = new OnlineExamStudentAnswerFilesComponent();
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        public SysResult Add(int onlineExamId, int currentUserId, string FilePath)
//        {
//            onlineExamStudentAnswerFilesComponent.Add(onlineExamId, currentUserId, FilePath);
//            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded  };
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        public SysResult Delete(int onlineExamId,      int currentUserId)
//        {
//            onlineExamStudentAnswerFilesComponent.Delete(onlineExamId,   currentUserId);
//            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
//        #region DisposeObject
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposing)
//            {
//                return;
//            }
//            onlineExamStudentAnswerFilesComponent?.Dispose();
//        }
//        #endregion
//    }
//}
