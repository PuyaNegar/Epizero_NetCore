using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters; 
namespace WebServicePresentationLayer.Infrastrcture.Filters
{
    public class ApiVersion : ActionFilterAttribute
    {
        private string  version { get; set; }
        //======================================================================================================================
        public ApiVersion(string _version)
        {
            this.version = _version;
        }
        //======================================================================================================================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.RouteData.Values["version"].ToString() != this.version)
            {
                context.Result = new NotFoundResult();
            }
        }
        //======================================================================================================================
    }
}
