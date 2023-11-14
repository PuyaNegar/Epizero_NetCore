using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebServicePresentationLayer.Infrastracture.Filters;
using WebServicePresentationLayer.Infrastracture.Functions;
using WebServicePresentationLayer.Infrastrcture.Filters;
using WebViewModels.OnlineExamsViewModels;

namespace WebServicePresentationLayer.Areas.OnlineExams
{
    [Area("OnlineExams")]
    [Authorize]
    [ApiVersion("1")]
    [Permision("Student")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync(DefaultErrorMessage = "عملیات به دلیل خطا متوقف گردید")]
    public class StudentDescriptiveAnswersController : ControllerBase
    {
        private StudentDescriptiveAnswersService onlineExamStudentAnswersService;
        public StudentDescriptiveAnswersController()
        {
            this.onlineExamStudentAnswersService = new StudentDescriptiveAnswersService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] StudentDescriptiveAnswersViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentAnswersService.AddOrUpdate(request.AnswerContext,request.OnlineExamQuestionId , request.OnlineExamId, GetCurrentUserId());
                return Ok(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= -=
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
            onlineExamStudentAnswersService?.Dispose();
        }
        #endregion
    }
}
