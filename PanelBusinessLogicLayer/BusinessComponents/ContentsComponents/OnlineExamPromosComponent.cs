using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class OnlineExamPromosComponent : IDisposable
    {
        private Repository<OnlineExamPromosModel> OnlineExamPromoSectionsRepository;
        public OnlineExamPromosComponent()
        {
            this.OnlineExamPromoSectionsRepository = new Repository<OnlineExamPromosModel>();
        }
        //==============================================================================================
        public IQueryable<OnlineExamPromosModel> Read()
        {
            var result = OnlineExamPromoSectionsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IQueryable<OnlineExamPromosModel> ReadByPromoSection(int OnlineExamPromoSectionGroupId)
        {
            var result = OnlineExamPromoSectionsRepository.Where(c => c.OnlineExamPromoSectionId == OnlineExamPromoSectionGroupId , c=>c.Course.TeacherUser).OrderBy(c => c.Inx);
            return result;
        }
        //==============================================================================================
        public void Add(int OnlineExamPromoSectionGroupId, List<OnlineExamPromosModel> models)
        {
             
            var OnlineExamIds = models.Select(c => c.CourseId).ToList();
            var isOnlineExamInClass = OnlineExamPromoSectionsRepository.Where(c => c.OnlineExamPromoSectionId == OnlineExamPromoSectionGroupId && OnlineExamIds.Contains(c.CourseId)).Any();
            if (isOnlineExamInClass)
                throw new CustomException("برخی از دوره های انتخابی قبلا به این سکشن افزوده شده است");

            OnlineExamPromoSectionsRepository.AddRange(models);
            OnlineExamPromoSectionsRepository.SaveChanges();
        }
        //==============================================================================================
        public OnlineExamPromosModel Find(int Id)
        {
            var result = OnlineExamPromoSectionsRepository.Where(c => c.Id == Id, c => c.Course.CourseTypes).Select(c => new OnlineExamPromosModel()
            {
                Id = c.Id,
                CourseId = c.CourseId,
                Inx = c.Inx,
                OnlineExamPromoSectionId = c.OnlineExamPromoSectionId,
                Course = new CoursesModel()
                {
                    Name = c.Course.Name,
                    CourseTypes = new CourseTypesModel()
                    {
                        Name = c.Course.CourseTypes.Name,
                    }
                }
            }).SingleOrDefault();
            return result;
        }
        //==============================================================================================
        public void Update(OnlineExamPromosModel model)
        {
            //**********************************************
            var data = OnlineExamPromoSectionsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("سکشن تبلیغاتی مورد نظر در سیستم موجود نمی‌باشد"); }
            var query = OnlineExamPromoSectionsRepository.FirstOrDefault(c => c.Id != model.Id && c.CourseId == model.CourseId && c.OnlineExamPromoSectionId == model.OnlineExamPromoSectionId);
            if (query != null) { throw new Exception("محصول انتخاب شده در سکشن تبلیغاتی مورد نظر قبلاً ثبت شده است"); }
            //**********************************************

            data.Inx = model.Inx;
            data.CourseId = model.CourseId;
            data.OnlineExamPromoSectionId = model.OnlineExamPromoSectionId;
            data.ModDateTime = DateTime.UtcNow;
            OnlineExamPromoSectionsRepository.Update(data);
            OnlineExamPromoSectionsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            OnlineExamPromoSectionsRepository.Delete(c=> Ids.Contains(c.Id));
            OnlineExamPromoSectionsRepository.SaveChanges();
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
            OnlineExamPromoSectionsRepository?.Dispose();
        }
        #endregion
    }
}
