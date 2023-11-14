using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.BaseViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseSearchController : Controller
    {
        private CourseSearchService courseSearchService;
        public CourseSearchController()
        {
            courseSearchService = new  CourseSearchService();
        } 
        //========================================================================= 
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> Operation([FromQuery] SearchValueViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseSearchService.Operation(viewModel.searchValue );
                return Json(result);
            });
        } 
        //========================================================================= 
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseSearchService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
