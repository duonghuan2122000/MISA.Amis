using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface base cho repository
    /// </summary>
    /// <typeparam name="T">Một thực thể</typeparam>
    /// CreatedBy: dbhuan (27/04/2021)
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Lấy thông tin một thực thể T theo id.   
        /// </summary>
        /// <param name="id">id của thực thể cần lấy.</param>
        /// <returns>Thông tin thực thể T</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public T Get(Guid id);

        /// <summary>
        /// Thêm mới một thực thể T.
        /// </summary>
        /// <param name="t">Thông tin thực thể T.</param>
        /// <returns>Số thực thể được thêm vào.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Insert(T t);

        /// <summary>
        /// Cập nhật thông tin một thực thể.
        /// </summary>
        /// <param name="t">Thông tin thực thể cần cập nhật.</param>
        /// <returns>Số thực thể được cập nhật.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Update(T t);

        /// <summary>
        /// Xóa một thực thể T.
        /// </summary>
        /// <param name="id">id thực thể cần xóa.</param>
        /// <returns>Số thực thể bị xóa.</returns>
        /// CreatedBy: dbhuan (27/04/2021)
        public int Delete(Guid id);
    }
}
