namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserGroupController : BaseController
    {
        private IUserGroup _service;

        public UserGroupController(IUserGroup service)
        {
            this._service = service;
        }

        /// <summary>
        /// 取得群組列表
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetList")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.role_management_view)]
        public async Task<ResponseBase<List<UserGroupGetListResponse>>> GetList([FromBody] UserGroupGetListArgs Args)
        {
            return await _service.GetList(Args, base.JWTPayload);
        }

        /// <summary>
        /// 取得群組
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("GetData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.role_management_view)]
        public async Task<ResponseBase<UserGroupGetDataResponse>> GetData([FromBody] UserGroupGetDataArgs Args)
        {
            return await _service.GetData(Args, base.JWTPayload);
        }

        /// <summary>
        /// 群組新增
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("AddData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.role_management_add)]
        public async Task<ResponseBase<UserGroupSaveDataResponse>> AddData([FromBody] UserGroupSaveDataArgs Args)
        {
            return await _service.SaveData(Args, base.JWTPayload);
        }

        /// <summary>
        /// 群組存檔
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("SaveData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.role_management_edit)]
        public async Task<ResponseBase<UserGroupSaveDataResponse>> SaveData([FromBody] UserGroupSaveDataArgs Args)
        {
            return await _service.SaveData(Args, base.JWTPayload);
        }

        /// <summary>
        /// 刪除群組
        /// </summary>
        /// <param name="Args"></param>
        /// <returns></returns>
        [Route("RemoveData")]
        [HttpPost]
        [AuthorizationFilter(Enum.Functions.role_management_delete)]
        public async Task<ResponseBase<UserGroupRemoveDataResponse>> RemoveData([FromBody] UserGroupRemoveDataArgs Args)
        {
            return await _service.RemoveData(Args, base.JWTPayload);
        }

    }
}
