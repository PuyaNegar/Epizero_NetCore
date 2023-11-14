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
    public class StudentMultipleChoiceAnswersController : ControllerBase
    {
        private StudentMultipleChoiceAnswersService studentMultipleChoiceAnswersService;
        public StudentMultipleChoiceAnswersController()
        {
            this.studentMultipleChoiceAnswersService = new StudentMultipleChoiceAnswersService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpPost]
        public async Task<IActionResult> AddOrUpdate([FromBody] StudentMultipeChoiceAnswerViewModel request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentMultipleChoiceAnswersService.AddOrUpdate(request.SelectedOption, request.OnlineExamQuestionId, request.OnlineExamId, GetCurrentUserId());
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
            studentMultipleChoiceAnswersService?.Dispose();
        }
        #endregion
    }
}
