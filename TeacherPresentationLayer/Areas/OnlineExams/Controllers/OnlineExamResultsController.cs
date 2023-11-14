using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using TeacherPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamResultsController : Controller, IDisposable
    {
        private StudentOnlineExamResultsService studentOnlineExamResultsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamResultsController()
        {
            this.studentOnlineExamResultsService = new StudentOnlineExamResultsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                try
                {
                    var OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                    ViewBag.AllResult = studentOnlineExamResultsService.Read(OnlineExamId).Value;
                    return View();
                }
                catch (Exception)
                {
                    return View();
                }

            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentOnlineExamResultsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
