using System; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices;
using PanelPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    [Authorize]
    [ModelValidatorAsync]
  //  [TeacherPermision]
    [ExceptionHandlerAsync]
    public class StudentOnlineExamBatchFinalizeController : Controller
    {
       private StudentOnlineExamBatchFinalizeService studentOnlineExamBatchFinalizeServicce;
        //=======================================================
        public StudentOnlineExamBatchFinalizeController()
        {
            this.studentOnlineExamBatchFinalizeServicce = new StudentOnlineExamBatchFinalizeService();
        }
        //=======================================================
        public IActionResult Operation(int Id)
        {
            var result = studentOnlineExamBatchFinalizeServicce.Operation(Id);
            return Json(result);
        }
        //=======================================================
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentOnlineExamBatchFinalizeServicce?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //=======================================================
    }
}
