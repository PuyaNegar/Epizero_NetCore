using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class StudentAcademicProgressChartsController : Controller
    {
        StudentAcademicProgressChartsService studentAcademicProgressChartsService;
        //====================================================
        public StudentAcademicProgressChartsController()
        {
            studentAcademicProgressChartsService = new StudentAcademicProgressChartsService();
        }
        //=====================================================
        public async Task<IActionResult> Read(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentAcademicProgressChartsService.Read(Id, CurrentContext.GetCurrentUserId(this).Value);
                return Json(result);
            });
        }
        //=================================================== 
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentAcademicProgressChartsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
