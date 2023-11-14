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
    public class StudentOnlineExamResultsController : ControllerBase
    {
        private StudentOnlineExamResultsService  studentOnlineExamResultsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public StudentOnlineExamResultsController()
        {
            studentOnlineExamResultsService = new  StudentOnlineExamResultsService();
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpGet]
        public async Task<IActionResult> Find ()
        {
            return await Task.Run<IActionResult>(() =>
            {
                int onlineExamId = Request.Query["OnlineExamId"].ToString().ToIntegerIdentifier();
                var result = studentOnlineExamResultsService.Find(onlineExamId, GetCurrentUserId());
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
            studentOnlineExamResultsService?.Dispose(); 
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
