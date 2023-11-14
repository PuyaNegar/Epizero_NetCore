using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using PanelBusinessLogicLayer.UtilityComponent;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherHomeworksComponent : IDisposable
    {
        private Repository<HomeworksModel> homeworksRepository;
        //==============================================
        public TeacherHomeworksComponent()
        {
            homeworksRepository = new Repository<HomeworksModel>();
        }
        //==============================================
        public void Add(HomeworksModel model, int teacherUserId)
        {
            TeacherCourseMeetingsValidationComponent.Validate(model.CourseMeetingId, teacherUserId);
            model.FilePath = FileComponentProvider.Save(FileFolder.HomeworkFiles, model.FilePath);
            homeworksRepository.Add(model);
            homeworksRepository.SaveChanges();
            HomeworksSmsComponent.Operation(model.CourseMeetingId, teacherUserId);
        }
        //==============================================
        public IQueryable<HomeworksModel> Read(int courseMeetingId, int teacherUserId)
        {
            var result = homeworksRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.CourseMeeting.TeacherUserId == teacherUserId, c => c.CourseMeeting);
            return result;
        }
        //==============================================
        public HomeworksModel Find(int homeworkId , int teacherUserId)
        {
            var result = homeworksRepository.SingleOrDefault(c => c.Id == homeworkId && c.CourseMeeting.TeacherUserId == teacherUserId , c=> c.CourseMeeting);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //==============================================
        public void Update(HomeworksModel model, int teacherUserId)
        {
            TeacherCourseMeetingsValidationComponent.Validate(model.CourseMeetingId, teacherUserId);
            var result = homeworksRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.IsActive = model.IsActive;
            result.Description = model.Description;
            result.Title = model.Title;
            result.ModDateTime = DateTime.UtcNow;
            result.ExpiredDate = model.ExpiredDate;
            result.ModUserId = teacherUserId;
            result.Description = result.Description;
            homeworksRepository.Update(result);
            homeworksRepository.SaveChanges();
        }
        //==============================================
        public void Delete(int homeworkId, int teacherUserId)
        {
            using (var homeworkAnswersRepository = new Repository<HomeworkAnswersModel>())
            {
                if (!homeworksRepository.Where(c => c.Id == homeworkId && c.CourseMeeting.TeacherUserId == teacherUserId).Any())
                    throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
                if (homeworkAnswersRepository.Where(c => c.HomeWorkId == homeworkId).Any())
                    throw new CustomException("به دلیل وجود پاسخ های دانش آموزان امکان حذف این  تکلیف وجود ندارد");
                homeworksRepository.Delete(c => c.Id == homeworkId);
                homeworksRepository.SaveChanges();
            }
        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            homeworksRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
