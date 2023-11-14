using Common.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ApiVersion("1")]
    //[Permision("Student")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync(DefaultErrorMessage = "عملیات به دلیل خطا متوقف گردید")]
    public class StudentOnlineExamsController : ControllerBase
    {
        private StudentOnlineExamsService studentOnlineExamsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public StudentOnlineExamsController()
        {
            this.studentOnlineExamsService = new StudentOnlineExamsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentOnlineExamsService.Read(GetCurrentUserId());
                return Ok(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpPost]
        public async Task<IActionResult> Finalize()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int onlineExamId = Request.Query["OnlineExamId"].ToString().ToIntegerIdentifier();
                var result = studentOnlineExamsService.Finalize(onlineExamId, GetCurrentUserId());
                return Ok(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpGet]
        public async Task<IActionResult> GetRemainingTime()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int onlineExamId = Request.Query["OnlineExamId"].ToString().ToIntegerIdentifier();
                var result = studentOnlineExamsService.GetRemainingTime(onlineExamId, GetCurrentUserId());
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
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            studentOnlineExamsService?.Dispose();
        }
        #endregion
    }
}
