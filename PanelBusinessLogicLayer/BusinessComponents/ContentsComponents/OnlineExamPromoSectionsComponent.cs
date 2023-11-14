using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class OnlineExamPromoSectionsComponent :IDisposable
    {
        private Repository<OnlineExamPromoSectionsModel> OnlineExamPromoSectionsGroupsRepository;
        //==============================================================================================
        public OnlineExamPromoSectionsComponent()
        {
            this.OnlineExamPromoSectionsGroupsRepository = new Repository<OnlineExamPromoSectionsModel>();
        }
        //==============================================================================================
        public IQueryable<OnlineExamPromoSectionsModel> Read()
        {
            var result = OnlineExamPromoSectionsGroupsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(OnlineExamPromoSectionsModel model)
        {
            var count = OnlineExamPromoSectionsGroupsRepository.SelectAllAsQuerable().Count();
            if (count >= 5) { throw new Exception("سکشن تبلیغاتی باید حداکثر 5 مورد باشد."); }
            //*********************************************
            var query = OnlineExamPromoSectionsGroupsRepository.FirstOrDefault(c => c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //**********************************************
            OnlineExamPromoSectionsGroupsRepository.Add(model);
            OnlineExamPromoSectionsGroupsRepository.SaveChanges();
        }
        //==============================================================================================
        public OnlineExamPromoSectionsModel Find(int Id)
        {
            var result = OnlineExamPromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(OnlineExamPromoSectionsModel model)
        {
            //**********************************************
            var data = OnlineExamPromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمیباشد"); }
            var query = OnlineExamPromoSectionsGroupsRepository.FirstOrDefault(c => c.Id != model.Id && c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.IsActive = model.IsActive;
            data.Title = model.Title;
            data.ModDateTime = DateTime.UtcNow;
            OnlineExamPromoSectionsGroupsRepository.Update(data);
            OnlineExamPromoSectionsGroupsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            OnlineExamPromoSectionsGroupsRepository.Delete(c=> Ids.Contains(c.Id));
            OnlineExamPromoSectionsGroupsRepository.SaveChanges();
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
            OnlineExamPromoSectionsGroupsRepository?.Dispose();
        }
        #endregion
    }
}
