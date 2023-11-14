using System;
using System.Linq;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
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
        public IQueryable<BlogGroupsModel> Read()
        {
            var result = BlogGroupsrepository.Where(c => c.IsActive == true);
            return result;
        }
        //============================================================
        public BlogGroupsModel Find(int Id)
        {
            var result = BlogGroupsrepository.SingleOrDefault(c => c.Id == Id && c.IsActive == true);
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
            BlogGroupsrepository?.Dispose();
        }
        #endregion
    }
}
