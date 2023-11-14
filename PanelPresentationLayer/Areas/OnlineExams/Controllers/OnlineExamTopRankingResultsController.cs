using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineExamTopRankingResultsController : Controller
    {
        private StudentOnlineExamResultsService studentOnlineExamResultsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamTopRankingResultsController()
        {
            studentOnlineExamResultsService = new StudentOnlineExamResultsService();
        }

        public IActionResult Index(int Id)
        {
            try
            {
                // var OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                //TeacherOnlineExamValidationComponent.Validate(OnlineExamId, CurrentContext.GetCurrentUserId(this).Value);
                ViewBag.AllResult = studentOnlineExamResultsService.Read(onlineExamId: Id).Value;
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
