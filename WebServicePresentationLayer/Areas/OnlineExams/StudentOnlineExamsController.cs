using Common.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebServicePresentationLayer.Infrastracture.Filters;
using WebServicePresentationLayer.Infrastracture.Functions;
using WebServicePresentationLayer.Infrastrcture.Filters;

namespace WebServicePresentationLayer.Areas.OnlineExams
{
    [Area("OnlineExams")]
    [Authorize]
    [ApiVersion("1")]
    [Permision("Student")]
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
            return CurrentContext.GetCurrentUserId(this);
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
