using Common.Objects;
using DataModels.BasicDefinitionsModels;
using PanelBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class TagsService : IDisposable
    {
        private TagsComponent tagsComponent;
        public TagsService()
        {
            tagsComponent = new TagsComponent();
        }
        //===================================================================
        public SysResult Read()
        {
            var result = tagsComponent.Read();
            var viewModel = result.Select(c => new TagsViewModel()
            {
                Id = c.Id,
                Title = c.Title
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = tagsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(TagsViewModel viewModel, int UserId)
        {
            var model = new TagsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                RegDateTime = DateTime.UtcNow,
                ModUserId = UserId,
                IsActive = true
            };
            tagsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<TagsViewModel> Find(int Id)
        {
            var result = tagsComponent.Find(Id);

            var viewModel = new TagsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
            };
            return new SysResult<TagsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(TagsViewModel viewModel, int UserId)
        {
            TagsModel model = new TagsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                ModUserId = UserId
            };
            tagsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> tagsViewModel)
        {
            List<TagsModel> model = tagsViewModel.Select(a => new TagsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            tagsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            tagsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
