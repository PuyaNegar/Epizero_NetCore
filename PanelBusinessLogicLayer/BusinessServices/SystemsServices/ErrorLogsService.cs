using PanelBusinessLogicLayer.BusinessComponents.SystemsComponents;
using Common.Objects; 
using System;
using DataModels.SystemsModels;

namespace PanelBusinessLogicLayer.BusinessServices.SystemsServices
{
    public class ErrorLogsService : IDisposable
    {
        private ErrorLogsComponent errorLogsComponent;
        //===============================================================================
        public ErrorLogsService()
        {
            errorLogsComponent = new ErrorLogsComponent();
        }
        //===============================================================================
        public SysResult Add(string errorMessage, string errorSource)
        {
            try
            {
                var model = new ErrorLogsModel()
                {
                    ErrorMessage = errorMessage,
                    ErrorSource = errorSource,
                    OccureDateTime = DateTime.UtcNow
                };
                errorLogsComponent.Add(model);
                return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد" };
            }
            catch (Exception ex)
            {
                return new SysResult() { IsSuccess = false, Message = ex.Message  };
            } 
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
            errorLogsComponent?.Dispose();
        }
        #endregion
    }
}
