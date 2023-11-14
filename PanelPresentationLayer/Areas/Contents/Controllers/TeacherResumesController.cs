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
using PanelViewModels.IdentitiesViewModels;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class TeacherResumesController : Controller
    {
        private TeacherResumesService teacherResumesService;
        //===========================================================================
        public TeacherResumesController()
        {
            this.teacherResumesService = new  TeacherResumesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            { 
                ViewBag.TeacherUserId = Id;
                using (var teacherUserService = new TeacherUsersService())
                {
                    var result = teacherUserService.Find(Id).Value;
                    ViewBag.TeacherFulName = result.FirstName + " " + result.LastName;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read(int Id , [FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = teacherResumesService.Read(Id);
                var result = sysResult.GetGridData<TeacherResumesViewModel>    (request); 
                return Json(result);
            }); 
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherResumesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherResumesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherResumesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] TeacherResumesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherResumesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel) 
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherResumesService.Delete(viewModel);
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
            teacherResumesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
