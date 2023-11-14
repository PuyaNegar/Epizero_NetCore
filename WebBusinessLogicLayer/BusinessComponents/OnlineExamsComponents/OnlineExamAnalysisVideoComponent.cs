using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamAnalysisVideoComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        //==============================================
        public OnlineExamAnalysisVideoComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //==============================================
        public OnlineExamsModel Find(int onlineExamId)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId , c=>c.QuestionType);
            return result;
        }
        //=============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
