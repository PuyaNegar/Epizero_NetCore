using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.BasicDefinitionsComponents;

namespace WebBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
    public class TagsService : IDisposable
    {
        private TagsComponent tagsComponent;
        public TagsService()
        {
            tagsComponent = new TagsComponent();
        }
        //===========================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = tagsComponent.Read();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message =  SystemCommonMessage.InformationFetchedSuccessfully , Value = viewModel };

        }
        //===========================================================================
        #region DisposeObject
        public void Dispose()
        {
            tagsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
