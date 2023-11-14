using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class CourseAndCourseMeetingStudentsController : Controller
    {
        private CourseAndCourseMeetingsStudentsService courseAndCourseMeetingStudentsService;
        //======================================================== 
        public CourseAndCourseMeetingStudentsController()
        {
            courseAndCourseMeetingStudentsService = new CourseAndCourseMeetingsStudentsService();
        }
        //======================================================== 
        public async Task<IActionResult> ReadCourseStudents( int Id )
        {
            return await Task.Run<IActionResult>(() =>
            { 
                var result = courseAndCourseMeetingStudentsService.ReadCourseStudentsWithoutDuplicate(courseId : Id  ) ;
                return Json(result);
            });
        } 
         //======================================================== 
        public async Task<IActionResult> ReadCourseMeetingStudents( int Id )
        {
            return await Task.Run<IActionResult>(() =>
            { 
                var result = courseAndCourseMeetingStudentsService.ReadCourseMeetingStudentsWithoutDuplicate(courseMeetingId : Id  ) ;
                return Json(result);
            });
        }
        //========================================================================= 
        public async Task<IActionResult> ReadCourseMeetingStudentsWithoutDuplicateByOnlineExamId(int Id)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var result = courseAndCourseMeetingStudentsService.ReadCourseMeetingStudentsWithoutDuplicateByOnlineExamId(onlineExamId: Id);
                return Json(result);
            });
        }
        //========================================================================= Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            courseAndCourseMeetingStudentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
