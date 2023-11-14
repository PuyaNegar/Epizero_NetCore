using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
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
    public class UserLoginLogsController : Controller
    {
        private UserLoginLogsService userLoginLogsService;
        public UserLoginLogsController()
        {
            userLoginLogsService = new UserLoginLogsService();
        }
        //=========================================================
        public IActionResult Index()
        {
            return View();
        }
        //=========================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = userLoginLogsService.Read();
                var result = sysResult.GetGridData<UserLoginLogsViewModel>
                (request);
                return Json(result);
            });
        }
        //=========================================================
        public async Task<IActionResult> ReadLogHistories([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = userLoginLogsService.ReadLogHistories(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] UserLoginHistoriesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = userLoginLogsService.Delete(GetCurrentUserId(), viewModel);
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
            userLoginLogsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
