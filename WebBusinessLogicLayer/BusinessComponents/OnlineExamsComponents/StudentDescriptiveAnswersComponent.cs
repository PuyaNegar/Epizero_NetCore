using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentDescriptiveAnswersComponent : IDisposable
    {
        private Repository<OnlineExamStudentAnswersModel> studentDescriptiveAnswersRepository;
        public StudentDescriptiveAnswersComponent()
        {
            this.studentDescriptiveAnswersRepository = new Repository<OnlineExamStudentAnswersModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void AddOrUpdate(string AnswerContext, int onlineExamQuestionId, int onlineExamId, int currentUserId)
        {
            CheckQuestionType(onlineExamQuestionId);
            var onlineExamStudentId = GetOnlineExamStudentId(onlineExamId, currentUserId);
            var result = studentDescriptiveAnswersRepository.SingleOrDefault(x => x.OnlineExamQuestionId == onlineExamQuestionId && x.OnlineExamStudentId == onlineExamStudentId, c => c.DescrptiveQuestionAnswer);
            if (result != null)
                Update(result, AnswerContext);
            else
                Add(AnswerContext, onlineExamQuestionId, onlineExamStudentId, currentUserId);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void Update(OnlineExamStudentAnswersModel result, string newAnswerContext)
        {
            result.ModDateTime = DateTime.UtcNow;
            result.DescrptiveQuestionAnswer.ModDateTime = DateTime.UtcNow;
            result.DescrptiveQuestionAnswer.AnswerContext = newAnswerContext;
            studentDescriptiveAnswersRepository.Update(result);
            studentDescriptiveAnswersRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        void Add(string AnswerContext, int onlineExamQuestionId, int onlineExamStudentId, int currentUserId)
        {
            var model = new OnlineExamStudentAnswersModel()
            {
                OnlineExamQuestionId = onlineExamQuestionId,
                OnlineExamStudentId = onlineExamStudentId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                DescrptiveQuestionAnswer = new DescrptiveQuestionAnswersModel()
                {
                    AnswerContext = AnswerContext,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = currentUserId
                }
            };
            studentDescriptiveAnswersRepository.Add(model);
            studentDescriptiveAnswersRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        int GetOnlineExamStudentId(int onlineExamId, int currentUserId   )
        { 
            using (var component = new StudentOnlineExamValidationsComponent())
            {
                double RemainingTime = 0;
                var result = component.Operation(onlineExamId, currentUserId, ref RemainingTime, false);
                if (result.OnlineExam.QuestionTypeId != (int)QuestionType.DescriptiveQuestions && result.OnlineExam.QuestionTypeId != (int)QuestionType.Descriptive_MultipleChoiceQuestions)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.Id;
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
                if (result.QuestionTypeId != (int)QuestionType.DescriptiveQuestions)
                    throw new CustomException("سوال بایستی بصورت تشریحی پاسخ داده شود");
            }
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentDescriptiveAnswersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
