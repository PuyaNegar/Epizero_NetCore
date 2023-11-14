using System;
using System.Collections.Generic;
using System.Linq;
using Common.Objects;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class LevelsService : IDisposable
    {
        private LevelsComponent levelsComponent;
        //===============================================================================
        public LevelsService()
        {
            levelsComponent = new LevelsComponent();
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = levelsComponent.Read().OrderBy(c => c.Id).Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name + "(" + c.LevelGroup.Name  + ")" 
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            levelsComponent?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
