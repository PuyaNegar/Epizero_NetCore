using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebViewModels.TrainingsViewModels;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Functions;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class CourseStudentQuestionLikesController : Controller
    {
        private CourseStudentQuestionLikesService courseStudentQuestionLikesService;
        //=========================================================================
        public CourseStudentQuestionLikesController()
        {
            courseStudentQuestionLikesService = new CourseStudentQuestionLikesService();
        }
        //========================================================================= 
        [HttpGet]
        [ApiService]
        public async Task<IActionResult> ReadCountStudentQuestionLike([FromQuery] StudentQuestionLikeViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionLikesService.ReadCountStudentQuestionLike(viewModel.CourseStudentQuestionId).Value;
                return Ok(result);
            });
        }
        //============================================================
        [HttpPost]
        public async Task<IActionResult> AddStudentQuestionLike([FromBody] StudentQuestionLikeViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionLikesService.AddStudentQuestionLike(GetCurrentUserId() , viewModel.CourseStudentQuestionId);
                return Ok(result);
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
            courseStudentQuestionLikesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
