using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.OnlineExamsViewModels;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
    //[TeacherPermision]
    [ExceptionHandlerAsync]
    public class StudentOnlineExamResultsController : Controller, IDisposable
    {
        private StudentOnlineExamResultsService studentOnlineExamResultsService;
        public StudentOnlineExamResultsController()
        {
            this.studentOnlineExamResultsService = new StudentOnlineExamResultsService();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult ShowResultPage(int Id)
        {
            using (var onlineExamStudentsService = new OnlineExamStudentsService())
            {
                var result = onlineExamStudentsService.Find(Id).Value;
                ViewBag.StartDateTimeOnlineExam = result.StartDateTimeOnlineExam;
                ViewBag.StudentFullName = result.StudentFullName;
                ViewBag.OnlineExamName = result.OnlineExamName;
                ViewBag.TotalRank = result.TotalRank;
            }
            ViewBag.onlineExamStudentId = Id;
            return View();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IActionResult ShowAllResultPage(int Id)
        {
            ViewBag.AllResult = studentOnlineExamResultsService.Read(Id).Value;
            return View();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public async Task<IActionResult> Find([FromForm] DataTableRequest request, int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = studentOnlineExamResultsService.Find(Id).GetGridData<StudentOnlineExamResultsViewModel>(request);
                return Json(result);
            });
        }
        //====================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentOnlineExamResultsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
