using App.BLL.Employee;
using App.Model.Northwind.Models;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _service;
        private readonly IHttpContextAccessor _accessor;

        public EmployeeController(IEmployee service, IHttpContextAccessor accessor)
        {
            _service = service;
            _accessor = accessor;
        }

        /// <summary>
        /// 取得員工資料
        /// </summary>
        /// <param name="args">查詢參數</param>
        /// <returns>單筆員工資料回應</returns>
        [Route("GetData")]
        [HttpPost]
        public async Task<ResponseBase<EmployeeGetDataResponse>> GetData([FromBody] EmployeeGetDataArgs args)
        {
            return await _service.GetData(args);
        }

        /// <summary>
        /// 取得員工列表
        /// </summary>
        /// <param name="args">列表查詢參數</param>
        /// <returns>員工列表回應</returns>
        [Route("GetList")]
        [HttpPost]
        public async Task<ResponseBase<List<EmployeeGetListResponse>>> GetList([FromBody] EmployeeGetListArgs args)
        {
            var jwtPayload = GetJWTPayload(); // 假設有一個方法從 HttpContext 獲取 JWT
            return await _service.GetList(args, jwtPayload);
        }

        /// <summary>
        /// 儲存員工資料
        /// </summary>
        /// <param name="args">儲存參數</param>
        /// <returns>儲存操作回應</returns>
        [Route("SaveData")]
        [HttpPost]
        public async Task<ResponseBase<EmployeeSaveDataResponse>> SaveData([FromBody] EmployeeSaveDataArgs args)
        {
            var jwtPayload = GetJWTPayload(); // 假設有一個方法從 HttpContext 獲取 JWT
            return await _service.SaveData(args, jwtPayload);
        }

        /// <summary>
        /// 移除員工資料
        /// </summary>
        /// <param name="args">移除參數</param>
        /// <returns>移除操作回應</returns>
        [Route("RemoveData")]
        [HttpPost]
        public async Task<ResponseBase<EmployeeRemoveDataResponse>> RemoveData([FromBody] EmployeeRemoveDataArgs args)
        {
            var jwtPayload = GetJWTPayload(); // 假設有一個方法從 HttpContext 獲取 JWT
            return await _service.RemoveData(args, jwtPayload);
        }

        // 輔助方法：從 HttpContext 獲取 JWT Payload（示例實現）
        private JWTPayload GetJWTPayload()
        {
            // 這裡應該實現從 HttpContext 解析 JWT 的邏輯
            // 以下是簡單示例，您需要根據實際 JWT 實現調整
            var userId = _accessor.HttpContext?.User?.FindFirst("sub")?.Value;
            var userName = _accessor.HttpContext?.User?.FindFirst("name")?.Value;
            var exp = long.Parse(_accessor.HttpContext?.User?.FindFirst("exp")?.Value ?? "0");

            return new JWTPayload
            {
                UserId = userId,
                UserName = userName,
                Exp = exp
            };
        }
    }
}
