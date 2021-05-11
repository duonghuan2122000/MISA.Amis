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
    public class EmployeeDepartmentRepository: IEmployeeDepartmentRepository
    {
        /// <summary>
        /// string config kết nối db.
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Hàm khởi tạo.
        /// </summary>
        /// <param name="configuration">Config project</param>
        public EmployeeDepartmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionDB");
        }


        /// <summary>
        /// Lấy danh sách đơn vị nhân viên
        /// </summary>
        /// <returns>Danh sách đơn vị nhân viên</returns>
        /// CreatedBy: dbhuan (11/05/2021)
        public IEnumerable<EmployeeDepartment> GetEmployeeDepartments()
        {
            // Thiết lập kết nối DB.
            using var connection = new MySqlConnection(_connectionString);

            var res = connection.Query<EmployeeDepartment>("Proc_GetEmployeeDepartment", commandType: CommandType.StoredProcedure);

            return res;
        }
    }
}
