using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.OnlineExamsViewModels;
using WebViewModels.TrainingsViewModels;


namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    [Authorize]
    public class OnlineExamsController : Controller
    {
        private StudentIndependentOnlineExamService studentIndependentOnlineExamService;
        //======================================================
        public OnlineExamsController()
        {
            studentIndependentOnlineExamService = new StudentIndependentOnlineExamService();
        }
        //======================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
             {
                 ViewBag.UserId = GetCurrentUserId();
                 var studentIndependentOnlineExamTask = GetStudentIndependentOnlineExamTask(CurrentContext.GetCurrentUserId(this).Value);
                 var studentDependentOnlineExamTask = GetStudentDependentOnlineExamTask(CurrentContext.GetCurrentUserId(this).Value);
                 Task.WaitAll(studentDependentOnlineExamTask, studentIndependentOnlineExamTask);
                 ViewBag.IndependentOnlineExam = studentIndependentOnlineExamTask.Result;
                 ViewBag.DependentOnlineExam = studentDependentOnlineExamTask.Result;
                 return View();
             });
        }
        //======================================================
        Task<List<StudentCoursesViewModel>> GetStudentIndependentOnlineExamTask(int studentUserId)
        {
            var task = new Task<List<StudentCoursesViewModel>>(() =>
            {
                using (var studentIndependentOnlineExamService = new StudentIndependentOnlineExamService())
                {
                    var result = studentIndependentOnlineExamService.Read(studentUserId).Value;
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //======================================================
        Task<List<StudentOnlineExamViewModel>> GetStudentDependentOnlineExamTask(int studentUserId)
        {
            var task = new Task<List<StudentOnlineExamViewModel>>(() =>
            {
                using (var studentDependentOnlineExamService = new StudentDependentOnlineExamService())
                {
                    var result = studentDependentOnlineExamService.Read(studentUserId).Value;
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentIndependentOnlineExamService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
