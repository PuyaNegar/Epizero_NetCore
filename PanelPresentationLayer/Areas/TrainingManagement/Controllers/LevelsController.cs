using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices;
using PanelPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Areas.TrainingManagement.Controllers
{
    [Area("TrainingManagement")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class LevelsController : Controller
    {
        private LevelsService levelsService;
        //===========================================================================
        public LevelsController()
        {
            this.levelsService = new LevelsService();
        }
        //===========================================================================
        public async Task<JsonResult> ReadForComboBox(int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = levelsService.ReadForComboBox(Id);
                return Json(result);
            });
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            levelsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
