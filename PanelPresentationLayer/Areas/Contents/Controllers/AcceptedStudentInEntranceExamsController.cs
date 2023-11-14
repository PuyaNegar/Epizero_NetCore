using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AcceptedStudentInEntranceExamsController : Controller
    {
        private AcceptedStudentInEntranceExamsService acceptedStudentInEntranceExamsService;
        //======================================================
        public AcceptedStudentInEntranceExamsController()
        {
            acceptedStudentInEntranceExamsService = new AcceptedStudentInEntranceExamsService();
        }
        //======================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.TeacherUserId = Id;
                using (var teacherUsersService = new TeacherUsersService())
                {
                    var result = teacherUsersService.Find(Id).Value;
                    ViewBag.TeacherFullName = result.FirstName + " " + result.LastName; 
                }
                return View();
            });
        }
        //======================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request , int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic filter = request.Filters.ToFilterExpression();
                int entranceExamTypeId = filter.EntranceExamTypeId == null ? 0 : filter.EntranceExamTypeId;
                var result = acceptedStudentInEntranceExamsService.Read(Id, entranceExamTypeId).GetGridData<AcceptedStudentInEntranceExamsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AcceptedStudentInEntranceExamsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = acceptedStudentInEntranceExamsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = acceptedStudentInEntranceExamsService.Delete(viewModel);
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
            acceptedStudentInEntranceExamsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
