using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class ArrangeQuestionsComponent : IDisposable
    {
        private Repository<OnlineExamQuestionsModel> onlineExamQuestionsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public ArrangeQuestionsComponent()
        {
            this.onlineExamQuestionsRepository = new Repository<OnlineExamQuestionsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Update(List<ArrangeQuestionsViewModel> viewModel)
        {
            var onlineExamQuestions = onlineExamQuestionsRepository.Where(c => viewModel.Select(c => c.QuestionId).ToList().Contains(c.Id)).ToList();
            foreach (var onlineExamQuestion in onlineExamQuestions)
            {
                onlineExamQuestion.Inx = viewModel.Single(c=>c.QuestionId == onlineExamQuestion.Id).Inx;
                onlineExamQuestionsRepository.Update(onlineExamQuestion); 
            }
            onlineExamQuestionsRepository.SaveChanges(); 
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamQuestionsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
