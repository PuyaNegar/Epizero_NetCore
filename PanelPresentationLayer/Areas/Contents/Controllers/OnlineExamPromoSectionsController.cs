﻿using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [Authorize] 
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamPromoSectionsController : Controller
    {
        private OnlineExamPromoSectionsService OnlineExamPromoSectionGroupsService;
        //===========================================================================
        public OnlineExamPromoSectionsController()
        {
            this.OnlineExamPromoSectionGroupsService = new OnlineExamPromoSectionsService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });

        }
        //===========================================================================
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var sysResult = OnlineExamPromoSectionGroupsService.Read();
                var result = sysResult.GetGridData<OnlineExamPromoSectionsViewModel>
                    (request);
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Create([FromBody] OnlineExamPromoSectionsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionGroupsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //============================================================================
        [HttpPost]
        public async Task<JsonResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionGroupsService.Find(viewModel.Id.Value);
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Update([FromBody] OnlineExamPromoSectionsViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionGroupsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });

        }
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = OnlineExamPromoSectionGroupsService.Delete(viewModel);
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
            OnlineExamPromoSectionGroupsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
