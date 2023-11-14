using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseMeetingVideosShowController : Controller
    {
        private CourseMeetingVideosService courseMeetingVideosService;
        //===========================================================================
        public CourseMeetingVideosShowController()
        {
            this.courseMeetingVideosService = new CourseMeetingVideosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseMeetingServiceVideo = new CourseMeetingVideosService())
                {
                    var result = courseMeetingServiceVideo.Find(Id).Value;
                    ViewBag.Link = result.Link;
                }
                return View();
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseMeetingVideosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
