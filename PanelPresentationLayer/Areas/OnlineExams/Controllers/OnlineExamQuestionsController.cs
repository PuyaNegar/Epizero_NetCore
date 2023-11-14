using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.OnlineExamsViewModels;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamQuestionsController : Controller
    {
        private OnlineExamQuestionsService onlineExamQuestionsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamQuestionsController()
        {
            this.onlineExamQuestionsService = new OnlineExamQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var onlineExamsService = new OnlineExamsService())
                {
                    var result = onlineExamsService.Find(Id).Value;
                    ViewBag.OnlineExamName = result.Name;
                    ViewBag.QuestionTypeName = result.QuestionTypeName;
                }
                var levelGroupsTask = GetLevelGroupsTask();
                ViewBag.LevelGroups = levelGroupsTask.Result;
                ViewBag.TeacherId = GetCurrentUserId();
                ViewBag.OnlineExamId = Id;
               
                return View();
            }); 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamQuestionsService.Read( Id , IncludeMultipleOptions : false);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OnlineExamQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamQuestionsService.Add(viewModel.QuestionId, viewModel.OnlineExamId, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] OnlineExamQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamQuestionsService.Delete(viewModel.Id, viewModel.OnlineExamId, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> UpdateQuestionCorrectOption([FromBody] OnlineExamQuestionCorrectOptionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamQuestionsService.UpdateQuestionCorrectOption(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> FindOnlineExamQuestion(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamQuestionsService.FindOnlineExamQuestion(onlineExamQuestionId: Id);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        Task<List<ComboBoxItems>> GetLevelGroupsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var levelGroupsService = new LevelGroupsService())
                {
                    return levelGroupsService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineExamQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
