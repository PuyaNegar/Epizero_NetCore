using Common.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; 

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class OnlineClassesController : Controller
    {
        private OnlineClassesService onlineClassesService;

        public OnlineClassesController()
        {
            onlineClassesService = new OnlineClassesService();
        }
        //==================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var onlineActiveClassesTask = GetOnlineActiveClassesTask( );
                var onlineClassesTask = GetOnlineClassesTask( );
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
                var result = onlineClassesService.JoinToClass(courseMeetingId , GetCurrentUserId()  );
                return Ok(result);
            });
        }
        //================================================================== 
        public async Task<IActionResult> Delete()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                var result = onlineClassesService.Delete(   courseMeetingId);
                return Ok(result);
            });
        }
        //=================================================================================
        Task<List<OnlineClassesViewModel>> GetOnlineClassesTask(   )
        {
            var task = new Task<List<OnlineClassesViewModel>>(() =>
            {
                var result = onlineClassesService.Read( ).Value;
                return result;
            });
            task.Start();
            return task;
        }
        //=================================================================================
        Task<List<OnlineClassesViewModel>> GetOnlineActiveClassesTask(   )
        {
            var task = new Task<List<OnlineClassesViewModel>>(() =>
            {
                var result = onlineClassesService.ReadActiveClass( ).Value;
                return result;
            });
            task.Start();
            return task;
        } 
        //=================================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this)  ;
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
