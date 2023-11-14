using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.OnlineExamsViewModels;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class OnlineExamQuestionsController : Controller
    {
        //=====================================================
        public async Task< IActionResult >  Index()
        { 
            return await Task.Run<IActionResult>(() =>
            {
                var onlineExamId = Convert.ToInt32(Request.Query["OnlineExamId"]);
                var onlineExamQuestionsTask = ReadOnlineExamQuestionsTask(onlineExamId);
                var studentMultipleChoiceAnswersTask = ReadStudentMultipleChoiceAnswersTask(onlineExamId);
                Task.WaitAll(studentMultipleChoiceAnswersTask, onlineExamQuestionsTask);
                ViewBag.StudentOnlineExamAnswers = studentMultipleChoiceAnswersTask.Result;
                ViewBag.OnlineExamQuestions = onlineExamQuestionsTask.Result;
                return View();
            }); 
        }
        //===================================================
        private Task<List<OnlineExamQuestionsViewModel>> ReadOnlineExamQuestionsTask(int onlineExamId)
        {
            var task = new Task<List<OnlineExamQuestionsViewModel>>(() =>
            {
                using (var onlineExamQuestionsService = new OnlineExamQuestionsService())
                {
                    var result = onlineExamQuestionsService.Read(onlineExamId).Value;
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===================================================
        private Task<List<StudentMultipeChoiceAnswerViewModel>> ReadStudentMultipleChoiceAnswersTask(int onlineExamId)
        {
            var task = new Task<List<StudentMultipeChoiceAnswerViewModel>>(() =>
            {
                using (var studentMultipleChoiceAnswersService = new StudentMultipleChoiceAnswersService())
                {
                    var result = studentMultipleChoiceAnswersService.Read(onlineExamId, CurrentContext.GetCurrentUserId(this).Value).Value;
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //=================================================== 
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
