using System;
using System.Threading.Tasks; 
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.OnlineExamsViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class QuestionsController : Controller
    {
        private QuestionsService questionsService;
        public QuestionsController()
        {
            this.questionsService = new QuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                int LessonId = Convert.ToInt32(data.LessonId);
                //var questionType = (QuestionType) data.QuestionType;
                //var isSelectAllTeacherQuestion = (ActiveStatus) Convert.ToInt32(data.IsSelectAllTeacherQuestion);
                var  result = questionsService.Read(LessonId , QuestionType.MultipleChoiceQuestions,  ActiveStatus.Deactive , GetCurrentUserId()).GetGridData<QuestionsViewModel>(request); ;
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            questionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
