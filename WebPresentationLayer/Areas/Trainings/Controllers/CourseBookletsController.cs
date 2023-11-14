using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.BaseViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CourseBookletsController : Controller
    {
        private CourseBookletsService courseBookletsService;
        
        public CourseBookletsController()
        {
            courseBookletsService = new CourseBookletsService();
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---= 
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int coursesId = Request.Query["CoursesId"].ToString().ToIntegerIdentifier();
                ViewBag.Data = courseBookletsService.Read(coursesId , GetCurrentUserId()).Value;
                return View();
            });
        }
       
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseBookletsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
