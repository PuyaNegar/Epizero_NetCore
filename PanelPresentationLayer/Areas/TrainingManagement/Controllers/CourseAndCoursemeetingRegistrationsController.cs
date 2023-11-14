using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseAndCoursemeetingRegistrationsController : Controller
    {
        private CourseAndCoursemeetingRegistrationsService courseAndCoursemeetingRegistrationsService;
        //===========================================================================
        public CourseAndCoursemeetingRegistrationsController()
        {
            this.courseAndCoursemeetingRegistrationsService = new CourseAndCoursemeetingRegistrationsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index( )
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
                var result = courseAndCoursemeetingRegistrationsService.Read().GetGridData<CourseAndCoursemeetingRegistrationsViewModel>(request);
                return Json(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseAndCoursemeetingRegistrationsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
