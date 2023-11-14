using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class DependentOnlineExamsComponent : IDisposable
    {
        Repository<OnlineExamsModel> onlineExamsRepository;
        public DependentOnlineExamsComponent()
        {
            this.onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(OnlineExamsModel model)
        {
            if (!IsValidOnlineExamDateTime(model))
                throw new CustomException("نمی توان برای تاریخ گذشته آزمون تعریف کرد ");
            onlineExamsRepository.Add(model);
            onlineExamsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamsModel> Read()
        {
            return onlineExamsRepository.Where(c => c.OnlineExamTypeId == (int)OnlineExamType.Dependent , c=> c.ModUser).OrderByDescending(c => c.Id);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamsModel Find(int Id)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == Id && c.OnlineExamTypeId == (int)OnlineExamType.Dependent, c => c.QuestionType , c=> c.TeacherUser);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(OnlineExamsModel model, int currentUserId)
        {
            //if (!IsValidOnlineExamDateTime(model))
            //    throw new CustomException("نمی توان برای تاریخ گذشته آزمون تعریف کرد ");
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == model.Id && c.OnlineExamTypeId == (int)OnlineExamType.Dependent);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (IsValidOnlineExamDateTime(result))
            {
                result.MaxGrade = model.MaxGrade;
                result.IsRandomOption = model.IsRandomOption;
                result.IsRandomQuestions = model.IsRandomQuestions;
                result.HasNegativePoint = model.HasNegativePoint; result.StartDateTime = model.StartDateTime;
                result.Name = model.Name;
            }
            result.IsVisibleOnSite = model.IsVisibleOnSite;
            result.IsAbleToEnterExpiredExam = model.IsAbleToEnterExpiredExam;
            result.AnalysisVideoLink = model.AnalysisVideoLink;
            result.Duration = model.Duration;
            result.AllowedTimeToEnter = model.AllowedTimeToEnter;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            onlineExamsRepository.Update(result);
            onlineExamsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int id)
        {
            onlineExamsRepository.Delete(c => c.Id == id && c.OnlineExamTypeId == (int)OnlineExamType.Dependent);
            onlineExamsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        bool IsValidOnlineExamDateTime(OnlineExamsModel model)
        {
            if (model.StartDateTime < DateTime.UtcNow)
                return false;
            return true;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            onlineExamsRepository?.Dispose();
        }
        #endregion
    }
}
