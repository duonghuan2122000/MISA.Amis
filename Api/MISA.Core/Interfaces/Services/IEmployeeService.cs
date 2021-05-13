using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MISA.Core.Interfaces.Services
{
    /// <summary>
    /// Interface dịch vụ nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Lấy danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc nhân viên</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Paging<Employee> GetEmployees(EmployeeFilter employeeFilter);

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dbhuan (10/05/2021)
        public string GetNewEmployeeCode();

        /// <summary>
        /// Export file excel danh sách nhân viên có bộ lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc</param>
        /// <returns>Stream</returns>
        /// CreatedBy: dbhuan (11/05/2021)
        public Stream ExportExcel(EmployeeFilter employeeFilter);
    }
}
