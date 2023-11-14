using Common.Extentions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
   public class StudentFinancialManualDebtsService : IDisposable
    {
        private StudentFinancialManualDebtsComponent studentFinancialManualDebtsComponent;
        //================================================
        public StudentFinancialManualDebtsService()
        {
            studentFinancialManualDebtsComponent = new StudentFinancialManualDebtsComponent();
        }
        //================================================

        public SysResult Add(StudentFinancialManualDebtsViewModel request, int CurrentUserId)
        {
            var model = new StudentFinancialManualDebtsModel()
            {
                CourseMeetingStudentId = request.CourseMeetingStudentId,
                DebtAmount = request.DebtAmount,
                Description = request.Description,
                ModUserId = CurrentUserId,
                RegDateTime = request.RegDateTime.ToDate().ToUtcDateTime(),
                ModDateTime = DateTime.UtcNow
            };
            studentFinancialManualDebtsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };

        }
   
        
        //===============================================================================
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        {
            var model = new StudentFinancialManualDebtsModel()
            {
                Id = viewModel.Id.Value,
            };
             
            studentFinancialManualDebtsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
         
        //=============================================================================== Disposing
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
            studentFinancialManualDebtsComponent?.Dispose();
        }
        #endregion
    }
}
