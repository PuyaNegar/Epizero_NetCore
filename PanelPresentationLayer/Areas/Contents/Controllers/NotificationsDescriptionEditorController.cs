using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class NotificationsDescriptionEditorController : Controller
    {
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var notificationService = new CourseNotificationsService())
                {
                    var result = notificationService.FindDescription(Id).Value;
                    ViewBag.Id = Id;
                    ViewBag.Name = result.Title;
                    ViewBag.Description = result.Description;
                    return View();
                }
            });
        }
    }
}
