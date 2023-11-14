using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
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
    public class CourseCopyController : Controller
    {
        private CourseCopyService courseCopyService;
        //===========================================================================
        public CourseCopyController()
        {
            this.courseCopyService = new CourseCopyService();
        }

        //===========================================================================
        public IActionResult Operation(int Id)
        {
            var result = courseCopyService.Operation(Id , CurrentContext.GetCurrentUserId(this));
            return Json(result);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseCopyService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
