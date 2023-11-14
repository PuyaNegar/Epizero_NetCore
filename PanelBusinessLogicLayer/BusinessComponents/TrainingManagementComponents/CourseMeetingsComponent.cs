using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseMeetingsComponent : IDisposable
    {
        private Repository<CourseMeetingsModel> courseMeetingsRepository;
        //======================================================
        public CourseMeetingsComponent()
        {
            courseMeetingsRepository = new Repository<CourseMeetingsModel>();
        }
        //===================================================
        public IQueryable<CourseMeetingsModel> Read(int CourseId)
        {
            var result = courseMeetingsRepository.Where(c => c.CourseId == CourseId , c=>c.ModUser);
            return result;
        }
        //=====================================================
        public void Add(CourseMeetingsModel model)
        { 
            using (var coursesRepository = new Repository<CoursesModel>())
            {
                var result = coursesRepository.SingleOrDefault(c => c.Id == model.CourseId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                model.TeacherUserId = result.TeacherUserId;
                courseMeetingsRepository.Add(model);
                courseMeetingsRepository.SaveChanges();
            } 
        }
        //===================================================
        public CourseMeetingsModel Find(int Id)
        {
            var result = courseMeetingsRepository.Where(c => c.Id == Id, c=> c.TeacherUser , c=>c.Course).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(CourseMeetingsModel model, int currentUserId)
        {
            var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Price = model.Price;
            result.Name = model.Name;
            result.Description = model.Description;
            result.DiscountPercent = model.DiscountPercent;
            result.IsActive = model.IsActive;
            result.IsPurchasable = model.IsPurchasable;
            //result.CourseId = model.CourseId;
            //result.TeacherUserId = model.TeacherUserId;
            result.DiscountAmount = model.DiscountAmount;
            result.StartDateTime = model.StartDateTime;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            courseMeetingsRepository.Update(result);
            courseMeetingsRepository.SaveChanges();
        }
        //===============================================================================
        public List<UsersModel> GetTeachers(int CourseId)
        {
            var teacherUserIds = courseMeetingsRepository.Where(c => c.CourseId == CourseId)
                .Select(c => c.TeacherUserId).Distinct().ToList<int>();
            using (var usersRepository = new Repository<UsersModel>())
            {
                var result = usersRepository.Where(c => teacherUserIds.Contains(c.Id) && c.UserGroupId == (int)UserGroup.Teacher, c => c.TeacherUserProfile).ToList();
                return result;
            }
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            courseMeetingsRepository.Delete(c => Ids.Contains(c.Id));
            courseMeetingsRepository.SaveChanges();
        }

        //===================================================
        public IQueryable<CourseMeetingsModel> ReadForComboBox()
        {
            var result = courseMeetingsRepository.Where(c => c.IsActive && c.Course.IsActive);
            return result;
        }
        //===================================================
        public IQueryable<CourseMeetingsModel> ReadForComboBox(int courseId)
        {
            var result = courseMeetingsRepository.Where(c =>c.CourseId == courseId && c.IsActive && c.Course.IsActive);
            return result;
        }
        //=================================================== Disposing
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
            courseMeetingsRepository?.Dispose();
        }
        #endregion

    }
}
