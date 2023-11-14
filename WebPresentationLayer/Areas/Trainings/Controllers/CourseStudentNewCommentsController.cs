using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.TrainingsViewModels;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class CourseStudentNewCommentsController : Controller
    {
        private CourseStudentNewCommentsService courseStudentNewCommentsService;
        //=========================================================================
        public CourseStudentNewCommentsController()
        {
            courseStudentNewCommentsService = new CourseStudentNewCommentsService();
        }
        //========================================================================= 
        [HttpPost]
        public async Task<IActionResult> AddStudentNewComments([FromBody] AddNewCommetsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentNewCommentsService.AddStudentNewComments(viewModel , GetCurrentUserId());
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
            courseStudentNewCommentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
