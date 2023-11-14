using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;
using System;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize] 
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class ScoringTariffsController : Controller
    {
        private ScoringTariffsService scoringTariffsService;
        //===========================================================================
        public ScoringTariffsController()
        {
            this.scoringTariffsService = new ScoringTariffsService();
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
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = scoringTariffsService.Read();
                var result = sysResult.GetGridData<ScoringTariffsViewModel>
                    (request);
                return Json(result);
            });

        } 
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = scoringTariffsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] ScoringTariffsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = scoringTariffsService.Update(viewModel, CurrentContext.GetCurrentUserId(this));
                return Json(result);
            });

        }  
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            scoringTariffsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
