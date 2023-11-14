using Common.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using PanelViewModels.TeacherTrainingsViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeacherPresentationLayer.Infrastracture.Filters;
using TeacherPresentationLayer.Infrastracture.Functions; 

namespace TeacherPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineClassesController : Controller
    {
        private TeacherOnlineClassesService onlineClassesService;

        public OnlineClassesController()
        {
            onlineClassesService = new TeacherOnlineClassesService();
        }
        //==================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var onlineActiveClassesTask = GetOnlineActiveClassesTask(GetCurrentUserId());
                var onlineClassesTask = GetOnlineClassesTask(GetCurrentUserId());
                Task.WaitAll(onlineClassesTask, onlineActiveClassesTask);  
                ViewBag.OnlineClasses = onlineClassesTask.Result; 
                ViewBag.OnlineActiveClasses = onlineActiveClassesTask.Result ;
                return View();
            });
        }
        //==================================================================
        [HttpPost]
        public async Task<IActionResult> JoinToClass()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = onlineClassesService.JoinToClass(GetCurrentUserId(), courseMeetingId);
                return Ok(result);
            });
        }
        //================================================================== 
        public async Task<IActionResult> Delete()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int weekScheduleId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = onlineClassesService.Delete(GetCurrentUserId(), weekScheduleId);
                return Ok(result);
            });
        }
        //=================================================================================
        Task<List<TeacherOnlineClassesViewModel>> GetOnlineClassesTask(int teacherUserId)
        {
            var task = new Task<List<TeacherOnlineClassesViewModel>>(() =>
            {
                var result = onlineClassesService.Read(teacherUserId).Value;
                return result;
            });
            task.Start();
            return task;
        }
        //=================================================================================
        Task<List<TeacherOnlineClassesViewModel>> GetOnlineActiveClassesTask(int teacherUserId)
        {
            var task = new Task<List<TeacherOnlineClassesViewModel>>(() =>
            {
                var result = onlineClassesService.ReadActiveClass(teacherUserId).Value;
                return result;
            });
            task.Start();
            return task;
        } 
        //=================================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            onlineClassesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
