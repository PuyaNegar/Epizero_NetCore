using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.IdentitiesViewModels;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class SalesPartnerUsersController : Controller
    {

        private SalesPartnerUsersService salesPartnerUsersService;
        //===========================================================================
        public SalesPartnerUsersController()
        {
            this.salesPartnerUsersService = new SalesPartnerUsersService();
        }
        //============================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = salesPartnerUsersService.Read();
                var result = sysResult.GetGridData<SalesPartnerUsersViewModel>(request);
                return Json(result);
            });
        }
        //=============================================================================== Disposing
        #region DisposeObject
        protected override void Dispose(bool disposing)
        {
            salesPartnerUsersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
