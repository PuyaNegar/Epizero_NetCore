using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentMultipleChoiceAnswersComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamStudentAnswersModel> onlineExamStudentAnswersRepository;
        public StudentMultipleChoiceAnswersComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamStudentAnswersRepository = new Repository<OnlineExamStudentAnswersModel>(mainDBContext);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamStudentAnswersModel> Read(int onlineExamId, int studentUserId)
        {
            ValidateOnlineExamDateTime(onlineExamId); 
            var result = onlineExamStudentAnswersRepository.Where(c => c.OnlineExamStudent.OnlineExamId == onlineExamId && c.OnlineExamStudent.OnlineExamId == onlineExamId && c.OnlineExamStudent.StudentUserId == studentUserId,
               c => c.MultipleChoiceQuestionAnswer);
            return result;
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void AddOrUpdate(int SelectedOption, int onlineExamQuestionId, int onlineExamId, int currentUserId)
        {
            CheckQuestionType(onlineExamQuestionId);
            var onlineExamStudentId = GetOnlineExamStudentId(onlineExamId, currentUserId);
            var result = onlineExamStudentAnswersRepository.SingleOrDefault(x => x.OnlineExamQuestionId == onlineExamQuestionId && x.OnlineExamStudentId == onlineExamStudentId, c => c.MultipleChoiceQuestionAnswer);
            if (result != null)
                Update(result, SelectedOption);
            else
                Add(SelectedOption, onlineExamQuestionId, onlineExamStudentId, currentUserId);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void Update(OnlineExamStudentAnswersModel result, int newSelectedOption)
        {
            if (newSelectedOption < 0)
            {
                Delete(result.Id, result.MultipleChoiceQuestionAnswer.Id);
            }
            else
            {
                result.ModDateTime = DateTime.UtcNow;
                result.MultipleChoiceQuestionAnswer.ModDateTime = DateTime.UtcNow;
                result.MultipleChoiceQuestionAnswer.SelectedOption = newSelectedOption;
                onlineExamStudentAnswersRepository.Update(result);
                onlineExamStudentAnswersRepository.SaveChanges();
            }

        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void Add(int SelectedOption, int onlineExamQuestionId, int onlineExamStudentId, int currentUserId)
        {
            if (SelectedOption < 0)
                return;
            var model = new OnlineExamStudentAnswersModel()
            {
                OnlineExamQuestionId = onlineExamQuestionId,
                OnlineExamStudentId = onlineExamStudentId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                MultipleChoiceQuestionAnswer = new MultipleChoiceQuestionAnswersModel()
                {
                    SelectedOption = SelectedOption,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = currentUserId
                }
            };
            onlineExamStudentAnswersRepository.Add(model);
            onlineExamStudentAnswersRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void Delete(int studentAnswerId, int multipleChoiceQuestionAnswerId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var MultipleChoiceQuestionAnswersRepository = new Repository<MultipleChoiceQuestionAnswersModel>(mainDBContext))
                    {
                        MultipleChoiceQuestionAnswersRepository.Delete(c => c.Id == multipleChoiceQuestionAnswerId);
                        MultipleChoiceQuestionAnswersRepository.SaveChanges();
                        onlineExamStudentAnswersRepository.Delete(c => c.Id == studentAnswerId);
                        onlineExamStudentAnswersRepository.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException(ex.Message);
                }
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        int GetOnlineExamStudentId(int onlineExamId, int currentUserId)
        {
            using (var component = new StudentOnlineExamValidationsComponent())
            {
                double RemainingTime = 0;
                var result = component.Operation(onlineExamId, currentUserId, ref RemainingTime, false);
                if (result.OnlineExam.QuestionTypeId != (int)QuestionType.MultipleChoiceQuestions && result.OnlineExam.QuestionTypeId != (int)QuestionType.Descriptive_MultipleChoiceQuestions)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.Id;
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void ValidateOnlineExamDateTime(int onlineExamId)
        {
            using (var onlineExamsRepository = new Repository<OnlineExamsModel>())
            {
                var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId);
                bool IsExpiredOnlineExam = result.StartDateTime.AddMinutes(result.Duration).AddMinutes(result.AllowedTimeToEnter == null ? 0 : result.AllowedTimeToEnter.Value) < DateTime.UtcNow;
                if (!IsExpiredOnlineExam)
                    throw new CustomException("آزمون به پایان نرسیده است، بعد از اتمام آزمون پاسخنامه قابل مشاهده است");
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void CheckQuestionType(int onlineExamQuestionId)
        {
            using (var onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>())
            {
                var result = onlineExamQuestionsRepository.SingleOrDefault(c => c.Id == onlineExamQuestionId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                if (result.QuestionTypeId != (int)QuestionType.MultipleChoiceQuestions)
                    throw new CustomException("سوال بایستی بصورت تشریحی پاسخ داده شود");
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamStudentAnswersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
