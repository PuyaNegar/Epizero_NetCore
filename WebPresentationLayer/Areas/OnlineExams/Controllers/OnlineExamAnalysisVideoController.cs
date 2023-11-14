using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamAnalysisVideoController : Controller
    {
        private OnlineExamAnalysisVideoService onlineExamAnalysisVideoService;
        private UsersService usersService;
        //=====================================================
        public OnlineExamAnalysisVideoController()
        {
            onlineExamAnalysisVideoService = new OnlineExamAnalysisVideoService();
            usersService = new UsersService();
        }
        //=====================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                ViewBag.StudentUser = usersService.Find(CurrentContext.GetCurrentUserId(this).Value).Value;
                ViewBag.OnlineExams = onlineExamAnalysisVideoService.Find(OnlineExamId).Value;
                return View();
            });
        }
        //====================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineExamAnalysisVideoService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
