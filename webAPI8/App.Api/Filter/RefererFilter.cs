using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace App.Api
{
    /// <summary>
    /// 黑箱-主機標頭驗證(按需加入至Controller)
    /// </summary>
    public class RefererFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            // 取得 Referer 頭部
            var referer = actionContext.HttpContext.Request.Headers["Referer"].ToString();

            // 進行驗證，例如：確保它來自合法的源
            if (string.IsNullOrWhiteSpace(referer) || !IsValidReferer(referer))
            {
                // 返回 403 Forbidden 以及一個錯誤訊息
                actionContext.Result = new ObjectResult(new
                {
                    error = "Invalid referer header.",
                    code = 403
                })
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
                return;
            }

            await next();
        }

        private bool IsValidReferer(string referer)
        {
            string? webroot = AppSettingHelper.GetSection("AppSettings:WebRoot").Value;
            if (string.IsNullOrWhiteSpace(webroot))
            {
                return false;
            }
            var uri = new Uri(webroot);
            var refererUri = new Uri(referer);
            // 進行驗證邏輯，例如比對允許的域名等
            return uri.Scheme == refererUri.Scheme && uri.Authority == refererUri.Authority;
        }
    }
}
