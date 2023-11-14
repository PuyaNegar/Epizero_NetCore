using Common.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    //[ApiVersion("1")]
    //[Permision("Student")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync(DefaultErrorMessage = "عملیات به دلیل خطا متوقف گردید")]
    public class StudentOnlineExamResultsController : Controller , IDisposable
    {
        private StudentOnlineExamResultsService studentOnlineExamResultsService;
        private OnlineExamParticipantsService onlineExamParticipantsService;

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public StudentOnlineExamResultsController()
        {
            studentOnlineExamResultsService = new StudentOnlineExamResultsService();
            onlineExamParticipantsService = new OnlineExamParticipantsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {

                int onlineExamId = Request.Query["OnlineExamId"].ToString().ToIntegerIdentifier();
                if (!string.IsNullOrEmpty(Request.Query["CourseId"]))
                {
                   ViewBag.CourseId = Request.Query["CourseId"].ToString().ToIntegerIdentifier();
                }
              
                try
                {
                    ViewBag.Data = studentOnlineExamResultsService.Find(onlineExamId, GetCurrentUserId()).Value;
                    ViewBag.OnlineExamParticipantsCount = onlineExamParticipantsService.Count(onlineExamId).Value;
                }
                catch { }
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObjects
        public void Dispose()
        {
            studentOnlineExamResultsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
