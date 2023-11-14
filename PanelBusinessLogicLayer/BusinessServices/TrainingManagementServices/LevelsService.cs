using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
   public class LevelsService : IDisposable
    {
        private LevelsComponent levelsComponent;
        public LevelsService()
        {
            this.levelsComponent = new LevelsComponent();
        }
        //===================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int LevelGroupId)
        {
            var result = levelsComponent.ReadByLevelGroup(LevelGroupId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = levelsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name + " (" + c.LevelGroup.Name + ")",
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //====================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            levelsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
