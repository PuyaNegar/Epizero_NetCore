using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices; 
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using System;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class IndependentOnlineExamsCopyController : Controller
    {
        private IndependentOnlineExamsCopyService independentOnlineExamsCopyService;
        //===========================================================================
        public IndependentOnlineExamsCopyController()
        {
            independentOnlineExamsCopyService = new IndependentOnlineExamsCopyService();
        }

        //===========================================================================
        public IActionResult Operation(int Id)
        {
            var result = independentOnlineExamsCopyService.Operation(Id, CurrentContext.GetCurrentUserId(this));
            return Json(result);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            independentOnlineExamsCopyService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
