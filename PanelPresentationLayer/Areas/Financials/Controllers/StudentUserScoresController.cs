using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions; 
using System.Threading.Tasks;
using WebDTOModels.IdentitiesDTOModels;
using Common.Extentions;
using Common.Objects;
using PanelViewModels.FinancialsViewModels;
using System;

namespace WebServicePresentationLayer.Areas.Identities.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentUserScoresController : Controller
    {
        private StudentUserScoresService studentUserScoresService;
        //============================================================================
        public StudentUserScoresController()
        {
            studentUserScoresService = new StudentUserScoresService();
        }
   
        //=============================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                return View();
            });
        } 
        //===========================================================================
        [HttpPost]
        public async Task<JsonResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<JsonResult>(() =>
            {
                dynamic requestData = request.Filters.ToFilterExpression();
                string TelNo = Convert.ToString(requestData["UserTelNo"]);
                var sysResult = studentUserScoresService.Read(TelNo);
                var result = sysResult.GetGridData<StudentUserScoresViewModel>
                    (request);
                return Json(result);
            });
        }


        //=======================================================
        [HttpPost]
        public async Task<JsonResult> GetBalance(string Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserScoresService.GetBalance(Id);
                return Json(result);
            });
        }
        //========================================================
        [HttpPost]
        public async Task<JsonResult> ChangeCredit([FromBody] ChangeScoreViewModel viewModel)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = studentUserScoresService.ChangeCredit(viewModel, GetCurrentUserId());
                return Json(result);
            });
        } 
        //==============================================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
    }
}
