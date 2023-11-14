using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using System;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CalculateCourseMultiTeacherSharesController : Controller
    {
        private CalculateCourseMultiTeacherSharesService calculateCourseMultiTeacherSharesService;
        //=============================================
        public CalculateCourseMultiTeacherSharesController()
        {
            calculateCourseMultiTeacherSharesService = new CalculateCourseMultiTeacherSharesService();
        } 
        //=============================================
        public async Task<IActionResult> Index(int? Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.CourseId = Id;
                if (Id != null)
                {
                    using (var coursesService = new CoursesService())
                    {
                        var result = coursesService.Find(Id.Value).Value;
                        ViewBag.CourseName = result.Name;
                    }
                }
                return View();
            });
        }
        //=========================================================================
        public async Task<IActionResult> Read(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = calculateCourseMultiTeacherSharesService.Calculate(Id);
                return Json(result);
            });
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            calculateCourseMultiTeacherSharesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
