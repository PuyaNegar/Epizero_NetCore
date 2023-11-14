using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.UtilityComponent;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class BlogsComponent : IDisposable
    {
        private Repository<BlogsModel> BlogsRepository;
        //============================================================
        public BlogsComponent()
        {
            BlogsRepository = new Repository<BlogsModel>();
        }
        //============================================================
        public void Add(BlogsModel model)
        {
            model.PicPath = FileComponentProvider.Save(FileFolder.Blogs, model.PicPath);
            BlogsRepository.Add(model);
            BlogsRepository.SaveChanges();
        }
        //============================================================
        public IQueryable<BlogsModel> Read()
        {
            var result = BlogsRepository.SelectAllAsQuerable(c => c.BlogGroups);
            return result;
        }
        //============================================================
        public BlogsModel Find(int id)
        {
            var result = BlogsRepository.SingleOrDefault(c => c.Id == id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Update(BlogsModel model)
        {
            var result = BlogsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Title = model.Title;
            result.Text = model.Text;
            result.PicPath = FileComponentProvider.Save(FileFolder.Blogs, model.PicPath);
            result.BlogGroupId = model.BlogGroupId;
            result.ModDateTime = DateTime.UtcNow;
            BlogsRepository.Update(result);
            BlogsRepository.SaveChanges();
        }
        //============================================================
        public void Delete(List<BlogsModel> model)
        {
            BlogsRepository.DeleteRange(model);
            BlogsRepository.SaveChanges();
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
            BlogsRepository?.Dispose();
        }
        #endregion
    }
}
