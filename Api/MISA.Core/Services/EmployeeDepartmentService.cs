using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    /// <summary>
    /// Dịch vụ đơn vị nhân viên
    /// </summary>
    public class EmployeeDepartmentService: IEmployeeDepartmentService
    {
        private IEmployeeDepartmentRepository _employeeDepartmentRepository;

        public EmployeeDepartmentService(IEmployeeDepartmentRepository employeeDepartmentRepository)
        {
            _employeeDepartmentRepository = employeeDepartmentRepository;
        }

        /// <summary>
        /// Lấy danh sách đơn vị nhân viên
        /// </summary>
        /// <returns>Danh sách đơn vị nhân viên</returns>
        /// CreatedBy: dbhuan (11/05/2021)
        public IEnumerable<EmployeeDepartment> GetEmployeeDepartments()
        {
            return _employeeDepartmentRepository.GetEmployeeDepartments();
        }
    }
}
