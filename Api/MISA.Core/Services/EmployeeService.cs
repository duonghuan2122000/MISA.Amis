using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    /// <summary>
    /// Dịch vụ nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeService: IEmployeeService
    {
        /// <summary>
        /// kho chứa nhân viên
        /// </summary>
        private IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeRepository">kho chứa nhân viên</param>
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Lấy danh sách nhân viên có lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc nhân viên</param>
        /// <returns>Danh sách nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Paging<Employee> GetEmployees(EmployeeFilter employeeFilter)
        {
            
            return _employeeRepository.GetEmployees(employeeFilter);
        }

        /// <summary>
        /// Lấy thông tin một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Thông tin một nhân viên</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public Employee GetEmployee(Guid employeeId)
        {
            return _employeeRepository.GetEmployee(employeeId);
        }

        /// <summary>
        /// Insert thông tin một nhân viên vào DB.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Insert(Employee employee)
        {
            return _employeeRepository.Insert(employee);
        }

        /// <summary>
        /// Update thông tin một nhân viên.
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Update(Employee employee)
        {
            return _employeeRepository.Update(employee);
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: dbhuan (09/05/2021)
        public int Delete(Guid employeeId)
        {
            return _employeeRepository.Delete(employeeId);
        }
    }
}
