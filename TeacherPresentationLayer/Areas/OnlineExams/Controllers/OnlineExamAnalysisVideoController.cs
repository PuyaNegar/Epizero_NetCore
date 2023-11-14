using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class OnlineExamAnalysisVideoController : Controller
    {
        private TeacherOnlineExamsService teacherOnlineExamsService;
        //=====================================================
        public OnlineExamAnalysisVideoController()
        {
            teacherOnlineExamsService = new TeacherOnlineExamsService();
        }
        //=====================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var OnlineExamId =Convert.ToInt32(Request.Query["OnlineExamId"]);
                ViewBag.OnlineExams = teacherOnlineExamsService.Find(OnlineExamId, CurrentContext.GetCurrentUserId(this).Value).Value;
                return View();
            });
        }
        //====================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            teacherOnlineExamsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
