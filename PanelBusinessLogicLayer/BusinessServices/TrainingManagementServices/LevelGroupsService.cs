using Common.Objects;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class LevelGroupsService : IDisposable
    {
        private LevelGroupsComponent levelGroupsComponent;
        public LevelGroupsService()
        {
            this.levelGroupsComponent = new LevelGroupsComponent();
        }
        //===================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = levelGroupsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===================================================================
        public SysResult Read()
        {
            var result = levelGroupsComponent.Read();
            var viewModel = result.Select(c => new LevelGroupsViewModel()
            {
                Id = c.Id,
                Title = c.Name,
                Description = c.Description
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<LevelGroupsViewModel> Find(int id)
        {
            var result = levelGroupsComponent.Find(id);
            var viewModel = new LevelGroupsViewModel()
            {
                Id = result.Id,
                Description = result.Description,
                Title = result.Name,
            };
            return new SysResult<LevelGroupsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(LevelGroupsViewModel request, int currentUserId)
        {
            var model = new LevelGroupsModel()
            {
                Id = request.Id,
                Description =request.Description,
                Name = request.Title,
                

            };
            levelGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //====================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            levelGroupsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
