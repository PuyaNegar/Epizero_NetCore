using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseMeetingOnlineExamsComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public CourseMeetingOnlineExamsComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>(); 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(OnlineExamsModel model)
        {
          //  CheckOnlineExamDateTime(model);
            onlineExamsRepository.Add(model);
            onlineExamsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamsModel> Read()
        {
            return onlineExamsRepository.SelectAllAsQuerable().OrderByDescending(c => c.Id);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamsModel Find(int Id)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == Id, c => c.QuestionType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(OnlineExamsModel model, int currentUserId)
        {
            //OnlineExamsComponent.CheckPermisionForEdit(model.Id);
            //CheckOnlineExamDateTime(model);
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Name = model.Name;
            result.StartDateTime = model.StartDateTime;
            result.TeacherUserId = currentUserId;
            result.Duration = model.Duration;
            result.IsRandomOption = model.IsRandomOption;
            result.IsRandomQuestions = model.IsRandomQuestions;
            result.HasNegativePoint = model.HasNegativePoint;
            result.AllowedTimeToEnter = model.AllowedTimeToEnter;
            result.MaxGrade = model.MaxGrade;
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            onlineExamsRepository.Update(result);
            onlineExamsRepository.SaveChanges();
        }
        //===================================================
        public void Delete(int id)
        {
            onlineExamsRepository.Delete(c => c.Id == id);
            onlineExamsRepository.SaveChanges();
        } 
        //=================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
              onlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion 
    }
}
