using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AboutUsDescriptionEditorController : Controller
    {
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var blogsService = new AboutUsService())
                {
                    var result = blogsService.FindDescription(Id).Value;
                    ViewBag.Id = Id;
                    ViewBag.Name = result.Title;
                    ViewBag.Description = result.Description;
                    return View();
                }
            });
        }
    }
}
