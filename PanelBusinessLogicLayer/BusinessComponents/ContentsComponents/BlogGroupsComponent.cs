using System;
using System.Collections.Generic;
using System.Linq;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class BlogGroupsComponent : IDisposable
    {
        private Repository<BlogGroupsModel> BlogGroupsrepository;
        //============================================================
        public BlogGroupsComponent()
        {
            BlogGroupsrepository = new Repository<BlogGroupsModel>();
        }
        //============================================================
        public void Add(BlogGroupsModel model)
        {
            BlogGroupsrepository.Add(model);
            BlogGroupsrepository.SaveChanges();
        }
        //============================================================
        public IQueryable<BlogGroupsModel> Read()
        {
            var result = BlogGroupsrepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public BlogGroupsModel Find(int id)
        {
            var result = BlogGroupsrepository.SingleOrDefault(c => c.Id == id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Update(BlogGroupsModel model)
        {
            var result = BlogGroupsrepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Title = model.Title;
            result.IsActive = model.IsActive;
            result.ModDateTime = DateTime.UtcNow;
            BlogGroupsrepository.Update(result);
            BlogGroupsrepository.SaveChanges();
        }
        //============================================================
        public void Delete(List<BlogGroupsModel> model)
        {
            BlogGroupsrepository.DeleteRange(model);
            BlogGroupsrepository.SaveChanges();
        }
        //============================================================Disposing
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
            BlogGroupsrepository?.Dispose();
        }
        #endregion


    }
}
