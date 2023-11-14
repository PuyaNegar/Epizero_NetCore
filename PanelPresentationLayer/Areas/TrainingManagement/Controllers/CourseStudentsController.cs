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
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseStudentsController : Controller
    {
        private CourseStudentsService courseStudentsService;
        //===========================================================================
        public CourseStudentsController()
        {
            this.courseStudentsService = new CourseStudentsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var coursesTask = GetCoursesTask();
                Task.WaitAll(coursesTask );
                ViewBag.Courses = coursesTask.Result;
                using (var courseService = new CoursesService())
                {
                    var result = courseService.Find(Id).Value;
                    ViewBag.CourseId = Id;
                    ViewBag.CourseName = result.Name;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.Read(Id).GetGridData<CourseStudentsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> AddStudentCourse([FromBody] ListCourseStudentsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.AddStudentCourse(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.Delete(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }


        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> SendSms([FromBody] StudentCustomSmsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.SendSms( CourseMeetingStudentType.Course , viewModel);
                return Json(result);
            });
        }

        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> SendSmsForCourseMeetingStudent([FromBody] StudentCustomSmsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseStudentsService.SendSms(CourseMeetingStudentType.CourseMeeting , viewModel);  
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
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
