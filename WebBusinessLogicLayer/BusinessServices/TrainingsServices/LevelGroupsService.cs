using Common.Objects;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class LevelGroupsService : IDisposable
    {
        private LevelGroupsComponent levelGroupsComponent;
        public LevelGroupsService()
        {
            this.levelGroupsComponent = new LevelGroupsComponent();
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
