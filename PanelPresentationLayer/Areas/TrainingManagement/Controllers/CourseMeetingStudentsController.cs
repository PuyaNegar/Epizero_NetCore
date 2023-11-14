using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class CourseMeetingStudentsController : Controller
    {
        private CourseMeetingStudentsService courseMeetingStudentsService;
        //===========================================================================
        public CourseMeetingStudentsController()
        {
            this.courseMeetingStudentsService = new CourseMeetingStudentsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var coursesTask = GetCoursesTask();
                Task.WaitAll(coursesTask);
                ViewBag.Courses = coursesTask.Result;
                using (var courseMeetingService = new CourseMeetingsService())
                {
                    var result = courseMeetingService.Find(Id).Value;
                    ViewBag.CourseMeetingName = result.Name;
                    ViewBag.CourseMeetingId = Id;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingStudentsService.Read(Id).GetGridData<CourseMeetingStudentsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseMeetingStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingStudentsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> AddStudentCourseMeeting([FromBody] ListCourseMeetingStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingStudentsService.AddStudentCourseMeeting(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel  viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseMeetingStudentsService.Delete(viewModel , GetCurrentUserId());
                return Json(result);
            }); 
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //===========================================================================
        public UserGroup GetCurrentUserGroup()
        {
            return CurrentContext.GetCurrentUserGroup(this);
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
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseMeetingStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
