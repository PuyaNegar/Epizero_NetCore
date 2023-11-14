using System;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
 
using PanelViewModels.TrainingManagementViewModels;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class AbsentationsController : Controller
    {
        private AbsentationsService absentationsService;
        public AbsentationsController()
        {
            absentationsService = new AbsentationsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index( )
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var coursesService = new TeacherCoursesService())
                {
                    var result = coursesService.ReadWithCourseMeetings(GetCurrentUserId(), null).Value;
                    ViewBag.Courses = result;
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
                var result = absentationsService.Read(courseMeetingId, techerUserId: null, date);
                return Json(result);
            });
        }
        //=========================================================================== 
        public async Task<IActionResult> ReadForAdd()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = absentationsService.Read(courseMeetingId, techerUserId: null, currentDate: null);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> ReadByCourseMeeting( )
        {
            return await Task.Run<IActionResult>(() =>
            {

                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();

                var result = absentationsService.ReadByCourseMeeting(courseMeetingId);
                return Json(result);
            });
        }
        //===========================================================
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AbsentationsViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = absentationsService.Add(request, GetCurrentUserId(), GetCurrentUserId());
                return Json(result);
            });
        }
        //=========================================================================== 
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] AbsentationsViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = absentationsService.Update(request, GetCurrentUserId(), GetCurrentUserId());
                return Json(result);
            });
        }
        //==================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
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
