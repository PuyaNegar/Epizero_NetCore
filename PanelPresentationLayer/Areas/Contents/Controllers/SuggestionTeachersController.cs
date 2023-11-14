using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters; 
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelViewModels.ContentsViewModels;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class SuggestionTeachersController : Controller
    {
        private SuggestionTeachersService suggestionTeachersService;
        //===========================================================================
        public SuggestionTeachersController()
        {
            this.suggestionTeachersService = new SuggestionTeachersService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var teacherUserService = new TeacherUsersService() )
                {
                    ViewBag.Teachers = teacherUserService.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = suggestionTeachersService.Read();
                var result = sysResult.GetGridData<SuggestionTeachersViewModel>
                (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SuggestionTeachersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = suggestionTeachersService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = suggestionTeachersService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] SuggestionTeachersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = suggestionTeachersService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel) 
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = suggestionTeachersService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            suggestionTeachersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
