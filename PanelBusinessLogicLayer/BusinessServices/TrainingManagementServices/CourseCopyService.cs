using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseCopyService : IDisposable
    {
        private CourseCopyComponent courseCopyComponent;
        //==========================================
        public CourseCopyService()
        {
            courseCopyComponent = new CourseCopyComponent();
        }
        //==========================================

        public SysResult Operation(int courseId, int currentUserId )
        {
            courseCopyComponent.Operation(courseId , currentUserId);
            return new SysResult() { IsSuccess = true, Message = "دوره با موفقیت کپی گردید" };
        }
        //==========================================
        public void Dispose()
        {
            courseCopyComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
