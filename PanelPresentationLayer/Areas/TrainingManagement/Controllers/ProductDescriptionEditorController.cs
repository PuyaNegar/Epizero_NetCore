﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer.Areas.Courses.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class ProductDescriptionEditorController : Controller
    {
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var productService = new ProductsService())
                {
                    var result = productService.FindDescription(Id).Value;
                    ViewBag.Id = Id;
                    ViewBag.Name = result.Name;
                    ViewBag.Description = result.Description;
                    return View();
                }
            });
        }
    }
}
