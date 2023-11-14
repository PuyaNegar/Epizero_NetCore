using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.OnlineExamsViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class DependentOnlineExamsController : Controller, IDisposable
    {
        private DependentOnlineExamsService onlineExamsService;
        //===========================================================================
        public DependentOnlineExamsController()
        {
            this.onlineExamsService = new DependentOnlineExamsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var teachersTask = GetTeachersTask();
                Task.WaitAll(teachersTask);
                ViewBag.Teachers = teachersTask.Result;
                return View();
            });
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> ExportWithMultipleOptionPage(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var onlineExamQuestionsService = new OnlineExamQuestionsService())
                {
                    ViewBag.Questions = onlineExamQuestionsService.Read(  Id, true).Value;
                    return View();
                } 
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamsService.Read().GetGridData<OnlineExamsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OnlineExamsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamsService.Find(viewModel.Id.Value );
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] OnlineExamsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamsService.Delete(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetTeachersTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var teacherUsersService = new TeacherUsersService())
                {
                    return teacherUsersService.ReadForComboBox(UserGroup.Teacher).Value;
                };
            });
            task.Start();
            return task;
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
            onlineExamsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
