using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using Common.Enums;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelViewModels.TrainingManagementViewModels;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;

namespace PanelPresentationLayer.Areas.Courses.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CoursesController : Controller
    {
        private CoursesService coursesService;
        //===========================================================================
        public CoursesController()
        {
            this.coursesService = new CoursesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var fAQService = new FAQService())
                {
                    ViewBag.FAQs = fAQService.ReadForComboBox().Value;
                }
                using (var OldStudentCommentsService = new OldStudentCommentsService())
                {
                    ViewBag.OldStudentComments = OldStudentCommentsService.ReadForComboBox().Value;
                }
                var levelGroupsTask = GetLevelGroupsTask();
                var teachersTask = GetTeachersTask();
                Task.WaitAll(levelGroupsTask, teachersTask);
                ViewBag.Teachers = teachersTask.Result;
                ViewBag.LevelGroups = levelGroupsTask.Result;
                return View();
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var data = request.Filters.ToFilterExpression();
                bool isActive = data == null ||  data.IsActive == null ? true :   Convert.ToBoolean(Convert.ToInt32(data.IsActive));
                var  result  = coursesService.Read(isActive, CourseCategoryType.Training , selectOnlyMultiTeacherCourse: false).GetGridData<CoursesViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CoursesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = coursesService.Add(viewModel, GetCurrentUserId() , CourseCategoryType.Training);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = coursesService.Find(viewModel.Id.Value  );
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody]  CoursesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = coursesService.Update(viewModel, GetCurrentUserId(),  CourseCategoryType.Training);
                return Json(result);
            }); 
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = coursesService.Delete(viewModel);
                return Json(result);
            }); 
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> UpdateDescription([FromBody] CourseDescriptionViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = coursesService.UpdateDescription(viewModel.Id, viewModel.Description, GetCurrentUserId());
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
                   return  teacherUsersService.ReadForComboBox(UserGroup.Teacher).Value;
                };
            });
            task.Start();
            return task;
        }
        //===========================================================================
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
        //===========================================================================
        Task<List<ComboBoxItems>> GetLessonsTask(int LevelId)
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var lessonsService = new LessonsService())
                {
                    return lessonsService.ReadForComboBox(LevelId, null).Value;
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
            coursesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
