using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.BusinessServices.TrainingManagementServices;
using Common.Enums;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.OnlineExamsViewModels;
using PanelViewModels.OnlineExamViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class DescriptiveQuestionsController : Controller
    {
        private DescriptiveQuestionsService descriptiveQuestionsService;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public DescriptiveQuestionsController()
        {
            this.descriptiveQuestionsService = new DescriptiveQuestionsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                ViewBag.FilterdLessonId = Id;
                return View();
            });
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> QuestionDesignPage(int? Id)
        {
            return await Task.Run<IActionResult>(() =>
            { 
                if (Id == null)
                {
                    ViewBag.QuestionDesignType = QuestionDesignType.Create;  
                    return View();
                }
                else
                {
                    ViewBag.QuestionDesignType = QuestionDesignType.Edit;
                    var result = descriptiveQuestionsService.Find(Id.Value /*, GetCurrentUserId()*/).Value;
                    ViewBag.Data = result;
                    return View();
                }
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read([FromForm] DataTableRequest request)
        {
            return await Task.Run<IActionResult>(() =>
            {
                dynamic data = request.Filters.ToFilterExpression();
                int lessonId = Convert.ToInt32(data.LessonId);
                var sysResult = descriptiveQuestionsService.Read(lessonId);
                var result = sysResult.GetGridData<DescriptiveQuestionsViewModel>  (request); 
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DescriptiveQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = descriptiveQuestionsService.Add(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Find([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = descriptiveQuestionsService.Find(viewModel.Id.Value /*, GetCurrentUserId()*/);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] DescriptiveQuestionsViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = descriptiveQuestionsService.Update(viewModel, GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] IntegerIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = descriptiveQuestionsService.Delete(viewModel.Id.Value /*, GetCurrentUserId()*/);
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        [HttpPost]
        public async Task<IActionResult> GetLessonTopics(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var lessontopicsService = new LessonTopicsService())
                {
                    var result = lessontopicsService.ReadForComboBox(Id);
                    return Json(result);
                }
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
            descriptiveQuestionsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
