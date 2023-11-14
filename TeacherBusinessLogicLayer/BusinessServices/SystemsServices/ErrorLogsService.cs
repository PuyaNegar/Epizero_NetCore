using Common.Objects;
using DataModels.SystemsModels;
using System;
using TeacherBusinessLogicLayer.BusinessComponents.SystemsComponents;

namespace TeacherBusinessLogicLayer.BusinessServices.SystemsServices
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
                return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
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
