using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class IndependentOnlineExamsController : Controller
    {
        private IndependentOnlineExamsService independentOnlineExamsService;
        //===========================================================================
        public IndependentOnlineExamsController()
        {
            this.independentOnlineExamsService = new IndependentOnlineExamsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var fieldsService = new FieldsService())
                {
                    ViewBag.Fields = fieldsService.ReadForComboBox().Value;
                }
                using (var teacherUsersService = new TeacherUsersService())
                {
                    ViewBag.Teachers = teacherUsersService.ReadForComboBox(UserGroup.Teacher).Value;
                }
                using (var coursesService = new CoursesService())
                {
                    var courseModel = (CoursesViewModel)coursesService.Find(Id).Value;
                    ViewBag.CourseName = courseModel.Name;
                    ViewBag.TeacherUserId = courseModel.TeacherUserId;
                    ViewBag.CourseId = Id;
                    ViewBag.IsMultiTeacher = (bool)courseModel.IsMultiTeacher.ToBoolean();
                    return View();
                }
            });
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = independentOnlineExamsService.Read(Id).GetGridData<IndependentOnlineExamsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IndependentOnlineExamsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = independentOnlineExamsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = independentOnlineExamsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] IndependentOnlineExamsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = independentOnlineExamsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = independentOnlineExamsService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public IActionResult UploadPDFUploadQuestion([FromQuery] int OnlineExamId, [FromBody] FileDataViewModel viewModel)
        {
            independentOnlineExamsService.UploadPDFUploadQuestion(OnlineExamId, viewModel, GetCurrentUserId());
            return Ok();
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
            independentOnlineExamsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
