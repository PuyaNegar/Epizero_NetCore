using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelBusinessLogicLayer.BusinessService.ProductManagement;
//using PanelViewModels.StoresViewModels;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using Newtonsoft.Json;
using Common.Enums;

namespace PanelPresentationLayer.Areas.Stores.Controllers
{
    [Area("Contents")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherCommentsController : Controller
    {
        private TeacherCommentsService teacherCommentsService;
        //===========================================================================
        public TeacherCommentsController()
        {
            this.teacherCommentsService = new TeacherCommentsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherUserId = Id;
                return View();
            });

        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                
                dynamic filter = JsonConvert.DeserializeObject(request.Filters);
                //int? courseId = filter.CourseId == 0 ? null : filter.CourseId;
                int confirmStatusTypeId = (int)filter.ConfirmStatusType;
                var sysResult = teacherCommentsService.Read((ConfirmStatusType)confirmStatusTypeId);
                var result = sysResult.GetGridData<TeacherCommentsViewModel>(request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = teacherCommentsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] TeacherCommentsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = teacherCommentsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = teacherCommentsService.Delete(viewModel);
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
            teacherCommentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
