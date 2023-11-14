using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseMeetingDedicatedTeachersController : Controller
    {
        private CourseMeetingDedicatedTeachersService courseMeetingDedicatedTeachersService;
        //================================================
        public CourseMeetingDedicatedTeachersController()
        {
            courseMeetingDedicatedTeachersService = new CourseMeetingDedicatedTeachersService(); 
        } 
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingDedicatedTeachersService.Find(courseMeetingId: viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] CourseMeetingDedicatedTeachersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingDedicatedTeachersService.AddOrUpdate(viewModel, GetCurrentUserId());
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
            courseMeetingDedicatedTeachersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
