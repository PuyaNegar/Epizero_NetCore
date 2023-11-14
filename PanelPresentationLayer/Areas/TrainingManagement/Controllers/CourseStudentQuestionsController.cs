using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseStudentQuestionsController : Controller
    {
        private CourseStudentQuestionsService courseStudentQuestionsService;
        //===========================================================================
        public CourseStudentQuestionsController()
        {
            courseStudentQuestionsService = new CourseStudentQuestionsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var coursesTask = GetCoursesTask();
                ViewBag.Courses = coursesTask.Result;
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic filter = JsonConvert.DeserializeObject(request.Filters);
                int? courseId = filter.CourseId == 0 ? null : filter.CourseId;
                int confirmStatusTypeId = filter.ConfirmStatusTypeId;
                var sysResult = courseStudentQuestionsService.Read((ConfirmStatusType)confirmStatusTypeId, courseId);
                var result = sysResult.GetGridData<StudentCourseQuestionsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================ 
        public async Task<IActionResult> AddAdminAnswers([FromBody] StudentCourseQuestionAdminAnswersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.AddAdminAnswers(viewModel, GetCurrentUserId());
                return Json(result);
            }); 
        }
        //============================================================================ 
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ReadAnswers(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.ReadAnswers(Id);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> ConfirmAnswer([FromBody] StudentCourseQuestionAnswerConfirmViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.ConfirmAnswer(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentCourseQuestionConfirmViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentQuestionsService.Confirm(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
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
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseStudentQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
