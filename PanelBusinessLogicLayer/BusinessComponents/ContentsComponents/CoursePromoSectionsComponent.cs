using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class CoursePromoSectionsComponent :IDisposable
    {
        private Repository<CoursePromoSectionsModel> coursePromoSectionsGroupsRepository;
        //==============================================================================================
        public CoursePromoSectionsComponent()
        {
            this.coursePromoSectionsGroupsRepository = new Repository<CoursePromoSectionsModel>();
        }
        //==============================================================================================
        public IQueryable<CoursePromoSectionsModel> Read()
        {
            var result = coursePromoSectionsGroupsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public void Add(CoursePromoSectionsModel model)
        {
            var count = coursePromoSectionsGroupsRepository.SelectAllAsQuerable().Count();
            if (count >= 5) { throw new Exception("سکشن تبلیغاتی باید حداکثر 5 مورد باشد."); }
            //*********************************************
            var query = coursePromoSectionsGroupsRepository.FirstOrDefault(c => c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //**********************************************
            coursePromoSectionsGroupsRepository.Add(model);
            coursePromoSectionsGroupsRepository.SaveChanges();
        }
        //==============================================================================================
        public CoursePromoSectionsModel Find(int Id)
        {
            var result = coursePromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //==============================================================================================
        public void Update(CoursePromoSectionsModel model)
        {
            //**********************************************
            var data = coursePromoSectionsGroupsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمیباشد"); }
            var query = coursePromoSectionsGroupsRepository.FirstOrDefault(c => c.Id != model.Id && c.Title == model.Title);
            if (query != null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود میباشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.IsActive = model.IsActive;
            data.Title = model.Title;
            data.ModDateTime = DateTime.UtcNow;
            coursePromoSectionsGroupsRepository.Update(data);
            coursePromoSectionsGroupsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            coursePromoSectionsGroupsRepository.Delete(c=> Ids.Contains(c.Id));
            coursePromoSectionsGroupsRepository.SaveChanges();
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
            coursePromoSectionsGroupsRepository?.Dispose();
        }
        #endregion
    }
}
