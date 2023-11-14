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
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamAnsweringPercentagesController : Controller
    {
        OnlineExamAnsweringPercentagesService onlineExamAnsweringPercentagesService;
        public OnlineExamAnsweringPercentagesController()
        {
            onlineExamAnsweringPercentagesService = new OnlineExamAnsweringPercentagesService();
        }
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                //var onlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                // TeacherOnlineExamValidationComponent.Validate(onlineExamId: onlineExamId, CurrentContext.GetCurrentUserId(this).Value);
                ViewBag.Data = onlineExamAnsweringPercentagesService.Operation(Id).Value;
                return View();
            });
        }
    }
}
