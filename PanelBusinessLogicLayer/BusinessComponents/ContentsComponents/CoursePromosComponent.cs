using Common.Extentions;
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
    public class CoursePromosComponent : IDisposable
    {
        private Repository<CoursePromosModel> coursePromoSectionsRepository;
        public CoursePromosComponent()
        {
            this.coursePromoSectionsRepository = new Repository<CoursePromosModel>();
        }
        //==============================================================================================
        public IQueryable<CoursePromosModel> Read()
        {
            var result = coursePromoSectionsRepository.SelectAllAsQuerable();
            return result;
        }
        //==============================================================================================
        public IQueryable<CoursePromosModel> ReadByPromoSection(int CoursePromoSectionGroupId)
        {
            var result = coursePromoSectionsRepository.Where(c => c.CoursePromoSectionId == CoursePromoSectionGroupId , c=>c.Course.TeacherUser).OrderBy(c => c.Inx);
            return result;
        }
        //==============================================================================================
        public void Add(int CoursePromoSectionGroupId, List<CoursePromosModel> models)
        {
             
            var CourseIds = models.Select(c => c.CourseId).ToList();
            var isCourseInClass = coursePromoSectionsRepository.Where(c => c.CoursePromoSectionId == CoursePromoSectionGroupId && CourseIds.Contains(c.CourseId)).Any();
            if (isCourseInClass)
                throw new CustomException("برخی از دوره های انتخابی قبلا به این سکشن افزوده شده است");

            coursePromoSectionsRepository.AddRange(models);
            coursePromoSectionsRepository.SaveChanges();
        }
        //==============================================================================================
        public CoursePromosModel Find(int Id)
        {
            var result = coursePromoSectionsRepository.Where(c => c.Id == Id, c => c.Course.CourseTypes).Select(c => new CoursePromosModel()
            {
                Id = c.Id,
                CourseId = c.CourseId,
                Inx = c.Inx,
                CoursePromoSectionId = c.CoursePromoSectionId,
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
        public void Update(CoursePromosModel model)
        {
            //**********************************************
            var data = coursePromoSectionsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("سکشن تبلیغاتی مورد نظر در سیستم موجود نمی‌باشد"); }
            var query = coursePromoSectionsRepository.FirstOrDefault(c => c.Id != model.Id && c.CourseId == model.CourseId && c.CoursePromoSectionId == model.CoursePromoSectionId);
            if (query != null) { throw new Exception("محصول انتخاب شده در سکشن تبلیغاتی مورد نظر قبلاً ثبت شده است"); }
            //**********************************************

            data.Inx = model.Inx;
            data.CourseId = model.CourseId;
            data.CoursePromoSectionId = model.CoursePromoSectionId;
            data.ModDateTime = DateTime.UtcNow;
            coursePromoSectionsRepository.Update(data);
            coursePromoSectionsRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<int> Ids)
        {
            coursePromoSectionsRepository.Delete(c=> Ids.Contains(c.Id));
            coursePromoSectionsRepository.SaveChanges();
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
            coursePromoSectionsRepository?.Dispose();
        }
        #endregion
    }
}
