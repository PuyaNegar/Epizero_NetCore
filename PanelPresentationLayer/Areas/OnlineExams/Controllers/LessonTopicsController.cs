using System;
using System.Threading.Tasks; 
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.OnlineExamViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class LessonTopicsController : Controller , IDisposable
    {
        private LessonTopicsService lessonTopicsService;
        //===========================================================================
        public LessonTopicsController()
        {
            this.lessonTopicsService = new LessonTopicsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.LessonId = Id;
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request , int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = lessonTopicsService.Read(Id);
                var result = sysResult.GetGridData<LessonTopicsViewModel>
                    (request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LessonTopicsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonTopicsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonTopicsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] LessonTopicsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonTopicsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonTopicsService.Delete(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ReadForComboBox(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonTopicsService.ReadForComboBox(Id );
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
            lessonTopicsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
