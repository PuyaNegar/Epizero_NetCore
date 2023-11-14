using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class IndependentOnlineExamsCopyService : IDisposable
    {
        private IndependentOnlineExamsCopyComponent independentOnlineExamsComponent;
        //==========================================
        public IndependentOnlineExamsCopyService()
        {
            independentOnlineExamsComponent = new IndependentOnlineExamsCopyComponent();
        }
        //==========================================

        public SysResult Operation(int courseId, int currentUserId)
        {
            independentOnlineExamsComponent.Operation(courseId, currentUserId);
            return new SysResult() { IsSuccess = true, Message = "دوره با موفقیت کپی گردید" };
        }
        //==========================================
        public void Dispose()
        {
            independentOnlineExamsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
