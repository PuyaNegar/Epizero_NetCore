using System;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.TrainingManagementViewModels;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{

    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class AbsentationsController : Controller
    {
        private AbsentationsService absentationsService;
        public AbsentationsController()
        {
            absentationsService = new AbsentationsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var CouresService = new CoursesService())
                {
                    var result = CouresService.Find(Id).Value;
                    ViewBag.CourseId = Id;
                    ViewBag.CourseName = result.Name;

                }
                //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                using (var courseMeetingService = new CourseMeetingsService())
                {
                    var result = courseMeetingService.ReadForComboBox(Id).Value;
                    ViewBag.CourseMeetings = result;
                    return View();
                }
            });
        }
        //=========================================================================== 
        public async Task<IActionResult> ReadForUpdate()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var date = Request.Query["Date"].ToString().ToDate().ToLocalDateTime();
                var result = absentationsService.Read(courseMeetingId  , techerUserId : null  ,  date);
                return Ok(result);
            });
        }
        //=========================================================================== 
        public async Task<IActionResult> ReadForAdd()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = absentationsService.Read(courseMeetingId, techerUserId: null, currentDate: null);
                return Ok(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ReadByCourseMeeting([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                int courseMeetingId = Convert.ToInt32(data.CourseMeetingId);
                var result = absentationsService.ReadByCourseMeeting(courseMeetingId).GetGridData<AbsentationsViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AbsentationsViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = absentationsService.Add(request  ,  GetCurrentUserId(), techerUserId: null);
                return Ok(result);
            });
        }
        //=========================================================================== 
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] AbsentationsViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = absentationsService.Update(request  , GetCurrentUserId() ,  teacherUserId: null);
                return Ok(result);
            });
        }
        //=========================================================== PriveteMethods
        #region PriveteMethods
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        #endregion
        //===========================================================  Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            absentationsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
