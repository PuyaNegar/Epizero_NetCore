using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class StudentOnlineExamResultsResetController : Controller
    {
        private StudentOnlineExamResultsResetService studentOnlineExamResultsResetService;
        //=====================================================
        public StudentOnlineExamResultsResetController()
        {
            studentOnlineExamResultsResetService = new StudentOnlineExamResultsResetService(); 
        }
        //=====================================================
        public async Task<IActionResult> Operation(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentOnlineExamResultsResetService.Operation(Id); 
                return Json(result);
            });
        }
        //====================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentOnlineExamResultsResetService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
