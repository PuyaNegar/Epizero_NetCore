using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class AddStudentToIndependentOnlineExamService : IDisposable
    {
        AddStudentToIndependentOnlineExamComponent addStudentToIndependentOnlineExamComponent;

        public AddStudentToIndependentOnlineExamService()
        {
            addStudentToIndependentOnlineExamComponent = new AddStudentToIndependentOnlineExamComponent();
        }
        //=========================================================
        public SysResult Operation(List<int> studentUserIds, int onlineExamId)
        {
            addStudentToIndependentOnlineExamComponent.Operation(studentUserIds, onlineExamId);
            return new SysResult() { IsSuccess = true, Message = "دانش آموز با موفقیت به لیست افزوده شد" };
        }
        //=========================================================
        public void Dispose()
        {
            addStudentToIndependentOnlineExamComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
