using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class FAQComponent : IDisposable
    {
        private Repository<FAQModel> faqRepository;
        //======================================================
        public FAQComponent()
        {
            faqRepository = new Repository<FAQModel>();
        }
        //======================================================
        public List<FAQViewModel> Read()
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = faqRepository.Where(c => c.IsActive && c.IsWebSite).Select(c => new FAQViewModel()
            {
                Id = c.Id,
                AnswerContext = c.AnswerContext,
                IsActive = c.IsActive,
                QuestionContext = c.QuestionContext,
                Inx = c.Inx, 
            }).OrderBy(c => c.Inx).ToList(); 
            return result;
        }
        //============================================================ Dispise
        #region DisposeObject
        public void Dispose()
        {
            faqRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
