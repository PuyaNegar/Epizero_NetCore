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
    public class StudentOnlineExamQuestionsController : ControllerBase
    {
        private StudentOnlineExamQuestionsService studentOnlineExamQuestionsService;
        public StudentOnlineExamQuestionsController()
        {
            this.studentOnlineExamQuestionsService = new StudentOnlineExamQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return await Task.Run<IActionResult>(() =>
            { 
                int OnlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                var result = studentOnlineExamQuestionsService.Read(OnlineExamId, GetCurrentUserId());
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
            studentOnlineExamQuestionsService?.Dispose();
        }
        #endregion
    }
}
