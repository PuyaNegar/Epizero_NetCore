using PanelViewModels.TrainingManagementViewModels;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using System.Collections.Generic; 
using System.Threading.Tasks;
using System;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class OnlineRegistrationFinancialExportController : Controller
    {
        private CoursesService coursesService;
        private OnlineRegistrationFinancialExportService onlineRegistrationFinancialExportService;
        //===========================================================================
        public OnlineRegistrationFinancialExportController()
        {
            this.coursesService = new CoursesService();
            this.onlineRegistrationFinancialExportService = new OnlineRegistrationFinancialExportService();

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
                var data = request.Filters.ToFilterExpression();
                bool isActive =  Convert.ToBoolean(Convert.ToInt32(data.IsActive));
                CourseCategoryType courseCategoryType =  (CourseCategoryType)Convert.ToInt32(data.CourseCategoryType) ;
                var result = coursesService.Read(isActive, courseCategoryType, selectOnlyMultiTeacherCourse: false).GetGridData<CoursesViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ExcelExport([FromQuery] List<int> CourseIds)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineRegistrationFinancialExportService.ExcelExport(CourseIds);
                return File(fileDownloadName: result.Value.FileName + ".xlsx",
                        fileContents: result.Value.FileContents,
                        contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineRegistrationFinancialExportService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
