using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamMultipleChoiceQuestionsComponent : IDisposable
    {
        private Repository<OnlineExamMultipleChoiceQuestionsModel> multipleChoiceQuestionsRepository;
        public OnlineExamMultipleChoiceQuestionsComponent()
        {
            this.multipleChoiceQuestionsRepository = new Repository<OnlineExamMultipleChoiceQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamMultipleChoiceQuestionsModel Find(int Id)
        {
            var result = multipleChoiceQuestionsRepository.SingleOrDefault(c => c.Id == Id, c => c.OnlineExamQuestion);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(OnlineExamMultipleChoiceQuestionsModel model, int currentUserId)
        {
            var result = multipleChoiceQuestionsRepository.SingleOrDefault(c => c.Id == model.Id, c => c.OnlineExamQuestion);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            //if (result.Question.QuestionMakerUserId != currentUserId)
            //    throw new CustomException("شما مجوز ویرایش سوال را ندارید");

            result.IsTextOption1 = model.IsTextOption1;
            result.IsTextOption2 = model.IsTextOption2;
            result.IsTextOption3 = model.IsTextOption3;
            result.IsTextOption4 = model.IsTextOption4;
            
            result.OnlineExamQuestion.QuestionContext = model.OnlineExamQuestion.QuestionContext;
            result.DescriptiveAnswer = model.DescriptiveAnswer;
            result.Option1 = model.Option1;
            result.Option2 = model.Option2;
            result.Option3 = model.Option3;
            result.Option4 = model.Option4;



            result.OnlineExamQuestion.QuestionContext_CkFormat = model.OnlineExamQuestion.QuestionContext_CkFormat;
            result.DescriptiveAnswer_CkFormat = model.DescriptiveAnswer_CkFormat;
            result.Option1_CkFormat = model.Option1_CkFormat;
            result.Option2_CkFormat = model.Option2_CkFormat;
            result.Option3_CkFormat = model.Option3_CkFormat;
            result.Option4_CkFormat = model.Option4_CkFormat;


            result.CorrectOption = model.CorrectOption;
            result.OnlineExamQuestion.IsTextQuestionContext = result.OnlineExamQuestion.IsTextQuestionContext;
            
            result.ModUserId = currentUserId;
            result.ModDateTime = DateTime.UtcNow;
            multipleChoiceQuestionsRepository.Update(result);
            multipleChoiceQuestionsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetParentOnlineExamId(int id)
        {
            var result = multipleChoiceQuestionsRepository.SingleOrDefault(c => c.Id == id, c => c.OnlineExamQuestion);
            if (result == null)
                throw new Exception(SystemCommonMessage.DataWasNotFound);
            return result.OnlineExamQuestion.OnlineExamId;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
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
            multipleChoiceQuestionsRepository?.Dispose();
        }
        #endregion
    }
}
