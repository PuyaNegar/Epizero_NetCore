using Common.Extentions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class FAQService : IDisposable
    {
        private FAQComponent fAQComponent;
        //=================================================================================
        public FAQService()
        {
            this.fAQComponent = new FAQComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = fAQComponent.Read();
            var viewModel = result.Select(c => new FAQViewModel()
            {
                Id = c.Id,
                AnswerContext = c.AnswerContext,
                QuestionContext = c.QuestionContext,
                IsActive = c.IsActive.ToActiveStatus(),
                IsWebSite = c.IsWebSite.ToActiveStatus(),
                Inx = c.Inx,
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                IsWebSiteName = c.IsWebSite ? "بلی" : "خیر",
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = fAQComponent.ReadForCourse();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.QuestionContext,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(FAQViewModel viewModel, int CurrentUserId)
        {
            var model = new FAQModel()
            {
                Id = viewModel.Id,
                QuestionContext = viewModel.QuestionContext,
                AnswerContext = viewModel.AnswerContext,
                Inx = viewModel.Inx,
                RegDateTime = DateTime.UtcNow,
                IsActive = viewModel.IsActive.ToBoolean(),
                IsWebSite = viewModel.IsWebSite.ToBoolean(),
                ModUserId = CurrentUserId, 
            };
            fAQComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<FAQViewModel> Find(int Id)
        {
            var result = fAQComponent.Find(Id);
            var viewModel = new FAQViewModel()
            {
                AnswerContext = result.AnswerContext,
                Id = result.Id,
                QuestionContext = result.QuestionContext,
                IsActive = result.IsActive.ToActiveStatus(),
                IsWebSite = result.IsWebSite.ToActiveStatus(),
                Inx = result.Inx,
                IsActiveName = result.IsActive ? "فعال" : "غیرفعال",
            };
            return new SysResult<FAQViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(FAQViewModel viewModel, int CurrentUserId)
        {

            var model = new FAQModel()
            {
                Id = viewModel.Id,
                QuestionContext = viewModel.QuestionContext,
                AnswerContext = viewModel.AnswerContext,
                Inx = viewModel.Inx,
                RegDateTime = DateTime.UtcNow,
                IsActive = viewModel.IsActive.ToBoolean(),
                IsWebSite = viewModel.IsWebSite.ToBoolean(),    
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow,
            };
            fAQComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new FAQModel()
            {
                Id = a.Id.Value,
            }).ToList();
            fAQComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
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
            fAQComponent?.Dispose();
        }
        #endregion
    }
}
