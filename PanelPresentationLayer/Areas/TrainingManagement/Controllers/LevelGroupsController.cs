using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelPresentationLayer.Infrastracture.Filters;
using System.Threading.Tasks;
using System;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Extentions;
using PanelViewModels.TrainingManagementViewModels;
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class LevelGroupsController : Controller
    {
        private LevelGroupsService _levelGroupsService ;
        //===========================================================================
        public LevelGroupsController()
        {
            this._levelGroupsService = new LevelGroupsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = _levelGroupsService.Read();
                var result = sysResult.GetGridData<LevelGroupsViewModel>
                    (request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = _levelGroupsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] LevelGroupsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = _levelGroupsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            _levelGroupsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
