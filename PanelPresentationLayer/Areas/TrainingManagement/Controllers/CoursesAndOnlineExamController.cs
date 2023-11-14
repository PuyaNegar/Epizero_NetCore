using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using Common.Enums;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelViewModels.TrainingManagementViewModels;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CoursesAndOnlineExamController : Controller
    {
        private CoursesService coursesService;
        //===========================================================================
        public CoursesAndOnlineExamController()
        {
            this.coursesService = new CoursesService();
        }
        //===========================================================================
        public async Task<IActionResult> ReadMultiTeacherCourse([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var data = request.Filters.ToFilterExpression(); 
                var result = coursesService.Read(IsActive :null , courseCategoryType: null , selectOnlyMultiTeacherCourse: true).GetGridData<CoursesViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            coursesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
