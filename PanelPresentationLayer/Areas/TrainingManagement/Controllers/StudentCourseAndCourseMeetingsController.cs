using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using System; 
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class StudentCourseAndCourseMeetingsController : Controller
    {
        private StudentCourseAndCourseMeetingsService studentCourseAndCourseMeetingsService;
        //=============================================================
        public StudentCourseAndCourseMeetingsController()
        {
            studentCourseAndCourseMeetingsService = new StudentCourseAndCourseMeetingsService(); 
        } 
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Read([FromBody] IntegerIdentifierViewModel viewModel )
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentCourseAndCourseMeetingsService.Read( viewModel.Id.Value);
                return Json(result);
            }); 
        }
        //=============================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentCourseAndCourseMeetingsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
