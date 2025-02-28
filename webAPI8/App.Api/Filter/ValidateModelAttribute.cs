using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using ILogger = NLog.ILogger;

namespace App.Api
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        internal ILogger inbound_logger = LogManager.GetLogger("inbound");
        internal ILogger trc_logger = LogManager.GetLogger("Trc");

        public override async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {


            if (!actionContext.ModelState.IsValid)
            {
                inbound_logger.Error($"Validate=>{actionContext.ModelState}");
                actionContext.Result = new BadRequestObjectResult("參數發生錯誤了！");
                return;
            }
            await next();

        }
    }
}