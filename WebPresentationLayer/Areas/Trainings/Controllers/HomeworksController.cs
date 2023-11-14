using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.TrainingsViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class HomeworksController : Controller
    {
        private HomeworksService studentHomeworksService;
        //=========================================================================
        public HomeworksController()
        {
            studentHomeworksService = new HomeworksService();
        }
        //========================================================================= 
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = studentHomeworksService.ReadAllWithAverageGrade(GetCurrentUserId()).Value;
                return View();
            });
        }
        //============================================================
        [HttpPost]
        public async Task<IActionResult> AddAnswer([FromBody] HomeworkFilePathViewModel viewModel)
        {
              return await Task.Run<IActionResult>(() =>
                {
                    var result = studentHomeworksService.AddAnswer(viewModel, GetCurrentUserId());
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
            studentHomeworksService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
