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
    public class ViewOnlineCourseBookletsController : Controller
    {
        private CourseBookletsService courseBookletsService;
        
        public ViewOnlineCourseBookletsController()
        {
            courseBookletsService = new CourseBookletsService();
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---= 
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.CourseBooklet = courseBookletsService.Find(Id).Value;
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
