using App.BLL.Employee;
using App.Model.Northwind.Models;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
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
        [Route(nameof(GetEmployeeData))]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<EmployeeGetDataResponse>> GetEmployeeData([FromBody] EmployeeGetDataArgs args)
        {
            return await _service.GetData(args);
        }

        /// <summary>
        /// 取得員工列表
        /// </summary>
        /// <param name="args">列表查詢參數</param>
        /// <returns>員工列表回應</returns>
        [Route(nameof(GetEmployeeList))]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<List<EmployeeGetListResponse>>> GetEmployeeList([FromBody] EmployeeGetListArgs args)
        {
            return await _service.GetList(args, base.JWTPayload);
        }

        /// <summary>
        /// 儲存員工資料
        /// </summary>
        /// <param name="args">儲存參數</param>
        /// <returns>儲存操作回應</returns>
        [Route(nameof(SaveEmployeeData))]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<EmployeeSaveDataResponse>> SaveEmployeeData([FromBody] EmployeeSaveDataArgs args)
        {
            return await _service.SaveData(args, base.JWTPayload);
        }

        /// <summary>
        /// 移除員工資料
        /// </summary>
        /// <param name="args">移除參數</param>
        /// <returns>移除操作回應</returns>
        [Route(nameof(RemoveEmployeeData))]
        [HttpPost]
        [AuthorizationFilter]
        public async Task<ResponseBase<EmployeeRemoveDataResponse>> RemoveEmployeeData([FromBody] EmployeeRemoveDataArgs args)
        {
            return await _service.RemoveData(args, base.JWTPayload);
        }


    }
}
