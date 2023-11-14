using DataAccessLayer.Repositories;
using DataModels.SystemsModels;
using DataModels.SystemsModels;
using System;

namespace WebBusinessLogicLayer.BusinessComponents.Systems
{
    public class ErrorLogsComponent : IDisposable
    {
        private Repository<ErrorLogsModel> errorLogsRepository;
        //===============================================================================
        public ErrorLogsComponent()
        {
            errorLogsRepository = new Repository<ErrorLogsModel>();
        }
        //===============================================================================
        public void Add(ErrorLogsModel data)
        {
            var model = new ErrorLogsModel()
            {
                ErrorMessage = data.ErrorMessage,
                ErrorSource = data.ErrorSource,
                OccureDateTime = DateTime.UtcNow
            };
            errorLogsRepository.Add(model);
            errorLogsRepository.SaveChanges();
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
            errorLogsRepository?.Dispose();
        }
        #endregion
    }
}
