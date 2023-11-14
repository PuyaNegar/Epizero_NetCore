using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherMultiCoursesShareController : Controller
    {
        private TeacherMultiCoursesShareService teacherMultiCoursesShareService;
        //====================================================================
        public TeacherMultiCoursesShareController()
        {
            teacherMultiCoursesShareService = new TeacherMultiCoursesShareService();
        }
        //====================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherMultiCoursesShare = teacherMultiCoursesShareService.Calculate(GetCurrentUserId()).Value;
                return View();
            });
        }
        //====================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=======================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            //   teacherMultiCoursesShareSertvice?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
