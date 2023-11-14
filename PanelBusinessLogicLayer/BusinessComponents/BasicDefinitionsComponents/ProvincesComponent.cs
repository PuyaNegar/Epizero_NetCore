using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
    public class ProvincesComponent : IDisposable
    {
        Repository<ProvincesModel> provinceRepository;
        //==============================================================================================
        public ProvincesComponent()
        {
            provinceRepository = new Repository<ProvincesModel>();
        }
        //==============================================================================================
        public void Add(ProvincesModel model)
        {
            //**********************************************
            var query = provinceRepository.FirstOrDefault(c => c.Name == model.Name);
            if (query != null) { throw new Exception("این استان در سیستم موجود می باشد"); }
            //**********************************************
            provinceRepository.Add(model);
            provinceRepository.SaveChanges();
        }
        //==============================================================================================
        public IQueryable<ProvincesModel> Read()
        {
            var result = provinceRepository.SelectAllAsQuerable().Select(c => new ProvincesModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActive = c.IsActive
            }).OrderBy(p => p.Id);
            return result;
        }
        //==============================================================================================
        public void Update(ProvincesModel model)
        {
            //**********************************************
            var data = provinceRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این استان در سیستم موجود نمی باشد"); }
            var query = provinceRepository.FirstOrDefault(c => c.Id != model.Id && c.Name == model.Name);
            if (query != null) { throw new Exception("این استان در سیستم موجود می باشد"); }
            //********************************************** 
            data.Name = model.Name;
            data.IsActive = model.IsActive;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = model.ModDateTime;
            provinceRepository.Update(data);
            provinceRepository.SaveChanges();
        }
        //==============================================================================================
        public ProvincesModel Find(int Id)
        {
            var result = provinceRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            provinceRepository.Delete(c=> Ids.Contains(c.Id));
            provinceRepository.SaveChanges();
        }
  
        //============================================================================================== Disposing 
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
            provinceRepository?.Dispose();
        }
        #endregion
    }
}
