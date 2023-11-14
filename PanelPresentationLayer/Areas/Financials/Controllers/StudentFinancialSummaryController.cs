using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentFinancialSummaryController : Controller
    {
        private StudentFinancialSummaryService studentFinanciaSummaryService;
        //============================================================================
        public StudentFinancialSummaryController()
        {
            this.studentFinanciaSummaryService = new StudentFinancialSummaryService();
        }
        //============================================================================
        public async Task<IActionResult> Index(int? Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.StudentUserId = Id;
                if (Id != null)
                    using (var courseMeetingStudentsService = new CourseMeetingStudentsService())
                    {
                        ViewBag.CourseMeetingStudents = courseMeetingStudentsService.ReadCourseMeetigWithStudentId(Id.Value).Value;
                    }
                else
                    ViewBag.CourseMeetingStudents = new List<ComboBoxItems>();
                using (var banksService = new BanksService())
                {
                    ViewBag.Banks = banksService.ReadForComboBox().Value;
                };
                using (var bankPosDevicesService = new BankPosDevicesService())
                {
                    ViewBag.BankPosDevices = bankPosDevicesService.ReadForComboBox().Value;
                };
                using (var paidChequesService = new PaidChequesService())
                {
                    ViewBag.PaidCheques = paidChequesService.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Read(int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentFinanciaSummaryService.Read(Id);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] AddStudentFinancialPaymentsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentFinanciaSummaryService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentFinanciaSummaryService.Delete(viewModel);
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
            studentFinanciaSummaryService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
