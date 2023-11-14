using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PanelBusinessLogicLayer.BusinessServices.SystemsServices;
using System.Linq;
using System.Threading.Tasks;

namespace PanelPresentationLayer.Infrastracture.Filters
{
    public class ModelValidatorAsync : ActionFilterAttribute
    {
        //===========================================================================
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await Task.Run(() =>
           {
               if (!context.ModelState.IsValid)
               {
                   var errorMessages = string.Empty;
                   var errors = context.ModelState.Where(c => c.Value.ValidationState == ModelValidationState.Invalid).ToList();
                   foreach (var error in errors)
                       errorMessages += error.Value.Errors[0].ErrorMessage + "\n";
                   AddLogs(errorMessages, context.HttpContext.Request.Path);
                   context.Result = new OkObjectResult(new SysResult() { IsSuccess = false, Message = errorMessages });
               }
               return base.OnActionExecutionAsync(context, next);
           });
        } 
        //=============================================================================
        void AddLogs(string errorMessage, string errorSource)
        {
            using (var errorLogsService = new ErrorLogsService())
            {
                errorLogsService.Add(errorMessage, errorSource);
            }
        }
        //=============================================================================
    }
}
