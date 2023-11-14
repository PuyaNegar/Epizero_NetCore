using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class ProductTypesComponent : IDisposable
    {
        private Repository<ProductTypesModel> productTypesRepository;
        //==============================================================================================
        public ProductTypesComponent()
        {
            this.productTypesRepository = new Repository<ProductTypesModel>();
        }
        //==============================================================================================
        public IQueryable<ProductTypesModel> Read()
        {
            var result = productTypesRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(ProductTypesModel model)
        {

            //**********************************************
            var query = productTypesRepository.FirstOrDefault(c => c.Name == model.Name);
            if (query != null) { throw new Exception("این گروه در سیستم موجود می باشد"); }
            //**********************************************
            productTypesRepository.Add(model);
            productTypesRepository.SaveChanges();
        }
        //==============================================================================================
        public ProductTypesModel Find(int Id)
        {
            var result = productTypesRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(ProductTypesModel model)
        {
            //**********************************************
            var data = productTypesRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این گروه در سیستم موجود نمی باشد"); }
            var query = productTypesRepository.FirstOrDefault(c => c.Id != model.Id && c.Name == model.Name);
            if (query != null) { throw new Exception("این گروه در سیستم موجود می باشد"); }
            //**********************************************
            data.Name = model.Name;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = DateTime.UtcNow;
            productTypesRepository.Update(data);
            productTypesRepository.SaveChanges();
        }
        //==============================================================================================
        public void Delete(List<ProductTypesModel> model)
        {
            productTypesRepository.DeleteRange(model);
            productTypesRepository.SaveChanges();
        }
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            productTypesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
