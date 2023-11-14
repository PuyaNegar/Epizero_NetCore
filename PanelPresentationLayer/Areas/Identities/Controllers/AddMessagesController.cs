using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{

    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class AddMessagesController : Controller
    {

        private MessagesService messagesService;
        //===========================================================================
        public AddMessagesController()
        {
            this.messagesService = new MessagesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var coursesTask = GetCoursesTask();
                var receiverUsersTask = GetReceiverUsersTask();
                var tagsTask = GetTagsTask();
                Task.WaitAll(coursesTask, receiverUsersTask , tagsTask);
                ViewBag.Courses = coursesTask.Result;
                ViewBag.ReceiverUsers = receiverUsersTask.Result;
                ViewBag.Tags = tagsTask.Result;
                return View();
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MessagesViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = messagesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = messagesService.Delete(viewModel);
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
        Task<List<ComboBoxItems>> GetReceiverUsersTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var studentUsersService = new StudentUsersService())
                {
                    return studentUsersService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetTagsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var tagsService = new TagsService())
                {
                    return tagsService.ReadForComboBox().Value;
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
            messagesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
