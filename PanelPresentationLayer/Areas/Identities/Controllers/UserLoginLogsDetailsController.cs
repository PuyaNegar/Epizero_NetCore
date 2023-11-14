using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class UserLoginLogsDetailsController : Controller
    {
        private UserLoginLogsDetailsService userLoginLogsDetailsService;
        public UserLoginLogsDetailsController()
        {
            userLoginLogsDetailsService = new UserLoginLogsDetailsService();
        }
        //=================================================================
        public IActionResult Index(int Id)
        {
            ViewBag.StudentUserId = Id;
            return View();
        }
        //=================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request ,int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = userLoginLogsDetailsService.Read(Id);
                var result = sysResult.GetGridData<UserLoginLogsDetailsViewModel>
                (request);
                return Json(result);
            });

        }
        //=================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            userLoginLogsDetailsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
