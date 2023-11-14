using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class AddStudentFinancialsService : IDisposable
    {
        private AddStudentFinancialsComponent addStudentFinancialsComponent;

        public AddStudentFinancialsService()
        {
            addStudentFinancialsComponent = new AddStudentFinancialsComponent();
        }
        //===============================================================================
        public SysResult Operation(AddStudentFinancialsViewModel viewModel, int currentUserId , CourseMeetingStudentType courseMeetingStudentType)
        {
            var  StudentUserIds  =   viewModel.StudentUserIds.Split(',').Select(Int32.Parse).ToList();
            addStudentFinancialsComponent.Operation(viewModel,   StudentUserIds , currentUserId , courseMeetingStudentType);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.OperationDoneSuccessfully };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            addStudentFinancialsComponent?.Dispose();
            GC.SuppressFinalize(this); 
        }
        #endregion
    }
}
