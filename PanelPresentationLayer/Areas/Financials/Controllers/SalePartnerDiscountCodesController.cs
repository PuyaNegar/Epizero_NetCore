using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [SalesPartnerPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SalePartnerDiscountCodesController : Controller
    {
        private DiscountCodesService discountCodesService;
        //===========================================================================
        public SalePartnerDiscountCodesController()
        {
            this.discountCodesService = new DiscountCodesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var courseMeetingsTask = GetCourseMeetingsTask();
                var coursesTask = GetCoursesTask();
                var salesPartnerUsersTask = GetSalesPartnerUsersTask();
                Task.WaitAll(courseMeetingsTask, coursesTask, salesPartnerUsersTask);
                ViewBag.CourseMeetings = courseMeetingsTask.Result;
                ViewBag.Courses = coursesTask.Result;
                ViewBag.SalesPartnerUsers = salesPartnerUsersTask.Result;
                return View();
            });
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = discountCodesService.Read();
                var result = sysResult.GetGridData<DiscountCodesViewModel>(request);
                return Json(result);
            }); 
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] DiscountCodesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = discountCodesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = discountCodesService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] DiscountCodesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = discountCodesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = discountCodesService.Delete(viewModel);
                return Json(result);
            });

        }
        //=======================================================
        Task<List<ComboBoxItems>> GetCoursesTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var coursesService = new CoursesService())
                {
                    return coursesService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //=======================================================
        Task<List<ComboBoxItems>> GetCourseMeetingsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var courseMeetingsService = new CourseMeetingsService())
                {
                    return courseMeetingsService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }


        //=======================================================
        Task<List<ComboBoxItems>> GetSalesPartnerUsersTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var salesPartnerUsersService = new SalesPartnerUsersService())
                {
                    return salesPartnerUsersService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }

        //===========================================================================
        int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            discountCodesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
