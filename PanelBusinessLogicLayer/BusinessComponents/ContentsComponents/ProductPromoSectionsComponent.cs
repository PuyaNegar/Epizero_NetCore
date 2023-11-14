using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class ProductPromoSectionsComponent :IDisposable
    {
        private Repository<ProductPromoSectionsModel> productPromoSectionsGroupsRepository;
        //==============================================================================================
        public ProductPromoSectionsComponent()
        {
            this.productPromoSectionsGroupsRepository = new Repository<ProductPromoSectionsModel>();
        }
        //==============================================================================================
        public IQueryable<ProductPromoSectionsModel> Read()
        {
            var result = productPromoSectionsGroupsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(ProductPromoSectionsModel model)
        {
            var count = productPromoSectionsGroupsRepository.SelectAllAsQuerable().Count();
            if (count >= 5) { throw new Exception("سکشن تبلیغاتی باید حداکثر 5 مورد باشد."); }
            //*********************************************
            var query = productPromoSectionsGroupsRepository.FirstOrDefault(c => c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //**********************************************
            productPromoSectionsGroupsRepository.Add(model);
            productPromoSectionsGroupsRepository.SaveChanges();
        }
        //==============================================================================================
        public ProductPromoSectionsModel Find(int Id)
        {
            var result = productPromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(ProductPromoSectionsModel model)
        {
            //**********************************************
            var data = productPromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمیباشد"); }
            var query = productPromoSectionsGroupsRepository.FirstOrDefault(c => c.Id != model.Id && c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.IsActive = model.IsActive;
            data.Title = model.Title;
            data.ModDateTime = DateTime.UtcNow;
            productPromoSectionsGroupsRepository.Update(data);
            productPromoSectionsGroupsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            productPromoSectionsGroupsRepository.Delete(c=> Ids.Contains(c.Id));
            productPromoSectionsGroupsRepository.SaveChanges();
        }
        //=================================================================Disposing
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
            productPromoSectionsGroupsRepository?.Dispose();
        }
        #endregion
    }
}
