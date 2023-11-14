using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.OnlineExamsViewModels;
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
    public class MultipleChoiceQuestionsController : Controller
    {
        private MultipleChoiceQuestionsService multipleChoiceQuestionsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public MultipleChoiceQuestionsController()
        {
            this.multipleChoiceQuestionsService = new MultipleChoiceQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index( )
        {
            return await Task.Run<IActionResult>(() =>
            {
                var levelGroupsTask = GetLevelGroupsTask();
                ViewBag.LevelGroups = levelGroupsTask.Result;
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> QuestionDesignPage(int? Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var levelGroupsTask = GetLevelGroupsTask();
                ViewBag.LevelGroups = levelGroupsTask.Result;
                if (Id == null)
                {
                    ViewBag.QuestionDesignType = QuestionDesignType.Create;
                    return View();
                }
                else
                {
                    ViewBag.QuestionDesignType = QuestionDesignType.Edit;
                    var result = multipleChoiceQuestionsService.Find(Id.Value/*, GetCurrentUserId()*/).Value;
                    ViewBag.Data = result;
                    return View();
                }
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                int lessonId = Convert.ToInt32(data.LessonId);
                var sysResult = multipleChoiceQuestionsService.Read(lessonId);
                var result = sysResult.GetGridData<MultipleChoiceQuestionsViewModel>
                    (request);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MultipleChoiceQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = multipleChoiceQuestionsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = multipleChoiceQuestionsService.Find(viewModel.Id.Value/*, GetCurrentUserId()*/);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MultipleChoiceQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = multipleChoiceQuestionsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = multipleChoiceQuestionsService.Delete(viewModel.Id.Value/*, GetCurrentUserId()*/);
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
            multipleChoiceQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
