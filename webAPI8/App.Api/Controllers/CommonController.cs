namespace App.Api.Controllers
{
    [Route("api/base")]
    public class CommonController : ControllerBase
    {
        private IBase _service;

        public CommonController(IBase service)
        {
            this._service = service;
        }

		/// <summary>
		/// 狀態
		/// </summary>
		/// <param name="TypeID">1:全選 2:請選擇 Other:None</param>
		/// <returns></returns>
		[Route("GetStatus")]
		[HttpPost]
		public ResponseBase<List<EnumResponse>> GetStatus([FromBody] EnumArgs args)
		{
			return _service.GetEnumList<Status>(args.TypeID);
		}

		/// <summary>
		/// Function
		/// </summary>
		/// <param name="TypeID">1:全選 2:請選擇 Other:None</param>
		/// <returns></returns>
		[Route("GetFunction")]
		[HttpPost]
		public async Task<ResponseBase<List<EnumResponse>>> GetFunction([FromBody] EnumArgs args)
		{
			return await _service.GetFunction(args.TypeID);
		}
	}
}
