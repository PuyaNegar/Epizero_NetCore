using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.Systems;
using Common.Objects;
 
using WebPresentationLayer.Infrastracture.Filters;

namespace WebServiceLayer.Controllers
{
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class CreateSiteMapController : Controller
    {
        CreateSiteMapComponent createSiteMapComponent;
        //=================================================
        public CreateSiteMapController()
        {
            createSiteMapComponent = new CreateSiteMapComponent();
        } 
        //==============================================
        [HttpGet]
        [Route("api/CreateSiteMap")]
        public async Task<IActionResult> Operation()
        {
            return await Task.Run<IActionResult>(() =>
            {
                createSiteMapComponent.Operation();
                return Ok(new SysResult() { IsSuccess = true , Message = SystemCommonMessage.OperationDoneSuccessfully});
            });
        }

        //=============================================================================== Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            createSiteMapComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
