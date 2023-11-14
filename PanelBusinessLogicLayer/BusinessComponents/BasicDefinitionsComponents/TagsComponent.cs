using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
    public class TagsComponent : IDisposable
    {
        private Repository<TagsModel> tagsRepository;
        //==============================================================================================
        public TagsComponent()
        {
            this.tagsRepository = new Repository<TagsModel>();
        }
        //==============================================================================================
        public IQueryable<TagsModel> Read()
        {
            var result = tagsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(TagsModel model)
        {

            //**********************************************
            var query = tagsRepository.FirstOrDefault(c => c.Title == model.Title);
            if (query != null) { throw new Exception("این تگ در سیستم موجود می باشد"); }
            //**********************************************
            tagsRepository.Add(model);
            tagsRepository.SaveChanges();
        }
        //==============================================================================================
        public TagsModel Find(int Id)
        {
            var result = tagsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(TagsModel model)
        {
            //**********************************************
            var data = tagsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این تگ در سیستم موجود نمی باشد"); }
            var query = tagsRepository.FirstOrDefault(c => c.Id != model.Id && c.Title == model.Title);
            if (query != null) { throw new Exception("این تگ در سیستم موجود می باشد"); }
            //**********************************************
            data.Title = model.Title;
            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = model.ModUserId;
            tagsRepository.Update(data);
            tagsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<TagsModel> model)
        {
            tagsRepository.DeleteRange(model);
            tagsRepository.SaveChanges();
        }
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            tagsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion

    }
}
