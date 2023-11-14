using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.ContentsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
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
    public class ContactUsController : Controller
    {
        private ContactUsService contactUsService;
        //===========================================================================
        public ContactUsController()
        {
            this.contactUsService = new ContactUsService();
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
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var sysResult = contactUsService.Read();
                var result = sysResult.GetGridData<ContactUsViewModel>
                    (request);
                return Json(result);
            });

        }
        //=========================================================================== 
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = contactUsService.Find(viewModel.Id.Value);
                return Json(result);
            });
        }
        //=========================================================================== 
        public async Task<IActionResult> Update([FromBody] ContactUsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = contactUsService.Update(viewModel);
                return Json(result);
            });
        }

        //=========================================================================== 
        public async Task<IActionResult> Delete([FromBody] List<IntegerIdentifierViewModel> viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = contactUsService.Delete(viewModel);
                return Json(result);
            });
        }
        //===========================================================================
        [HttpPost]
        public async Task<IActionResult> SendSms([FromBody] StudentCustomSmsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = contactUsService.SendSms(viewModel);
                return Json(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            contactUsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
