using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Data;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Kho chứa nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// string config kết nối db.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Hàm khởi tạo.
        /// </summary>
        /// <param name="configuration">Config project</param>
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionDB");
        }

        /// <summary>
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns></returns>
        /// CreatedBy: dbhuan (13/05/2021)
        public bool CheckEmployeeCodeExists(string employeeCode, Guid? employeeId = null)
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            // kiểm tra trùng mã.
            bool isExists = connection.QueryFirstOrDefault<bool>("Proc_CheckEmployeeCodeExists", new { employeeCode, employeeId }, commandType: CommandType.StoredProcedure);

            return isExists;
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
