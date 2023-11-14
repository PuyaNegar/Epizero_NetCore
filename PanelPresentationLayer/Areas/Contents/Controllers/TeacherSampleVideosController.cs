using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
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
    public class TeacherSampleVideosController : Controller
    {
        private TeacherSampleVideosService teacherSampleVideosService;
        //===========================================================================
        public TeacherSampleVideosController()
        {
            this.teacherSampleVideosService = new TeacherSampleVideosService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherId = Id;
                using (var teacherUserService = new TeacherUsersService())
                {
                    var result = teacherUserService.Find(Id).Value;
                    ViewBag.TeacherFulName = result.FirstName +" " + result.LastName;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request ,int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = teacherSampleVideosService.Read(Id);
                var result = sysResult.GetGridData<TeacherSampleVideosViewModel>
                (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherSampleVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSampleVideosService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSampleVideosService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TeacherSampleVideosViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSampleVideosService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherSampleVideosService.Delete(viewModel);
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
            teacherSampleVideosService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
