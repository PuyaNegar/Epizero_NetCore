using System;
using System.Linq;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class FieldsComponent:IDisposable

    {
        private Repository<FieldsModel> fieldsRepository;
        //============================================================
        public FieldsComponent()
        {
            fieldsRepository = new Repository<FieldsModel>();
        } 
        //============================================================
        public IQueryable<FieldsModel> Read()
        {
            var result = fieldsRepository.Where(c=>c.IsActive);
            return result;
        } 
        //============================================================
        public FieldsModel Find(int id)
        {
            var result = fieldsRepository.SingleOrDefault(c => c.Id == id&& c.IsActive);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
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
            fieldsRepository?.Dispose();
        }
        #endregion
    }
}
