using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using WebBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebBusinessLogicLayer.BusinessServices.TrainingsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class UserProfilesController : Controller
    {
        private UserProfilesService userProfilesService;
        //===========================================================================
        public UserProfilesController()
        {
            userProfilesService = new UserProfilesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var provinceTask = GetProvincesTask();
                var fieldsTask = GetFieldsTask();
                var levelsTask = GetLevelsTask();
                Task.WaitAll(fieldsTask, provinceTask, levelsTask);
                ViewBag.Fields = fieldsTask.Result;
                ViewBag.Provinces = provinceTask.Result;
                ViewBag.Levels = levelsTask.Result;
                return View();
            });
        }
        //======================================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> ReadProfiles()
        {
            using (var userProfilesService = new UserProfilesService())
            {
                return await Task.Run<IActionResult>(() =>
                {
                    var result = userProfilesService.Find(GetCurrentUserId().Value);
                    return Json(result);
                });
            }
        }
        //=============================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentUserProfileViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = userProfilesService.Update(viewModel, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //=============================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> UpdateField([FromBody] SelectedFeildViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = userProfilesService.UpdateField(viewModel, GetCurrentUserId().Value);
                return Ok(result);
            });
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetFieldsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var fieldService = new FieldsService())
                {
                    return fieldService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetLevelsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var levelsService = new LevelsService())
                {
                    return levelsService.ReadForComboBox().Value;
                };
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetProvincesTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var provinceServices = new ProvincesServices())
                {
                    return provinceServices.ReadForComboBox().Value;
                }
            });
            task.Start();
            return task;
        }

        //======================================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            userProfilesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
