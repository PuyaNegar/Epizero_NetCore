using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Linq;
using TeacherBusinessLogicLayer.UtilityComponents;

namespace TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents
{
    public class TeacherCourseMeetingBookletsComponent : IDisposable
    {
        private Repository<CourseMeetingBookletsModel> courseMeetingBookletsRepository;
        //=============================================
        public TeacherCourseMeetingBookletsComponent()
        {
            courseMeetingBookletsRepository = new Repository<CourseMeetingBookletsModel>();
        }
        //==============================================
        public void Add(CourseMeetingBookletsModel model, int teacherUserId)
        {
            TeacherCourseMeetingsValidationComponent.Validate(model.CourseMeetingId, teacherUserId);
            model.FilePath = FileComponentProvider.Save(FileFolder.CourseMeetingBooklets, model.FilePath);
            courseMeetingBookletsRepository.Add(model);
            courseMeetingBookletsRepository.SaveChanges();
        }
        //==============================================
        public CourseMeetingBookletsModel Find(int courseMeetingBookletId, int teacherUserId)
        {
            var result = courseMeetingBookletsRepository.SingleOrDefault(c => c.Id == courseMeetingBookletId && c.CourseMeeting.TeacherUserId == teacherUserId, c => c.CourseMeeting);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //==============================================
        public void Update(CourseMeetingBookletsModel model, int teacherUserId)
        {
            TeacherCourseMeetingsValidationComponent.Validate(model.CourseMeetingId, teacherUserId);
            var result = courseMeetingBookletsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.IsActive = model.IsActive;
            result.Title = model.Title;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = teacherUserId;
            result.Description = model.Description;
            courseMeetingBookletsRepository.Update(result);
            courseMeetingBookletsRepository.SaveChanges();
        }
        //==============================================
        public IQueryable<CourseMeetingBookletsModel> Read(int courseMeetingId, int teacherUserId)
        {
            var result = courseMeetingBookletsRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.CourseMeeting.TeacherUserId == teacherUserId, c => c.CourseMeeting);
            return result;
        }
        //==============================================
        public void Delete(int courseMeetingBookletId, int teacherUserId)
        {
            courseMeetingBookletsRepository.Delete(c => c.Id == courseMeetingBookletId && c.CourseMeeting.TeacherUserId == teacherUserId);
            courseMeetingBookletsRepository.SaveChanges();
        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingBookletsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
