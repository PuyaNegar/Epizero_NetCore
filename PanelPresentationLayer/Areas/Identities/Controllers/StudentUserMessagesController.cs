using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class StudentUserMessagesController : Controller
    {
        private StudentUserMessagesService studentUserMessagesService;
        //===========================================================================
        public StudentUserMessagesController()
        {
            this.studentUserMessagesService = new StudentUserMessagesService();
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
              
               
                var sysResult = studentUserMessagesService.Read( );
                var result = sysResult.GetGridData<StudentUserMessagesViewModel>(request);
                return Json(result);
            });

        }
         
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserMessagesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] StudentUserMessagesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserMessagesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserMessagesService.Delete(viewModel);
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
            studentUserMessagesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
