using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Interface dịch vụ đơn vị nhân viên
    /// </summary>
    public interface IEmployeeDepartmentService
    {
        /// <summary>
        /// Lấy danh sách đơn vị nhân viên
        /// </summary>
        /// <returns>Danh sách đơn vị nhân viên</returns>
        /// CreatedBy: dbhuan (11/05/2021)
        public IEnumerable<EmployeeDepartment> GetEmployeeDepartments();
    }
}
