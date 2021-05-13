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
    public interface IEmployeeRepository: IBaseRepository<Employee>
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
        /// Kiểm tra trùng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">mã nhân viên</param>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns></returns>
        public bool CheckEmployeeCodeExists(string employeeCode, Guid? employeeId = null);
    }
}
