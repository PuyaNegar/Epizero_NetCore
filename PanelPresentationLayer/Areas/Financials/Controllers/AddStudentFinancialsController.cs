using Common.Enums;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    // [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AddStudentFinancialsController : Controller
    {
        private AddStudentFinancialsService addStudentFinancialsService;
        //===========================================================================
        public AddStudentFinancialsController()
        {
            addStudentFinancialsService = new AddStudentFinancialsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var paidChequesService = new PaidChequesService())
                {
                    ViewBag.PaidCheques = paidChequesService.ReadForComboBox().Value;
                }
                var coursesTask = GetCoursesTask();
                var banksTask = GetBanksTask();
                var bankPosDevicesTask = GetBankPosDevicesTask();
                Task.WaitAll(coursesTask, banksTask, bankPosDevicesTask);
                ViewBag.Courses = coursesTask.Result;
                ViewBag.Banks = banksTask.Result;
                ViewBag.BankPosDevices = bankPosDevicesTask.Result;
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Operation([FromBody] AddStudentFinancialsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = addStudentFinancialsService.Operation(viewModel, CurrentContext.GetCurrentUserId(this) , (CourseMeetingStudentType)viewModel.CourseMeetingStudentTypeId);
                return Json(result);
            });
        }
        //===========================================================================
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
        //===========================================================================
        Task<List<ComboBoxItems>> GetBanksTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var banksService = new BanksService())
                {
                    return banksService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //=======================================================
        Task<List<ComboBoxItems>> GetBankPosDevicesTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var bankPosDevicesService = new BankPosDevicesService())
                {
                    return bankPosDevicesService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
