using App.EF.EF.dbDemoContext;
using App.Model.Northwind.Models; // 假設使用 Mapster 進行物件映射
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace App.BLL.Employee
{
    public class EmployeeService : ServiceBase, IEmployee
    {
        /// <summary>
        /// 取得員工資料
        /// </summary>
        public async Task<ResponseBase<EmployeeGetDataResponse>> GetData(EmployeeGetDataArgs args)
        {
            ResponseBase<EmployeeGetDataResponse> response = new ResponseBase<EmployeeGetDataResponse>()
            {
                Entries = new EmployeeGetDataResponse()
            };

            try
            {
                await using (var context = await base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    TblEmployee? tblEmployee = await context.TblEmployees
                        .FirstOrDefaultAsync(e => e.EmployeeId == args.EmployeeID);

                    if (tblEmployee != null)
                    {
                        response.Entries = new EmployeeGetDataResponse
                        {
                            EmployeeID = tblEmployee.EmployeeId,
                            City = tblEmployee.City,
                            Country = tblEmployee.Country,
                            FirstName = tblEmployee.FirstName,
                            PostalCode = tblEmployee.FirstName,
                        };
                        response.StatusCode = EnumStatusCode.Success;
                        response.Message = "查詢成功";
                    }
                    else
                    {
                        response.StatusCode = EnumStatusCode.Fail;
                        response.Message = "找不到該員工";
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error($"GetEmployeeData EX Utc Now: {DateTime.UtcNow:yyyy/MM/dd HH:mm:ss}\n EX: {ex}");
            }

            return response;
        }

        /// <summary>
        /// 取得員工列表
        /// </summary>
        public async Task<ResponseBase<List<EmployeeGetListResponse>>> GetList(EmployeeGetListArgs args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<List<EmployeeGetListResponse>>()
            {
                Entries = new List<EmployeeGetListResponse>()
            };

            try
            {
                await using (var context = await base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    var query = context.TblEmployees.AsQueryable();

                    // 根據查詢條件過濾
                    if (args.EmployeeID > 0)
                        query = query.Where(e => e.EmployeeId == args.EmployeeID);
                    if (!string.IsNullOrEmpty(args.LastName))
                        query = query.Where(e => e.LastName.Contains(args.LastName));
                    if (!string.IsNullOrEmpty(args.FirstName))
                        query = query.Where(e => e.FirstName.Contains(args.FirstName));
                    if (!string.IsNullOrEmpty(args.Title))
                        query = query.Where(e => e.Title.Contains(args.Title));
                    if (args.BirthDate.HasValue)
                        query = query.Where(e => e.BirthDate == args.BirthDate);
                    if (!string.IsNullOrEmpty(args.City))
                        query = query.Where(e => e.City.Contains(args.City));
                    if (!string.IsNullOrEmpty(args.Country))
                        query = query.Where(e => e.Country.Contains(args.Country));

                    var employees = await query.ToListAsync();
                    response.Entries = employees.Adapt<List<EmployeeGetListResponse>>();
                    response.StatusCode = EnumStatusCode.Success;
                    response.Message = "查詢成功";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error($"GetEmployeeList EX Utc Now: {DateTime.UtcNow:yyyy/MM/dd HH:mm:ss}\n EX: {ex}");
            }

            return response;
        }

        /// <summary>
        /// 儲存員工資料
        /// </summary>
        public async Task<ResponseBase<EmployeeSaveDataResponse>> SaveData(EmployeeSaveDataArgs args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<EmployeeSaveDataResponse>()
            {
                Entries = new EmployeeSaveDataResponse()
            };

            try
            {
                await using (var context = await base.dbTemplate(Enum.ConnectionMode.Master))
                {
                    TblEmployee? tblEmployee = await context.TblEmployees.FindAsync(args.EmployeeID);

                    if (tblEmployee != null) // 更新
                    {  // 更新屬性
                        tblEmployee.LastName = args.LastName;
                        tblEmployee.FirstName = args.FirstName;
                        tblEmployee.Title = args.Title;
                        tblEmployee.TitleOfCourtesy = args.TitleOfCourtesy;
                        tblEmployee.BirthDate = args.BirthDate;
                        tblEmployee.HireDate = args.HireDate;
                        tblEmployee.Address = args.Address;
                        tblEmployee.City = args.City;
                        tblEmployee.Region = args.Region;
                        tblEmployee.PostalCode = args.PostalCode;
                        tblEmployee.Country = args.Country;
                        tblEmployee.HomePhone = args.HomePhone;
                        tblEmployee.Extension = args.Extension;
                        tblEmployee.Photo = args.Photo;
                        tblEmployee.Notes = args.Notes;
                        tblEmployee.ReportsTo = args.ReportsTo;
                        tblEmployee.PhotoPath = args.PhotoPath;
                    }
                    else // 新增
                    {
                        tblEmployee = new TblEmployee();
                        // 更新屬性
                        tblEmployee.LastName = args.LastName;
                        tblEmployee.FirstName = args.FirstName;
                        tblEmployee.Title = args.Title;
                        tblEmployee.TitleOfCourtesy = args.TitleOfCourtesy;
                        tblEmployee.BirthDate = args.BirthDate;
                        tblEmployee.HireDate = args.HireDate;
                        tblEmployee.Address = args.Address;
                        tblEmployee.City = args.City;
                        tblEmployee.Region = args.Region;
                        tblEmployee.PostalCode = args.PostalCode;
                        tblEmployee.Country = args.Country;
                        tblEmployee.HomePhone = args.HomePhone;
                        tblEmployee.Extension = args.Extension;
                        tblEmployee.Photo = args.Photo;
                        tblEmployee.Notes = args.Notes;
                        tblEmployee.ReportsTo = args.ReportsTo;
                        tblEmployee.PhotoPath = args.PhotoPath;
                        await context.TblEmployees.AddAsync(tblEmployee);
                    }
                    await context.SaveChangesAsync();
                    response.StatusCode = EnumStatusCode.Success;
                    response.Message = "員工資料儲存成功";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error($"SaveEmployeeData EX Utc Now: {DateTime.UtcNow:yyyy/MM/dd HH:mm:ss}\n EX: {ex}");
            }

            return response;
        }

        /// <summary>
        /// 移除員工資料
        /// </summary>
        public async Task<ResponseBase<EmployeeRemoveDataResponse>> RemoveData(EmployeeRemoveDataArgs args, JWTPayload jwtPayload)
        {
            var response = new ResponseBase<EmployeeRemoveDataResponse>()
            {
                Entries = new EmployeeRemoveDataResponse()
            };

            try
            {
                await using (var context = await base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    TblEmployee? tblEmployee = await context.TblEmployees
                        .FirstOrDefaultAsync(e => e.EmployeeId == args.EmployeeID);

                    if (tblEmployee == null)
                    {
                        response.StatusCode = EnumStatusCode.Fail;
                        response.Message = "找不到要移除的員工";
                        return response;
                    }

                    context.TblEmployees.Remove(tblEmployee);
                    await context.SaveChangesAsync();
                    response.StatusCode = EnumStatusCode.Success;
                    response.Message = "員工資料移除成功";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = EnumStatusCode.Fail;
                response.Message = ex.Message;
                _logger.Error($"RemoveEmployeeData EX Utc Now: {DateTime.UtcNow:yyyy/MM/dd HH:mm:ss}\n EX: {ex}");
            }

            return response;
        }

    }
}