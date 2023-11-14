using Common.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks; 
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ApiVersion("1")]
    //[Permision("Student")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync(DefaultErrorMessage = "عملیات به دلیل خطا متوقف گردید")]
    public class StudentOnlineExamValidationsController : ControllerBase
    {
        private StudentOnlineExamValidationsService studentOnlineExamValidationsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public StudentOnlineExamValidationsController()
        {
            studentOnlineExamValidationsService = new  StudentOnlineExamValidationsService();
        }  
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpPost]
        public async Task<IActionResult> Operation()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int onlineExamId = Request.Query["OnlineExamId"].ToString().ToIntegerIdentifier();
                var result = studentOnlineExamValidationsService.Operation(onlineExamId, GetCurrentUserId());
                return Ok(result);
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
            studentOnlineExamValidationsService?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
