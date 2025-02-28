using App.EF.EF.dbTemplate;

namespace App.BLL
{
    public interface IUser
    {
        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ResponseBase<TblUser>> GetUser(string model);

        Task<ResponseBase<string>> UserLogin(UserLoginRequest model, string clientIP);

        Task<ResponseBase<GetMenuResponse>> GetMenu(GetMenuArgs args, JWTPayload jwtPayload);

        Task<ResponseBase<List<UserGetListResponse>>> GetList(UserGetListArgs Args, JWTPayload jwtPayload);

        Task<ResponseBase<UserGetDataResponse>> GetData(UserGetDataArgs Args);

        Task<ResponseBase<UserSaveDataResponse>> SaveData(UserSaveDataArgs Args, JWTPayload jwtPayload);

        Task<ResponseBase<UserRemoveDataResponse>> RemoveData(UserRemoveDataArgs Args, JWTPayload jwtPayload);


        Task<ResponseBase<List<UserGetUserLogResponse>>> GetUserLog(UserGetUserLogArgs Args);

        Task<ResponseBase<UserSetUserLogResponse>> SetUserLog(UserSetUserLogArgs Args, JWTPayload jwtPayload);
    }
}