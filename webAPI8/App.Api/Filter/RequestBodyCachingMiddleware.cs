namespace App.Api
{
    public class RequestBodyCachingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestBodyCachingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await ReadRequestBodyAsync(context);
            await _next(context);
        }

        private async Task<string> ReadRequestBodyAsync(HttpContext context)
        {
            string bodyAsText = string.Empty;
            if (context.Items.TryGetValue("RequestBody", out var requestBody) && requestBody is string bodyText)
            {
                return bodyText;
            }
            if (context.Request.Body != null && context.Request.Body.CanSeek && context.Request.Body.Length > 0)
            {
                context.Request.Body.Seek(0, SeekOrigin.Begin);
                using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
                bodyAsText = await reader.ReadToEndAsync() ?? string.Empty;
                context.Request.Body.Seek(0, SeekOrigin.Begin);
            }
            context.Items["RequestBody"] = bodyAsText;

            return bodyAsText;
        }
    }

}
