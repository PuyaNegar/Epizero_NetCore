using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class SlidersComponent : IDisposable
    {
        private Repository<SlidersModel> slidersRepository;
        //======================================================
        public SlidersComponent()
        {
            slidersRepository = new Repository<SlidersModel>();
        }
        //======================================================
        public List<SlidersViewModel> Read()
        {
            var cdnUrl = AppConfigProvider.CdnUrl(); 
            var result = slidersRepository.Where(c => c.IsActive).Select(c => new SlidersViewModel()
            {
                Id = c.Id,
                PichPath = cdnUrl + c.PicPath,
                Title = c.Title,
                Alt = c.Alt,
                Inx = c.Inx,
                Description = c.Description,
                Link = c.Link,
            }).OrderBy(c => c.Inx).ToList(); ;
            return result;
        }
        //============================================================ Dispise
        #region DisposeObject
        public void Dispose()
        {
            slidersRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
