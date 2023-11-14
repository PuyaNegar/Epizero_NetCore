using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using System;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class OnlineExamAnsweringPercentagesController : Controller
    {
        OnlineExamAnsweringPercentagesService onlineExamAnsweringPercentagesService;
        public OnlineExamAnsweringPercentagesController()
        {
            onlineExamAnsweringPercentagesService = new OnlineExamAnsweringPercentagesService();
        }
        //====================================================
        public async Task< IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var onlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                TeacherOnlineExamValidationComponent.Validate(onlineExamId: onlineExamId, CurrentContext.GetCurrentUserId(this).Value);
                ViewBag.Data = onlineExamAnsweringPercentagesService.Operation(onlineExamId).Value;
                return View();
            });
        } 
        //====================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
             onlineExamAnsweringPercentagesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
