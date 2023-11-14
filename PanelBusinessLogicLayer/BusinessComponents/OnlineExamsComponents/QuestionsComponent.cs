using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Linq;
using System.Linq.Dynamic;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class QuestionsComponent : IDisposable
    {
        private Repository<QuestionsModel> questionsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public QuestionsComponent()
        {
            this.questionsRepository = new Repository<QuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<QuestionsModel> Read(int LessonId, QuestionType QuestionType, ActiveStatus isSelectAllTeacherQuestion , int currentUserId)
        {
            IQueryable<QuestionsModel> query = null;
            query = questionsRepository.Where(c => c.LessonId == LessonId, c=> c.QuestionType);
            
            if (QuestionType == QuestionType.DescriptiveQuestions)
                query = query.Where(c => c.QuestionTypeId == (int)QuestionType.DescriptiveQuestions);
            
            if (QuestionType == QuestionType.MultipleChoiceQuestions)
                query = query.Where(c => c.QuestionTypeId == (int)QuestionType.MultipleChoiceQuestions);
            
            if (isSelectAllTeacherQuestion !=  ActiveStatus.Deactive)
                query = query.Where(x => x.QuestionMakerUserId == currentUserId);

            return query;
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
            questionsRepository?.Dispose();
        }
        #endregion
    }
}
