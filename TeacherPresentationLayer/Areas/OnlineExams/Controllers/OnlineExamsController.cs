using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeacherPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class OnlineExamsController : Controller
    {
        private TeacherOnlineExamsService teacherOnlineExamsService;
        public OnlineExamsController()
        {
            teacherOnlineExamsService = new TeacherOnlineExamsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult Index()
        {
            ViewBag.OnlineExams = teacherOnlineExamsService.Read(GetCurrentUserId()).Value;
            return View();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
 
        public async Task<IActionResult> Find()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                var result = teacherOnlineExamsService.Find(OnlineExamId, CurrentContext.GetCurrentUserId(this).Value);
                return Ok(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            teacherOnlineExamsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
