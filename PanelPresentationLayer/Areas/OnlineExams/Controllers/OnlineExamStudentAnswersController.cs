using System;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
   // [TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamStudentAnswersController : Controller
    {
        private OnlineExamStudentAnswersService onlineEmStudentAnswersService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentAnswersController()
        {
            this.onlineEmStudentAnswersService = new OnlineExamStudentAnswersService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = onlineEmStudentAnswersService.Read(Id).Value;
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineEmStudentAnswersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
