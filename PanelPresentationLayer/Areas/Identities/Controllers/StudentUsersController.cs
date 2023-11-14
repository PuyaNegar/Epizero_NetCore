using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelViewModels.BaseViewModels;
using PanelViewModels.IdentitiesViewModels;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelBusinessLogicLayer.BusinessServices.SystemsServices;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelViewModels.Identity;

namespace PanelPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentUsersController : Controller
    {
        private StudentUsersService studentUsersService;
        //===========================================================================
        public StudentUsersController()
        {
            this.studentUsersService = new StudentUsersService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var provinceTask = GetProvincesTask();
                var fieldsTask = GetFieldsTask();
                var levelsTask = GetLevelsTask();
                Task.WaitAll(fieldsTask, provinceTask);
                ViewBag.Fields = fieldsTask.Result;
                ViewBag.Levels = levelsTask.Result;
                ViewBag.Provinces = provinceTask.Result;
                return View();
            }); 
        }
        //===========================================================================
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = studentUsersService.Read();
                var result = sysResult.GetGridData<StudentUsersViewModel>(request);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<IActionResult> Add([FromBody] StudentUsersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = studentUsersService.Add(viewModel);
                return Json(sysResult);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUsersService.Find(viewModel.Id.Value);
                return Json(result);
            });
        } 
        //********************************************************************
        [HttpPost]
        public async Task<JsonResult> GetActiveStatus([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUsersService.GetActiveStatus(viewModel.Id.Value);
                return Json(result);
            });

        }
        //********************************************************************
        [HttpPost]
        public async Task<JsonResult> ChangeActiveStatus([FromBody] UserStatusViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUsersService.ChangeActiveStatus(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentUsersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUsersService.Update(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]

        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUsersService.ChangePassword(viewModel);
                return Json(result);
            });
        }
        //==========================================================================
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentUsersService.Delete(viewModel);
                return Json(result);
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
                using (var levelService = new LevelsService())
                {
                    return levelService.ReadForComboBox().Value;
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
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> GetSiteLoginToken([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUsersService.GetSiteLoginToken(viewModel.Id.Value);
                return Json(result);
            });
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
            studentUsersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
