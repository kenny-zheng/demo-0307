using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mapster;
using App.BLL.Employee;
using App.Model.Northwind.Models; // 假設使用 Mapster 進行物件映射

namespace App.BLL.Employee
{
    public class EmployeeService : ServiceBase, IEmployee
    {

        private IEmployee _service;

        public EmployeeService(IEmployee service)
        {
            this._service = service;
        }


        /// <summary>
        /// 取得員工資料
        /// </summary>
        public async Task<ResponseBase<EmployeeGetDataResponse>> GetData(EmployeeGetDataArgs args)
        {
            var response = new ResponseBase<EmployeeGetDataResponse>()
            {
                Data = new EmployeeGetDataResponse()
            };

            try
            {
                await using (var context = await base.dbTemplate(Enum.ConnectionMode.Slave))
                {
                    var employee = await context.Employees
                        .FirstOrDefaultAsync(e => e.EmployeeID == args.EmployeeID);

                    if (employee != null)
                    {
                        response.Data = employee.Adapt<EmployeeGetDataResponse>();
                        response.IsSuccess = true;
                        response.Message = "查詢成功";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "找不到該員工";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
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
                Data = new List<EmployeeGetListResponse>()
            };

            try
            {
                await using (var context = _context)
                {
                    var query = context.Employees.AsQueryable();

                    // 根據查詢條件過濾
                    if (args.EmployeeID > 0)
                        query = query.Where(e => e.EmployeeID == args.EmployeeID);
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
                    response.Data = employees.Adapt<List<EmployeeGetListResponse>>();
                    response.IsSuccess = true;
                    response.Message = "查詢成功";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
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
                Data = new EmployeeSaveDataResponse()
            };

            try
            {
                await using (var context = _context)
                {
                    Employee employee;
                    if (args.EmployeeID > 0) // 更新
                    {
                        employee = await context.Employees
                            .FirstOrDefaultAsync(e => e.EmployeeID == args.EmployeeID);
                        if (employee == null)
                        {
                            response.IsSuccess = false;
                            response.Message = "找不到要更新的員工";
                            return response;
                        }
                    }
                    else // 新增
                    {
                        employee = new Employee();
                        context.Employees.Add(employee);
                    }

                    // 更新屬性
                    employee.LastName = args.LastName;
                    employee.FirstName = args.FirstName;
                    employee.Title = args.Title;
                    employee.TitleOfCourtesy = args.TitleOfCourtesy;
                    employee.BirthDate = args.BirthDate;
                    employee.HireDate = args.HireDate;
                    employee.Address = args.Address;
                    employee.City = args.City;
                    employee.Region = args.Region;
                    employee.PostalCode = args.PostalCode;
                    employee.Country = args.Country;
                    employee.HomePhone = args.HomePhone;
                    employee.Extension = args.Extension;
                    employee.Photo = args.Photo;
                    employee.Notes = args.Notes;
                    employee.ReportsTo = args.ReportsTo;
                    employee.PhotoPath = args.PhotoPath;

                    await context.SaveChangesAsync();
                    response.Data.IsSuccess = true;
                    response.Data.Message = "儲存成功";
                    response.IsSuccess = true;
                    response.Message = "員工資料儲存成功";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
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
                Data = new EmployeeRemoveDataResponse()
            };

            try
            {
                await using (var context = _context)
                {
                    var employee = await context.Employees
                        .FirstOrDefaultAsync(e => e.EmployeeID == args.EmployeeID);

                    if (employee == null)
                    {
                        response.IsSuccess = false;
                        response.Message = "找不到要移除的員工";
                        return response;
                    }

                    context.Employees.Remove(employee);
                    await context.SaveChangesAsync();
                    response.Data.IsSuccess = true;
                    response.Data.Message = "移除成功";
                    response.IsSuccess = true;
                    response.Message = "員工資料移除成功";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.Error($"RemoveEmployeeData EX Utc Now: {DateTime.UtcNow:yyyy/MM/dd HH:mm:ss}\n EX: {ex}");
            }

            return response;
        }

        public Task<ResponseBase<EmployeeGetDataResponse>> GetData(EmployeeGetDataArgs args)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase<List<EmployeeGetListResponse>>> GetList(EmployeeGetListArgs args, JWTPayload jwtPayload)
        {
            throw new NotImplementedException();
        }
    }
}