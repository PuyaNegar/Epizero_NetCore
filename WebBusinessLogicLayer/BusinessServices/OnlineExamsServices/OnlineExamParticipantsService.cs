using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;

namespace WebBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamParticipantsService : IDisposable
    {
        private OnlineExamParticipantsComponent onlineExamParticipantsComponent;
        //================================================================
        public OnlineExamParticipantsService()
        {
            onlineExamParticipantsComponent = new OnlineExamParticipantsComponent();
        }
        //================================================================
        public SysResult<int> Count(int onlineExamId)
        {
            var result = onlineExamParticipantsComponent.Count(onlineExamId);
            return new SysResult<int>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //================================================================
        public void Dispose()
        {
            onlineExamParticipantsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
