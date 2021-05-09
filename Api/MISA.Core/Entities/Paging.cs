using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Phân trang
    /// </summary>
    /// <typeparam name="T">Thực thể</typeparam>
    /// CreatedBy: dbhuan (09/05/2021)
    public class Paging<T> where T: class
    {
        /// <summary>
        /// Tổng số bản ghi
        /// </summary>
        public int? TotalRecord { get; set; }

        /// <summary>
        /// Tổng số trang
        /// </summary>
        public int? TotalPages
        {
            get
            {
                return (int) Math.Ceiling((decimal) TotalRecord / PageSize);
            }
        }

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Số bản ghi trên một trang
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Dữ liệu
        /// </summary>
        public IEnumerable<T>? Data { get; set; }

    }
}
