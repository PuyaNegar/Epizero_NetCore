using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherIntroductionsController : Controller
    {
        private TeacherIntroductionsService teacherIntroductionsService;
        //================================================================
        public TeacherIntroductionsController()
        {
            teacherIntroductionsService = new TeacherIntroductionsService();
        }
        //================================================================
        public async Task<IActionResult> Index(string Rechapcha = null)
        {
            ViewBag.Rechapcha = Rechapcha;
            return await Task.Run<IActionResult>(() =>
            {
                int teacherId = Request.Query["TeacherId"].ToString().ToIntegerIdentifier();
                ViewBag.TeacherIntroductions = teacherIntroductionsService.Read(teacherId).Value;
                return View();
            });

        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            teacherIntroductionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
