using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using PanelViewModels.BasicDefinitionsViewModels;
using PanelViewModels.BaseViewModels;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize] 
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TagsController : Controller
    {
        private TagsService tagsService;
        //===========================================================================
        public TagsController()
        {
            this.tagsService = new TagsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            }); 
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = tagsService.Read();
                var result = sysResult.GetGridData<TagsViewModel>
                    (request);
                return Json(result);
            }); 
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] TagsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                var result = tagsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            }); 
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = tagsService.Find(viewModel.Id.Value);
                return Json(result);
            }); 
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody]  TagsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            { 
                var result = tagsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            }); 
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = tagsService.Delete(viewModel);
                return Json(result);
            });

        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
       
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            tagsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
