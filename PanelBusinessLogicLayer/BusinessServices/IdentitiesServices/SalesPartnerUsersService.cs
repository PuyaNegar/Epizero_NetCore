using Common.Enums;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.IdentitiesServices
{
   public class SalesPartnerUsersService : IDisposable
    {
        private SalesPartnerUsersComponent salesPartnerUsersComponent;
        //===============================================================================
        public SalesPartnerUsersService()
        {
            salesPartnerUsersComponent = new SalesPartnerUsersComponent();
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = salesPartnerUsersComponent.ReadForComboBox(UserGroup.SalesPartner);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
        }
        //====================================================================================
        public SysResult Read()
        {
            var result = salesPartnerUsersComponent.Read().Select(c => new SalesPartnerUsersViewModel()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                FullName = c.FirstName + " " + c.LastName,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
                salesPartnerUsersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
