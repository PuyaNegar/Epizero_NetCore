using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamTopRankingResultsController : Controller, IDisposable
    {
        private StudentOnlineExamResultsService studentOnlineExamResultsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamTopRankingResultsController()
        {
            studentOnlineExamResultsService = new StudentOnlineExamResultsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult Index()
        {
            try
            {
                var OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                //TeacherOnlineExamValidationComponent.Validate(OnlineExamId, CurrentContext.GetCurrentUserId(this).Value);
                ViewBag.AllResult = studentOnlineExamResultsService.Read(OnlineExamId).Value;
                return View();
            }
            catch (Exception)
            {
                return View();
            }


        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            // studentOnlineExamResultsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
