using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
   public class OnlineExamQuestionsComponent : IDisposable
    {
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        public OnlineExamQuestionsComponent()
        {
            this.onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamQuestionsModel> Read(int onlineExamId)
        {
            return onlineExamQuestionsRepository.Where(c => c.OnlineExamId == onlineExamId, c => c.OnlineExamMultipleChoiceQuestion.OnlineExamQuestion).OrderByDescending(c => c.Inx);
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
            onlineExamQuestionsRepository?.Dispose();
        }
        #endregion
    }
}
