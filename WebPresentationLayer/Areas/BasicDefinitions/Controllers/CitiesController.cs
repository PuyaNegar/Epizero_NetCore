using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extentions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using WebPresentationLayer.Infrastracture.Filters;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("BasicDefinitions")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CitiesController : Controller
    {
        private CitiesService citiesService;
        //===========================================================================
        public CitiesController()
        {
            this.citiesService = new CitiesService();
        }
        //===========================================================================
        public async Task<JsonResult> ReadForComboBox(int Id)
        {
            return await Task.Run<JsonResult>(() =>
            {
                var result = citiesService.ReadForComboBox(Id);
                return Json(result);
            });
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return Convert.ToInt32(User.Claims.ToList()[1].Value);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            citiesService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
