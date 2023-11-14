using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using PanelBusinessLogicLayer.UtilityComponent;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    /// <summary>
    /// نظرات دانش آموزان سابق
    /// </summary>
    public class CoursesComponent : IDisposable
    {
        MainDBContext mainDBContext;
        private Repository<CoursesModel> courseRepository;
        private Repository<CourseFAQsModel> courseFAQsRepository;
        private Repository<CommentOldStudentCoursesModel> commentOldStudentCoursesRepository;
        //============================================================
        public CoursesComponent()
        {
            mainDBContext = new MainDBContext();
            courseRepository = new Repository<CoursesModel>(mainDBContext);
            courseFAQsRepository = new Repository<CourseFAQsModel>(mainDBContext);
            commentOldStudentCoursesRepository = new Repository<CommentOldStudentCoursesModel>(mainDBContext);
        }
        //============================================================
        public void Add(CoursesModel model)
        {
            model.LogoPicPath = FileComponentProvider.Save(FileFolder.Courses, model.LogoPicPath);
            model.BannerPicPath = FileComponentProvider.Save(FileFolder.Courses, model.BannerPicPath);
            courseRepository.Add(model);
            courseRepository.SaveChanges();
        }
        //============================================================
        public IQueryable<CoursesModel> Read(bool? IsActive, CourseCategoryType? courseCategoryType, bool selectOnlyMultiTeacherCourse)
        {
            IQueryable<CoursesModel> query = courseRepository.SelectAllAsQuerable(  c => c.CourseTypes, c => c.TeacherUser.TeacherUserProfile , c=> c.ModUser);
            if (IsActive != null)
                query = query.Where(c => c.IsActive == IsActive);
            if (courseCategoryType != null)
                query = query.Where(c => c.CourseCategoryTypeId == (int)courseCategoryType);
            if(selectOnlyMultiTeacherCourse)
                query = query.Where(c => c.IsMultiTeacher);
            return query;
        }
        //============================================================
        public IQueryable<CoursesModel> ReadForComboBox()
        {
            IQueryable<CoursesModel> query = courseRepository.Where(c => c.IsActive, c => c.CourseTypes, c => c.TeacherUser.TeacherUserProfile);
            return query;
        }
        //============================================================
        
        public void Update(CoursesModel model , int currentUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {

                    var result = courseRepository.SingleOrDefault(c => c.Id == model.Id);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);

                    courseFAQsRepository.Delete(c => c.CourseId == model.Id);
                    courseFAQsRepository.SaveChanges();

                    commentOldStudentCoursesRepository.Delete(c => c.CourseId == model.Id);
                    commentOldStudentCoursesRepository.SaveChanges();

                    result.Name = model.Name;
                    result.CourseMeetingCount = model.CourseMeetingCount;   
                    result.Audience = model.Audience;
                    result.DiscountPercent = model.DiscountPercent;
                    result.Description = model.Description;
                    result.LogoPicPath = FileComponentProvider.Save(FileFolder.Courses, model.LogoPicPath);
                    result.BannerPicPath = FileComponentProvider.Save(FileFolder.Courses, model.BannerPicPath);
                    result.Price = model.Price;
                    result.CourseDuration = model.CourseDuration;
                    result.IsVisibleOnSite = model.IsVisibleOnSite;
                    result.StartDate = model.StartDate;
                    result.EndDate = model.EndDate;
                    result.MetaDescription = model.MetaDescription;
                    result.CourseTypeId = model.CourseTypeId;
                    result.Inx = model.Inx;
                    result.IsShowDetailsInWeb = model.IsShowDetailsInWeb;
                    result.LanguageId = model.LanguageId;
                    result.LessonId = model.LessonId;
                    result.ModUserId = currentUserId;
                    result.IsActive = model.IsActive;
                    result.IsMultiTeacher = model.IsMultiTeacher;
                    result.ModDateTime = DateTime.UtcNow;
                    result.DiscountAmount = model.DiscountAmount;
                    result.CourseFAQs = model.CourseFAQs;
                    result.CommentOldStudentCourses = model.CommentOldStudentCourses;

                    courseRepository.Update(result);
                    courseRepository.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
                //**********************************************

            }
        }
        //============================================================
        public CoursesModel Find(int id)
        {
            var result = courseRepository.SingleOrDefault(c => c.Id == id,c=>c.CourseFAQs, c => c.CommentOldStudentCourses, c => c.Lessons.Level.LevelGroup);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public CoursesModel FindDescription(int Id)
        {
            var result = courseRepository.Where(c => c.Id == Id).Select(c => new CoursesModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).SingleOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //================================================================================
        public void UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            var data = courseRepository.SingleOrDefault(c => c.Id == Id);
            if (data == null)
                throw new Exception(SystemCommonMessage.DataWasNotFound);

            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = CurrentUserId;
            data.Description = Description;
            courseRepository.Update(data);
            courseRepository.SaveChanges();
        }
        //============================================================
        public void Delete(List<CoursesModel> model)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var list = model.Select(c => c.Id).ToList();

                    courseFAQsRepository.Delete(c => list.Contains(c.CourseId));
                    courseFAQsRepository.SaveChanges();

                    commentOldStudentCoursesRepository.Delete(c => list.Contains(c.CourseId));
                    commentOldStudentCoursesRepository.SaveChanges();

                    courseRepository.Delete(c => list.Contains(c.Id));
                    courseRepository.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
