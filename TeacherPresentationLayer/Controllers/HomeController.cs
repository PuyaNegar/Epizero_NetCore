using System.Threading.Tasks;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using TeacherPresentationLayer.Infrastracture.Functions;

namespace TeacherPresentationLayer.Controllers
{ 
    public class HomeController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {  
                using (var courseStudentsReportsService = new CourseStudentsReportsService(GetCurrentUserId().Value))
                {
                    ViewBag.CitiesReport = courseStudentsReportsService.GetCities().Value;
                    ViewBag.FieldsReport = courseStudentsReportsService.GetFields().Value;
                    ViewBag.GendersReport = courseStudentsReportsService.GetGenders().Value;
                    ViewBag.LevelsReport = courseStudentsReportsService.GetLevels().Value;
                }
                return View();
            });
        }
        //=================================================
        public IActionResult KeepAlive()
        {
            return Ok(new SysResult() { IsSuccess = true });
        }
        //============================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
    }
}
