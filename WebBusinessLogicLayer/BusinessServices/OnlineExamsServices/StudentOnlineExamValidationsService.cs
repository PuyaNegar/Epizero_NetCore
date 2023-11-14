using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class StudentOnlineExamValidationsService : IDisposable
    {
        private StudentOnlineExamValidationsComponent studentOnlineExamValidationsComponent;
        //==============================================
        public StudentOnlineExamValidationsService()
        {
            studentOnlineExamValidationsComponent = new StudentOnlineExamValidationsComponent();
        }
        //==============================================
        public SysResult Operation(int onlineExamId, int studentUserId)
        {
            double remainingTime = 0;

            using (var addStudentToIndependentOnlineExam = new AddStudentToIndependentOnlineExam())
            {
                addStudentToIndependentOnlineExam.Operation(onlineExamId, studentUserId);
                studentOnlineExamValidationsComponent.Operation(onlineExamId, studentUserId, ref remainingTime, true);
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully };
            } 
        }
        //==============================================
        #region DisposeObjects
        public void Dispose()
        {
            studentOnlineExamValidationsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
