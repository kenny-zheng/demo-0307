using App.Model.Northwind.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL.Employee
{
  public  interface IEmployee
    {
        /// <summary>
        /// 取得員工資料
        /// </summary>
        /// <param name="args">員工查詢參數</param>
        /// <returns>單筆員工資料回應</returns>
        Task<ResponseBase<EmployeeGetDataResponse>> GetData(EmployeeGetDataArgs args);

        /// <summary>
        /// 取得員工列表
        /// </summary>
        /// <param name="args">員工列表查詢參數</param>
        /// <param name="jwtPayload">JWT認證資訊</param>
        /// <returns>員工列表回應</returns>
        Task<ResponseBase<List<EmployeeGetListResponse>>> GetList(EmployeeGetListArgs args, JWTPayload jwtPayload);

        /// <summary>
        /// 儲存員工資料
        /// </summary>
        /// <param name="args">員工儲存參數</param>
        /// <param name="jwtPayload">JWT認證資訊</param>
        /// <returns>儲存操作回應</returns>
        Task<ResponseBase<EmployeeSaveDataResponse>> SaveData(EmployeeSaveDataArgs args, JWTPayload jwtPayload);

        /// <summary>
        /// 移除員工資料
        /// </summary>
        /// <param name="args">員工移除參數</param>
        /// <param name="jwtPayload">JWT認證資訊</param>
        /// <returns>移除操作回應</returns>
        Task<ResponseBase<EmployeeRemoveDataResponse>> RemoveData(EmployeeRemoveDataArgs args, JWTPayload jwtPayload);
    }
}
