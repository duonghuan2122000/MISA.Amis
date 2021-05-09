using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface kho chứa nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Lấy danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc nhân viên</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Paging<Employee> GetEmployees(EmployeeFilter employeeFilter);

        /// <summary>
        /// Lấy thông tin một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Thông tin một nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Employee GetEmployee(Guid employeeId);

        /// <summary>
        /// Insert thông tin một nhân viên vào DB.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Insert(Employee employee);

        /// <summary>
        /// Update thông tin một nhân viên.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Update(Employee employee);

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Delete(Guid employeeId);
    }
}
