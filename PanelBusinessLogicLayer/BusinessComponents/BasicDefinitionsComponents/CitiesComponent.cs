using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
    public class CitiesComponent :IDisposable
    {
        private Repository<CitiesModel> cityRepository;
        //==============================================================================================
        public CitiesComponent()
        {
            cityRepository = new Repository<CitiesModel>();
        }
        //==============================================================================================

        public void Add(CitiesModel model)
        {
            //**********************************************
            var query = cityRepository.FirstOrDefault(c => c.Name == model.Name);
            if (query != null) { throw new Exception("این شهر در سیستم موجود می باشد"); }
            //**********************************************
            cityRepository.Add(model);
            cityRepository.SaveChanges();
        }
        //==============================================================================================
        public IQueryable<CitiesModel> ReadByProvince(int provinceId)
        {
            var result = cityRepository.Where(c => c.ProvinceId == provinceId).Select(c => new CitiesModel()
            {
                Id = c.Id,
                Name = c.Name,
                IsActive = c.IsActive,
            }).OrderBy(c => c.Id);
            return result;
        }
        //==============================================================================================
        public void Update(CitiesModel model)
        {
            //**********************************************
            var data = cityRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این شهر در سیستم موجود نمی باشد"); }
           var  query = cityRepository.FirstOrDefault(c => c.Id != model.Id && c.Name == model.Name);
            if (query != null) { throw new Exception("این شهر در سیستم موجود می باشد"); }
            //**********************************************
            data.Name = model.Name;
            data.IsActive = model.IsActive;
            data.ModUserId = model.ModUserId;
            data.ModDateTime = model.ModDateTime;
            cityRepository.Update(data);
            cityRepository.SaveChanges();

        }
        //==============================================================================================
        public CitiesModel Find(int Id)
        {
            var result = cityRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            cityRepository.Delete(c=> Ids.Contains(c.Id));
            cityRepository.SaveChanges();
        }
        //==============================================================================================
        public static string GetFullName(int CityId)
        {
            using (var CityRepository = new Repository<CitiesModel>())
            {
                var result = CityRepository.Where(c => c.Id == CityId, c => c.Province)
                           .Select(c => new { CityName = c.Name, ProvinceName = c.Province.Name }).SingleOrDefault();
                return $"{result.ProvinceName} - {result.CityName}";
            }
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
            cityRepository?.Dispose();
        }
        #endregion
    }
}
