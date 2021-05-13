using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// Repository base class
    /// </summary>
    /// <typeparam name="T">Một thực thể.</typeparam>
    /// CreatedBy: dbhuan (28/04/2021)
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected IConfiguration _configuration;
        protected string _connectionString;
        private string _tableName = typeof(T).Name;

        /// <summary>
        /// Phương thức khởi tạo
        /// </summary>
        /// <param name="configuration">Config của project</param>
        /// CreatedBy: dbhuan (28/04/2021)
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ConnectionDB");
        }

        /// <summary>
        /// Xóa một thực thể T.
        /// </summary>
        /// <param name="id">id thực thể cần xóa.</param>
        /// <returns>Số thực thể bị xóa.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Delete(Guid id)
        {
            // Thiết lập kết nối cơ sở dữ liệu.
            var connection = new MySqlConnection(_connectionString);

            // stored procedures.
            var proc = $"Proc_Delete{_tableName}";

            var p = new DynamicParameters();
            p.Add($"{_tableName}Id", id);

            var rowsAffect = connection.Execute(proc, p, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }

        /// <summary>
        /// Lấy thông tin một thực thể T theo id.   
        /// </summary>
        /// <param name="id">id của thực thể cần lấy.</param>
        /// <returns>Thông tin thực thể T</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public T Get(Guid id)
        {
            // Thiết lập kết nối cơ sở dữ liệu.
            var connection = new MySqlConnection(_connectionString);

            var proc = $"Proc_Get{_tableName}ById";

            var p = new DynamicParameters();
            p.Add($"{_tableName}Id", id);

            // Lấy thông tin khách hàng.
            var entity = connection.QueryFirstOrDefault<T>(proc, p, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Thêm mới một thực thể T.
        /// </summary>
        /// <param name="t">Thông tin thực thể T.</param>
        /// <returns>Số thực thể được thêm vào.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Insert(T t)
        {
            // Thiết lập kết nối cơ sở dữ liệu.
            var connection = new MySqlConnection(_connectionString);

            var proc = $"Proc_Insert{_tableName}";

            var rowsAffect = connection.Execute(proc, t, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }

        /// <summary>
        /// Cập nhật thông tin một thực thể.
        /// </summary>
        /// <param name="t">Thông tin thực thể cần cập nhật.</param>
        /// <returns>Số thực thể được cập nhật.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Update(T t)
        {
            // Thiết lập kết nối cơ sở dữ liệu.
            var connection = new MySqlConnection(_connectionString);

            var proc = $"Proc_Update{_tableName}";

            var rowsAffect = connection.Execute(proc, t, commandType: CommandType.StoredProcedure);

            return rowsAffect;
        }
    }
}
