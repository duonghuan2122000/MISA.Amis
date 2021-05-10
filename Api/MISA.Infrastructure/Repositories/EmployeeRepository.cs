using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Kho chứa nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// string config kết nối db.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Hàm khởi tạo.
        /// </summary>
        /// <param name="configuration">Config project</param>
        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionDB");
        }

        /// <summary>
        /// Lấy danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc nhân viên</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Paging<Employee> GetEmployees(EmployeeFilter employeeFilter)
        {
            var res = new Paging<Employee>()
            {
                Page = employeeFilter.Page,
                PageSize = employeeFilter.PageSize
            };

            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // Tính tổng nhân viên.
            int? totalRecord = connection.QueryFirstOrDefault<int>("Proc_GetTotalEmployees", employeeFilter, commandType: CommandType.StoredProcedure);

            if (totalRecord == null)
            {
                return res;
            }

            res.TotalRecord = totalRecord;

            // Lấy danh sách nhân viên.
            var employees = connection.Query<Employee>("Proc_GetEmployees", employeeFilter, commandType: CommandType.StoredProcedure);

            res.Data = employees;

            return res;
        }

        /// <summary>
        /// Lấy thông tin một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Thông tin một nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Employee GetEmployee(Guid employeeId)
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // Thiết lập param cho stored procedure.
            var p = new DynamicParameters();
            p.Add("employeeId", employeeId);

            // Lấy thông tin nhân viên.
            var employee = connection.QueryFirstOrDefault<Employee>("Proc_GetEmployee", p, commandType: CommandType.StoredProcedure);

            return employee;
        }

        /// <summary>
        /// Insert thông tin một nhân viên vào DB.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Insert(Employee employee)
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // insert vào db.
            var rowsAffect = connection.Execute("Proc_InsertEmployee", employee, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }

        /// <summary>
        /// Update thông tin một nhân viên.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Update(Employee employee)
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // insert vào db.
            var rowsAffect = connection.Execute("Proc_UpdateEmployee", employee, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Delete(Guid employeeId)
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // Thiết lập param cho stored procedure.
            var p = new DynamicParameters();
            p.Add("employeeId", employeeId);

            // Lấy thông tin nhân viên.
            var rowsAffect = connection.Execute("Proc_DeleteEmployee", p, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dbhuan (10/05/2021)
        public string GetNewEmployeeCode()
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // Lấy mã nhân viên lớn nhất trên db.
            string? maxEmployeeCode = connection.QueryFirstOrDefault<string>("Proc_MaxEmployeeCode", commandType: CommandType.StoredProcedure);

            if (maxEmployeeCode == null)
            {
                return "NV-0001";
            }

            string employeeCodeNumStr = string.Empty;

            for (var i = 0; i < maxEmployeeCode.Length; i++)
            {
                if (char.IsDigit(maxEmployeeCode[i]))
                {
                    employeeCodeNumStr += maxEmployeeCode[i];
                }
            }

            int employeeCodeNum = int.Parse(employeeCodeNumStr);
            employeeCodeNum++;

            return "NV-" + employeeCodeNum;
        }
    }
}
