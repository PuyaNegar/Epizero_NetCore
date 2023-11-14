using System;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelViewModels.IdentitiesViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using Common.Enums;
using System.Collections.Generic;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AdminUsersController : Controller
    {
        private AdminUsersService adminUsersService;
        //===========================================================================
        public AdminUsersController()
        {
            this.adminUsersService = new AdminUsersService();
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
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic filter = request.Filters.ToFilterExpression();
                var userGroup = (UserGroup)Convert.ToInt32(filter.UserGroupId);
                var result = adminUsersService.Read(userGroup).GetGridData<AdminUsersViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> Add([FromBody] AdminUsersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = adminUsersService.Add(viewModel);
                return Json(sysResult);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> ChangeCurrentUserPassword([FromBody] CurrentUserChangePasswordViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = adminUsersService.ChangePassword(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]

        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = adminUsersService.ChangePassword(viewModel);
                return Json(result);
            });
        }

        //********************************************************************
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = adminUsersService.Find((int)viewModel.Id.Value);
                return Json(result);
            });
        }
        //********************************************************************
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] EditAdminUsersViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = adminUsersService.Update(viewModel);
                return Json(result);
            });

        } 
        ////===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = adminUsersService.Delete(viewModel);
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
            adminUsersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
