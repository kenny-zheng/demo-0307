using App.BLL.Employee;
using App.Model;

namespace App.Tests.EmployeeServiceTests
{
    [TestClass]
    public class EmployeeServiceTests
    {

        //// 測試 GetData 方法 - 成功案例
        //[TestMethod]
        //public async Task GetData_EmployeeExists_ReturnsSuccess()
        //{

        //    var service = new EmployeeService();
        //    var employee = new TblEmployee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        City = "New York",
        //        Country = "USA"
        //    };


        //    var args = new EmployeeGetDataArgs { EmployeeID = 1 };

        //    // Act
        //    var result = await service.GetData(args);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Success, result.StatusCode);
        //    Assert.AreEqual("查詢成功", result.Message);
        //    Assert.IsNotNull(result.Entries);
        //    Assert.AreEqual(1, result.Entries.EmployeeID);
        //    Assert.AreEqual("John", result.Entries.FirstName);
        //    Assert.AreEqual("New York", result.Entries.City);
        //    Assert.AreEqual("USA", result.Entries.Country);
        //}

        //// 測試 GetData 方法 - 員工不存在案例
        //[TestMethod]
        //public async Task GetData_EmployeeNotFound_ReturnsFail()
        //{
        //    // Arrange
        //    using var context = GetInMemoryDbContext();
        //    var service = new EmployeeService(context);
        //    var args = new EmployeeGetDataArgs { EmployeeID = 1 };

        //    // Act
        //    var result = await service.GetData(args);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Fail, result.StatusCode);
        //    Assert.AreEqual("找不到該員工", result.Message);
        //    Assert.IsNotNull(result.Entries);
        //}

        //// 測試 GetList 方法 - 成功案例
        //[TestMethod]
        //public async Task GetList_WithFilters_ReturnsFilteredList()
        //{
        //    // Arrange
        //    using var context = GetInMemoryDbContext();
        //    var service = new EmployeeService(context);
        //    context.TblEmployees.AddRange(
        //        new TblEmployee { EmployeeId = 1, FirstName = "John", LastName = "Doe", City = "New York" },
        //        new TblEmployee { EmployeeId = 2, FirstName = "Jane", LastName = "Doe", City = "Los Angeles" }
        //    );
        //    await context.SaveChangesAsync();

        //    var args = new EmployeeGetListArgs { FirstName = "John" };
        //    var jwtPayload = new JWTPayload();

        //    // Act
        //    var result = await service.GetList(args, jwtPayload);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Success, result.StatusCode);
        //    Assert.AreEqual("查詢成功", result.Message);
        //    Assert.IsNotNull(result.Entries);
        //    Assert.AreEqual(1, result.Entries.Count);
        //    Assert.AreEqual("John", result.Entries[0].FirstName);
        //}

        // 測試 SaveData 方法 - 新增成功案例
        [TestMethod]
        public async Task SaveData_NewEmployee_ReturnsSuccess()
        {
            IEmployee _service = new EmployeeService();
            var args = new EmployeeSaveDataArgs
            {
                EmployeeID = 1,
                FirstName = "John",
                LastName = "Doe",
                City = "New York"
            };
            var jwtPayload = new JWTPayload();

            // Act
            var result = await _service.SaveData(args, jwtPayload);

            // Assert
            Assert.AreEqual(EnumStatusCode.Success, result.StatusCode);
            Assert.AreEqual("員工資料儲存成功", result.Message);
            Assert.IsNotNull(result.Entries);

        }

        // 測試 SaveData 方法 - 更新成功案例
        //[TestMethod]
        //public async Task SaveData_UpdateEmployee_ReturnsSuccess()
        //{
        //    // Arrange
        //    using var context = GetInMemoryDbContext();
        //    var service = new EmployeeService(context);
        //    var employee = new TblEmployee { EmployeeId = 1, FirstName = "OldName" };
        //    context.TblEmployees.Add(employee);
        //    await context.SaveChangesAsync();

        //    var args = new EmployeeSaveDataArgs
        //    {
        //        EmployeeID = 1,
        //        FirstName = "John",
        //        LastName = "Doe"
        //    };
        //    var jwtPayload = new JWTPayload();

        //    // Act
        //    var result = await service.SaveData(args, jwtPayload);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Success, result.StatusCode);
        //    Assert.AreEqual("員工資料儲存成功", result.Message);
        //    var updatedEmployee = await context.TblEmployees.FindAsync(1);
        //    Assert.IsNotNull(updatedEmployee);
        //    Assert.AreEqual("John", updatedEmployee.FirstName);
        //    Assert.AreEqual("Doe", updatedEmployee.LastName);
        //}

        //// 測試 RemoveData 方法 - 成功案例
        //[TestMethod]
        //public async Task RemoveData_EmployeeExists_ReturnsSuccess()
        //{
        //    // Arrange
        //    using var context = GetInMemoryDbContext();
        //    var service = new EmployeeService(context);
        //    var employee = new TblEmployee { EmployeeId = 1 };
        //    context.TblEmployees.Add(employee);
        //    await context.SaveChangesAsync();

        //    var args = new EmployeeRemoveDataArgs { EmployeeID = 1 };
        //    var jwtPayload = new JWTPayload();

        //    // Act
        //    var result = await service.RemoveData(args, jwtPayload);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Success, result.StatusCode);
        //    Assert.AreEqual("員工資料移除成功", result.Message);
        //    var deletedEmployee = await context.TblEmployees.FindAsync(1);
        //    Assert.IsNull(deletedEmployee);
        //}

        //// 測試 RemoveData 方法 - 員工不存在案例
        //[TestMethod]
        //public async Task RemoveData_EmployeeNotFound_ReturnsFail()
        //{
        //    // Arrange
        //    using var context = GetInMemoryDbContext();
        //    var service = new EmployeeService(context);
        //    var args = new EmployeeRemoveDataArgs { EmployeeID = 1 };
        //    var jwtPayload = new JWTPayload();

        //    // Act
        //    var result = await service.RemoveData(args, jwtPayload);

        //    // Assert
        //    Assert.AreEqual(EnumStatusCode.Fail, result.StatusCode);
        //    Assert.AreEqual("找不到要移除的員工", result.Message);
        //}
    }
}