using Microsoft.AspNetCore.Mvc.Filters;

namespace App.Api
{
    public class GlobalExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(
             ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            ContentResult result = new ContentResult
            {
                StatusCode = 500,
                ContentType = "text/json;charset=utf-8;"
            };

            _logger.LogError($"錯誤訊息:{context.Exception.Message} {Environment.NewLine} StackTrace: {context.Exception.StackTrace}");
            result.Content = "系統發生錯誤了!"; //context.Exception.Message;

            context.Result = result;
            context.ExceptionHandled = true;
        }

    }
}
