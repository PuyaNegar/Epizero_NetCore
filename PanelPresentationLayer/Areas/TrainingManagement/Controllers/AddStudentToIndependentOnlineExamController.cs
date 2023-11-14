using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [ModelValidatorAsync]
    [AdminPermision]
    [ExceptionHandlerAsync]
    public class AddStudentToIndependentOnlineExamController : Controller
    {
        AddStudentToIndependentOnlineExamService addStudentToIndependentOnlineExamService;

        public AddStudentToIndependentOnlineExamController()
        {
            addStudentToIndependentOnlineExamService = new AddStudentToIndependentOnlineExamService();
        }

        //============================================================================
        [HttpPost]
        public IActionResult Operation([FromBody] AddStudentToIndependentOnlineExamViewModel viewModel)
        {
            var result = addStudentToIndependentOnlineExamService.Operation( viewModel.StudentUserIds,viewModel.OnlineExamId);
            return Json(result);
        }
        //===========================================================  Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            addStudentToIndependentOnlineExamService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
