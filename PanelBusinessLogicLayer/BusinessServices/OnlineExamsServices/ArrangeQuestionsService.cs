using Common.Functions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
  public class ArrangeQuestionsService : IDisposable
    {
        private ArrangeQuestionsComponent arrangeQuestionsComponent;
        public ArrangeQuestionsService()
        {
            this.arrangeQuestionsComponent = new ArrangeQuestionsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public SysResult  Update(List<ArrangeQuestionsViewModel> viewModel   )
        {
            if (!viewModel.Any())
                throw new CustomException("هیچ لیستی جهت بروزرسانی اولویت سوال انتخاب نشده است");
            arrangeQuestionsComponent.Update(viewModel);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };  
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            arrangeQuestionsComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
