using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents
{
   public class TagsComponent : IDisposable
    {
        private Repository<TagsModel> tagsRepository;
        //======================================================================= 
        public TagsComponent()
        {
            tagsRepository = new Repository<TagsModel>();
        }
        //======================================================================= 
        public IQueryable<TagsModel> Read()
        {
            var result = tagsRepository.Where(c => c.IsActive == true);
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
            tagsRepository?.Dispose();
        }
        #endregion




    }
}
