using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.OnlineExamsViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    // [TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamStudentsController : Controller, IDisposable
    {
        private OnlineExamStudentsService onlineExamStudentsService;
        //==================================================================================
        public OnlineExamStudentsController()
        {
            this.onlineExamStudentsService = new OnlineExamStudentsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var coursesTask = GetCoursesTask();
                var onlineExamTask = GetOnlineExamTask(Id);
                Task.WaitAll(coursesTask, onlineExamTask);
                ViewBag.OnlieExamId = Id;
                ViewBag.OnlineExamName = onlineExamTask.Result.Name;
                ViewBag.QuestionTypeName = onlineExamTask.Result.QuestionTypeName;
                ViewBag.Courses = coursesTask.Result;
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Add([FromBody] OnlineExamStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentsService.Add(viewModel.StudentUserIds, viewModel.OnlineExamId, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentsService.Read(Id).GetGridData<OnlineExamStudentsViewModel>(request);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] OnlineExamStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentsService.Delete(viewModel.Id, viewModel.OnlineExamId/*, GetCurrentUserId()*/);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<List<ComboBoxItems>> GetCoursesTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var coursesService = new CoursesService())
                {
                    return coursesService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<OnlineExamsViewModel> GetOnlineExamTask(int Id)
        {
            var task = new Task<OnlineExamsViewModel>(() =>
            {
                using (var onlineExamsService = new OnlineExamsService())
                {
                    var result = onlineExamsService.Find(Id).Value;
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineExamStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
