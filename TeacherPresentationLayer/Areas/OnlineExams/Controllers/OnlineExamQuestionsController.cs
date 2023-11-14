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
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamQuestionsController : Controller
    {
        private OnlineExamQuestionsService onlineExamQuestionsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamQuestionsController()
        {
            this.onlineExamQuestionsService = new OnlineExamQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                TeacherOnlineExamValidationComponent.Validate(onlineExamId: Id, GetCurrentUserId());
                var result = onlineExamQuestionsService.Read(Id, IncludeMultipleOptions: false);
                ViewBag.OnlineExamQuestions = result;
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
       [HttpGet]
        public async Task<IActionResult> Find()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int Id = Convert.ToInt32(Request.Query["Id"]);
                var result = onlineExamQuestionsService.Find(Id);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineExamQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
