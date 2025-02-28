using Jose;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace App.Api
{
    public class AuthorizationFilter : ActionFilterAttribute
    {
        public string Permission { get; set; }
        public bool AccessLog { get; set; } = false;

        public int EnumFunctionId { get; set; }


        public AuthorizationFilter(Functions enumFunction = Functions.none)
        {
            EnumFunctionId = (int)enumFunction;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            var secret = AppSettingHelper.GetSection("TokenSecret").Value; //加密字串

            string Authorization = actionContext.HttpContext.Request.Headers["Authorization"];

            if (Authorization != null && Authorization.StartsWith("Bearer"))
            {
                try
                {
                    //get service

                    //get client ip 
                    var iP = IpHelper.GetClinetIPAddress(actionContext.HttpContext);

                    var jwtToken = Authorization.Substring("Bearer ".Length).Trim();
                    IDictionary<string, object> headers = JWT.Headers(jwtToken);

                    string alg = (string)headers["alg"];
                    if (alg != JwsAlgorithm.HS512.ToString())
                    {
                        actionContext.Result = new UnauthorizedResult();
                        return;
                    }
                    var jwtObject = JWT.Decode<JWTPayload>(
                        jwtToken,
                        Encoding.UTF8.GetBytes(secret),
                        JwsAlgorithm.HS512);

                    // TODO 驗證是否存在
                    //var taskCheckJWTLive = _service.CheckJWTLive(jwtObject.UserId, jwtToken);
                    //taskCheckJWTLive.Wait();
                    var isLive = true;

                    if (isLive)
                    {

                    }
                    else // 過期
                    {
                        actionContext.Result = new UnauthorizedResult();
                    }
                }
                catch (Exception ex)
                {
                    actionContext.Result = new UnauthorizedResult();
                }
            }
            else
            {
                actionContext.Result = new UnauthorizedResult();
            }

            base.OnActionExecuting(actionContext);
        }
    }


    public class CustomForbiddenResult : JsonResult
    {
        public CustomForbiddenResult(string message)
            : base(new CustomError(message))
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }

    public class CustomError
    {
        public string Error { get; }

        public CustomError(string message)
        {
            Error = message;
        }
    }



}
