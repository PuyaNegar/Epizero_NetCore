using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class RulesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        }
    }
}
