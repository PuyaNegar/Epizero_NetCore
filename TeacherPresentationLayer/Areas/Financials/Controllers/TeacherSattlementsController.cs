using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices;
using PanelViewModels.BaseViewModels;
using System;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherSattlementsController : Controller
    {
        private TeacherSattlementsService teacherSattlementsService;
        //===================================================
        public TeacherSattlementsController()
        {
            teacherSattlementsService = new TeacherSattlementsService();
        }
        //===================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var viewModel = new DateFiltersViewModel
                {
                    FromDate = null,
                    ToDate = null
                };
                ViewBag.TeacherSattlementChart = teacherSattlementsService.Read(GetCurrentUserId().Value, viewModel).Value;
                if (teacherSattlementsService.IsShow(GetCurrentUserId().Value).Value)
                {
                    using (var teacherFinancialDashboardService = new TeacherFinancialDashboardService())
                    {
                        var result = teacherFinancialDashboardService.Read(GetCurrentUserId().Value).Value;
                        ViewBag.TeacherFinancials = result;
                        return View();
                    }
                }
                else
                {
                    return NotFound();
                }
            });
        }
        //==================================================
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> Read([FromQuery] DateFiltersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSattlementsService.Read(GetCurrentUserId().Value, viewModel);
                return Ok(result);
            });
        }
        //==================================================
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> ReadAggregationSummery()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSattlementsService.ReadAggregationSummery(GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //==================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            teacherSattlementsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
