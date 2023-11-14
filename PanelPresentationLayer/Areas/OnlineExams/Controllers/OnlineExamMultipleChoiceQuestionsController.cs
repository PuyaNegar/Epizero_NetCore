using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamMultipleChoiceQuestionsController : Controller
    {
        private OnlineExamMultipleChoiceQuestionsService multipleChoiceQuestionsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamMultipleChoiceQuestionsController()
        {
            this.multipleChoiceQuestionsService = new OnlineExamMultipleChoiceQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult QuestionEditPage(int Id)
        {
            var result = multipleChoiceQuestionsService.Find(Id/*, GetCurrentUserId()*/).Value;
            ViewBag.Data = result;
            return View();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public IActionResult Update([FromBody] OnlineExamMultipleChoiceQuestionsViewModel viewModel)
        {
            var result = multipleChoiceQuestionsService.Update(viewModel, GetCurrentUserId());
            return Json(result);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
 
        public IActionResult ReturnToOnlineExam(int Id)
        {
            using (var component = new OnlineExamMultipleChoiceQuestionsComponent())
            {
                var result = component.GetParentOnlineExamId(Id);
                return Redirect("/OnlineExams/OnlineExamQuestions/Index/" + result);
            }
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
            multipleChoiceQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
