using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ReportServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Reports.Controllers
{
    [Area("Reports")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AcademyProductTypeReportsController : Controller
    {
        private AcademyProductTypeReportsService academyProductTypeReportsService;
        //===========================================================================
        public AcademyProductTypeReportsController()
        {
            this.academyProductTypeReportsService = new AcademyProductTypeReportsService();
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
 
                var sysResult = academyProductTypeReportsService.Read();
                var result = sysResult.GetGridData<AcademyProductTypeReportsViewModel>(request);
                return Json(result);
            });

        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            academyProductTypeReportsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
