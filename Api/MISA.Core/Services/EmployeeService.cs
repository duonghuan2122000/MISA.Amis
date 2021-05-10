using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using MISA.Core.Validations;
using System;
using System.Collections.Generic;
using System.Resources;
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
            if(employeeFilter.Page <= 0 || employeeFilter.PageSize <= 0)
            {
                throw new ClientException("Tham số truyền vào không hợp lệ");
            }
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
            Validate(employee);
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
            Validate(employee);
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

        /// <summary>
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dbhuan (10/05/2021)
        public string GetNewEmployeeCode()
        {
            return _employeeRepository.GetNewEmployeeCode();
        }

        /// <summary>
        /// Valid dữ liệu
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// CreatedBy: dbhuan (10/05/2021)
        private void Validate(Employee employee)
        {
            var properties = typeof(Employee).GetProperties();

            foreach(var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(PropertyRequired), true);

                if(requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(employee);

                    if(propertyValue == null || string.IsNullOrEmpty((string)propertyValue))
                    {
                        var requiredProperty = requiredProperties[0] as PropertyRequired;

                        var msgError = requiredProperty.MsgError;

                        if (string.IsNullOrEmpty(msgError))
                        {
                            var msgErrorPropertyRequired = Properties.ValidationResource.MsgErrorPropertyRequired;

                            var keyResource = string.IsNullOrEmpty(requiredProperty.ErrorResourceName) ? property.Name : requiredProperty.ErrorResourceName;

                            var valueResource = new ResourceManager(requiredProperty.ErrorResourceType).GetString(keyResource);

                            var name = string.IsNullOrEmpty(valueResource) ? property.Name : valueResource;

                            msgError = string.Format(msgErrorPropertyRequired, name);
                        }

                        throw new ClientException(msgError);
                    }
                }
            }
        }
    }
}
