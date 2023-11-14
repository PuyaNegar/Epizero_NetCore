using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
 
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class StudentCoursesController : Controller
    {
        private StudentCoursesService studentCoursesService;
        //========================================================================
        public StudentCoursesController()
        {
            studentCoursesService = new StudentCoursesService(); 
        }
        //========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = studentCoursesService.Read(GetCurrentUserId()).Value; 
                return View();
            });
        } 
        //========================================================================= 
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentCoursesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
