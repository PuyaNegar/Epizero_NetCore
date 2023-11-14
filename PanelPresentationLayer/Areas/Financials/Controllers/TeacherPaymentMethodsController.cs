using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
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
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherPaymentMethodsController : Controller
    {
        private TeacherPaymentMethodsService teacherPaymentMethodsService;
        //===========================================================================
        public TeacherPaymentMethodsController()
        {
            this.teacherPaymentMethodsService = new TeacherPaymentMethodsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseService = new CoursesService())
                {
                    var result = courseService.Find(Id).Value;
                    ViewBag.CourseName = result.Name;
                    ViewBag.CourseId = Id;
                }
                using (var courseMeeting = new CourseMeetingsService())
                {
                    var result = courseMeeting.GetTeachersForComboBox(Id).Value;
                    ViewBag.Teachers = result;
                }

                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = teacherPaymentMethodsService.Read(Id);
                var result = sysResult.GetGridData<TeacherPaymentMethodsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherPaymentMethodsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherPaymentMethodsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherPaymentMethodsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TeacherPaymentMethodsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherPaymentMethodsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherPaymentMethodsService.Delete(viewModel);
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
            teacherPaymentMethodsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
