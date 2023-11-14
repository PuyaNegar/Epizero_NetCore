using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices; 
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;

namespace PanelPresentationLayer.Areas.BasicDefinitions.Controllers
{
    [Area("BasicDefinitions")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync] 
    [ExceptionHandlerAsync]
    public class CitiesController : Controller
    {
        private CitiesService citiesService;
        //===========================================================================
        public CitiesController()
        {
            this.citiesService = new CitiesService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var provinceServices = new ProvincesServices())
                {
                    ViewBag.Provinces = provinceServices.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                dynamic filter = request.Filters.ToFilterExpression();
                int provinceId = filter.ProvinceId == null ? 0 : filter.ProvinceId;
                var sysResult = citiesService.ReadByProvince(provinceId);
                var result = sysResult.GetGridData<CitiesViewModel>(request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] CitiesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody]  CitiesViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        public async Task<JsonResult> ReadForComboBox(int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.ReadForComboBox(Id);
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            citiesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
