using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelViewModels.IdentitiesViewModels;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using Common.Enums;
using PanelViewModels.BaseViewModels;
using PanelBusinessLogicLayer.BusinessServices.SystemsServices;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize] 
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]

    public class TeacherUsersController : Controller
    {
        private TeacherUsersService teacherUsersService;
        //===========================================================================
        public TeacherUsersController()
        {
            this.teacherUsersService = new TeacherUsersService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var provinceServices = new ProvincesServices())
                {
                    ViewBag.Provinces = provinceServices.ReadForComboBox().Value;
                }
                return View();
            });

        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = teacherUsersService.Read();
                var result = sysResult.GetGridData<TeacherUsersViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================ 
        public async Task<IActionResult> Add([FromBody] TeacherUsersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherUsersService.Add(viewModel);
                return Json(result);
            });
        }
        ////============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherUsersService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        ////===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]  TeacherUsersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherUsersService.Update(viewModel);
                return Json(result);
            });
        } 
        ////===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = teacherUsersService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]

        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = teacherUsersService.ChangePassword(viewModel);
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
            teacherUsersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
