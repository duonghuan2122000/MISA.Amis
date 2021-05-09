using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Bộ lọc nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeFilter
    {
        /// <summary>
        /// trang hiện tại
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// số bản ghi trên một trang
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// từ khóa lọc (mã nhân viên, tên nhân viên)
        /// </summary>
        public string Filter { get; set; }
    }
}
