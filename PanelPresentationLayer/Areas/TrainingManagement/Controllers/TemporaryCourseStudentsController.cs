using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.TrainingManagementViewModels;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class TemporaryCourseStudentsController : Controller
    {
        private TemporaryCourseStudentsService temporaryCourseStudentsService;
        //===================================================
        public TemporaryCourseStudentsController()
        {
            temporaryCourseStudentsService = new TemporaryCourseStudentsService(); 
        }
        //===================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var data = request.Filters.ToFilterExpression();
                bool isActive = data == null || data.IsActive == null ? true : Convert.ToBoolean(Convert.ToInt32(data.IsActive));
                var  result = temporaryCourseStudentsService.Read(isActive)  
                .GetGridData<TemporaryCourseStudentsViewModel>(request);
                return Json(result);
            }); 
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            temporaryCourseStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
