using System; 
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.OnlineExamViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class OnlineExamStudentManualAnswersController : Controller
    {
        private OnlineExamStudentManualAnswersService onlineExamStudentManualAnswersService; 
        public OnlineExamStudentManualAnswersController()
        {
            this.onlineExamStudentManualAnswersService = new OnlineExamStudentManualAnswersService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Index(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var onlineExamStudentService  = new OnlineExamStudentsService())
                {
                    var onlineExamStudentsModel = onlineExamStudentService.Find(Id).Value;
                    ViewBag.StudentFullName = onlineExamStudentsModel.StudentFullName;
                }
                ViewBag.onlineExamStudentId = Id;
                ViewBag.Questions = onlineExamStudentManualAnswersService.Read(Id, GetCurrentUserId()).Value;
                return View();
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Read(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentManualAnswersService.Read(Id , GetCurrentUserId());
                return Json(result);
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Add([FromBody] OnlineExamStudentManualAnswersViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = onlineExamStudentManualAnswersService.Add(viewModel.OnlineExamStudentId, viewModel.OnlineExamStudentManualAnswerSelectedOptions, GetCurrentUserId());
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
            onlineExamStudentManualAnswersService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
