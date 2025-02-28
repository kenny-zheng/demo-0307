using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;

namespace App.Api
{
    /// <summary>
    /// 黑箱-大量指派
    /// </summary>
    public class ValidateJsonPropertiesFilter : ActionFilterAttribute
    {
        public ValidateJsonPropertiesFilter()
        {

        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var bodyAsText = string.Empty;
            if (context.HttpContext.Items.TryGetValue("RequestBody", out var requestBody) && requestBody is string bodyText)
            {
                bodyAsText = bodyText;
            }

            if (!string.IsNullOrEmpty(bodyAsText))
            {
                var jsonInput = JObject.Parse(bodyAsText);
                if (jsonInput != null)
                {
                    // 取得目標方法的參數型別
                    var modelType = context.ActionDescriptor.Parameters[0].ParameterType;

                    // 從型別中取得所有的屬性
                    var expectedProperties = modelType.GetProperties().Select(p => p.Name).ToHashSet();

                    // 從JSON輸入中取得所有的屬性名稱
                    var propertiesInJson = jsonInput.Properties().Select(p => p.Name).ToHashSet();

                    // 檢查是否所有的JSON屬性都在期待的屬性列表中
                    if (!propertiesInJson.All(p => expectedProperties.Any(y => string.Equals(p, y, StringComparison.OrdinalIgnoreCase))))
                    {
                        context.Result = new StatusCodeResult(500); // 設定500錯誤
                        return;
                    }
                }
            }
            await next();  // 繼續執行後續的過濾器和動作方法
        }
    }
}