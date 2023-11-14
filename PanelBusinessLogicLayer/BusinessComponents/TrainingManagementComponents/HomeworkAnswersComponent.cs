using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
   public class HomeworkAnswersComponent : IDisposable
    {
        private Repository<HomeworkAnswersModel> homeworkAnswersRepository;
        //===================================================
        public HomeworkAnswersComponent()
        {
            homeworkAnswersRepository = new Repository<HomeworkAnswersModel>();
        }
        //===================================================
        public IQueryable<HomeworkAnswersModel> Read(int homeworkId)
        {
            var result = homeworkAnswersRepository.Where(c => c.HomeWorkId == homeworkId , c=> c.HomeWork ,c=> c.StudentUser);
            return result;
        }
        //===================================================
        public HomeworkAnswersModel Find(int Id)
        {
            var result = homeworkAnswersRepository.Where(c => c.Id == Id, c => c.HomeWork, c => c.StudentUser).SingleOrDefault();
            return result;
        }
        //===================================================
        public void Update(HomeworkAnswersModel model, int currentUserId)
        {
            var result = homeworkAnswersRepository.SingleOrDefault(c => c.Id == model.Id && c.HomeWorkId == model.HomeWorkId && c.StudentUserId == model.StudentUserId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Grade = model.Grade;
            result.Description = model.Description;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            homeworkAnswersRepository.Update(result);
            homeworkAnswersRepository.SaveChanges();
        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            homeworkAnswersRepository.Delete(c => Ids.Contains(c.Id));
            homeworkAnswersRepository.SaveChanges();
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
            homeworkAnswersRepository?.Dispose();
        }
        #endregion
    }
}
