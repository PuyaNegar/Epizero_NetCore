using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelPresentationLayer.Infrastracture.Filters;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class LessonsController : Controller
    {
        private LessonsService lessonsService;
        //===========================================================================
        public LessonsController()
        {
            this.lessonsService = new LessonsService();
        }
        //===========================================================================
        [AdminPermision]
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var levelGroupsTask = GetLevelGroupsTask();
                var fieldsTask = GetFieldsTask();
                Task.WaitAll(levelGroupsTask , fieldsTask);
                ViewBag.LevelGroups = levelGroupsTask.Result;
                ViewBag.Fields = fieldsTask.Result;
                return View();
            });

        }
        //===========================================================================
        [AdminPermision]
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                int fieldId = Convert.ToInt32(data.FieldId);
                int levelId = Convert.ToInt32(data.LevelId);
                var result = lessonsService.Read(levelId, fieldId).GetGridData<LessonsViewModel>(request);
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        [AdminPermision]
        public async Task<IActionResult> Add([FromBody] LessonsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        [AdminPermision]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        [AdminPermision]
        public async Task<IActionResult> Update([FromBody]  LessonsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        [AdminPermision]
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonsService.Delete(viewModel);
                return Json(result);
            });

        }
        //============================================================================
        public async Task<IActionResult> ReadForComboBox(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = lessonsService.ReadForComboBox(Id , null);
                return Json(result);
            });
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetLevelGroupsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var countiesServices = new LevelGroupsService())
                {
                    return countiesServices.ReadForComboBox().Value;
                }
            });
            task.Start();
            return task;
        }
        //===========================================================================
        Task<List<ComboBoxItems>> GetFieldsTask()
        {
            var task = new Task<List<ComboBoxItems>>(() =>
            {
                using (var repository = new FieldsService())
                {
                    return repository.ReadForComboBox().Value;
                }
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
            lessonsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
