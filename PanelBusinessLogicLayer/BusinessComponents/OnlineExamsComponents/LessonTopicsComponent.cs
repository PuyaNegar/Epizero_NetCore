using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class LessonTopicsComponent : IDisposable
    {
        private Repository<LessonTopicsModel> lessonTopicsRepository;
        public LessonTopicsComponent()
        {
            this.lessonTopicsRepository = new Repository<LessonTopicsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(LessonTopicsModel model)
        {
            lessonTopicsRepository.Add(model);
            lessonTopicsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<LessonTopicsModel> Read(int lessonId)
        {
                return lessonTopicsRepository.Where(c=> c.LessonId == lessonId,c=> c.Lesson).OrderByDescending(c=> c.Inx);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public LessonTopicsModel Find(int Id)
        {
            var result = lessonTopicsRepository.SingleOrDefault(c => c.Id == Id);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(LessonTopicsModel model, int currentUserId)
        {
            var result = lessonTopicsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.LessonId = model.LessonId;
            result.Name = model.Name;
            result.Inx = model.Inx;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            lessonTopicsRepository.Update(result);
            lessonTopicsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public static string GetFullName(int? LessonTopicId)
        {
            using (var lessonTopicRepository = new Repository<LessonTopicsModel>())
            {
                if (LessonTopicId == null)
                    return string.Empty;
                var result = lessonTopicRepository.Where(x => x.Id == LessonTopicId, x => x.Lesson )
                                    .Select(c => new {  LessonName = c.Lesson.Name , LessonTopicName = c.Name}).SingleOrDefault();

                return $" {result.LessonName} - {result.LessonTopicName} ";
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int id)
        {
            lessonTopicsRepository.Delete(c => c.Id == id);
            lessonTopicsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
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
            lessonTopicsRepository?.Dispose();
        }
        #endregion
    }
}
