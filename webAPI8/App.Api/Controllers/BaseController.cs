namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {

        protected JWTPayload JWTPayload => HttpContext.Items["jwtPayload"] as JWTPayload ?? new JWTPayload();
        private string? trace_id = string.Empty;//Log TraceID



    }
}
