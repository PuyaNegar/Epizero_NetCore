using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebPresentationLayer.Infrastracture.Filters;
using WebBusinessLogicLayer.BusinessServices.FinancialsServices;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize] 
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
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.Balance = studentUserScoresService.GetBalance(CurrentContext.GetCurrentUserId(this).Value).Value.Balance;
                ViewBag.Transactions = studentUserScoresService.Read(CurrentContext.GetCurrentUserId(this).Value).Value;
                return View();
            });
        }  
        //============================================================================================== 
    }
}
