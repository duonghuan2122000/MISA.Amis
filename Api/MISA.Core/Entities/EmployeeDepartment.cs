using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin đơn vị nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeDepartment
    {
        /// <summary>
        /// Id của đơn vị nhân viên
        /// </summary>
        public Guid EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// Mô tả bộ phận
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Trách nhiệm đơn vị
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Quyền lợi của đơn vị
        /// </summary>
        public string Profit { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
