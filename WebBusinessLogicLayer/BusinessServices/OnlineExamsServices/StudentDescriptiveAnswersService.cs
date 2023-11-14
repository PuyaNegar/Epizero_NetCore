using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;

namespace WebBusinessLogicLayer.BusinessServices.IdentitiesServices
{
    public class StudentDescriptiveAnswersService : IDisposable
    {
        private StudentDescriptiveAnswersComponent studentDescriptiveAnswersComponent;
        public StudentDescriptiveAnswersService()
        {
            this.studentDescriptiveAnswersComponent = new StudentDescriptiveAnswersComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public SysResult AddOrUpdate(string AnswerContext, int OnlineExamQuestionId, int onlineExamId, int currentUserId)
        {

            studentDescriptiveAnswersComponent.AddOrUpdate(AnswerContext,  OnlineExamQuestionId, onlineExamId, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
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
            studentDescriptiveAnswersComponent?.Dispose();
        }
        #endregion
    }
}
