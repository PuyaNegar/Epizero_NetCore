using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.TrainingsViewModels;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class BooksFiltersController : Controller
    {
        private CourseFilterService courseFilterService;
        //========================================================================= 
        public BooksFiltersController()
        {
            courseFilterService = new CourseFilterService();
        }
        //========================================================================= 
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Data = courseFilterService.ReadByCourseTypeId((int)CourseType.Book).Value;
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
            courseFilterService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
