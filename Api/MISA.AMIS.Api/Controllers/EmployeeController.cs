using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Dịch vụ nhân viên
        /// </summary>
        private IEmployeeService _employeeService;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeService">dịch vụ nhân viên</param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Lấy danh sách nhân viên có lọc.
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc nhân viên</param>
        /// <returns>
        /// 200 - Có dữ liệu trả về
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dbhuan (09/05/2021)
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] EmployeeFilter employeeFilter)
        {
            var res = _employeeService.GetEmployees(employeeFilter);
            if (res.Data.Any() && res.TotalRecord != null)
            {
                return Ok(res);
            }
            return NoContent();
        }

        /// <summary>
        /// Lấy thông tin nhân viên
        /// </summary>
        /// <param name="employeeId">Id nhân viên</param>
        /// <returns>
        /// 200 - Có dữ liệu trả về
        /// 204 - Không có dữ liệu
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dbhuan (09/05/2021)
        [HttpGet("{employeeId}")]
        public IActionResult GetEmployee(Guid employeeId)
        {
            var employee = _employeeService.GetEmployee(employeeId);
            if (employee == null)
            {
                return NoContent();
            }
            return Ok(employee);
        }

        /// <summary>
        /// Insert một nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>
        /// 201 - Thêm mới thành công
        /// 204 - Thêm mới thất bại
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dbhuan (09/05/2021)
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            var res = _employeeService.Insert(employee);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            return NoContent();
        }

        /// <summary>
        /// Update thông tin nhân viên
        /// </summary>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>
        /// 200 - Cập nhật thành công
        /// 204 - Cập nhật thất bại
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dbhuan (09/05/2021)
        [HttpPut]
        public IActionResult PutEmployee(Employee employee)
        {
            var res = _employeeService.Update(employee);
            if (res > 0)
            {
                return Ok(res);
            }
            return NoContent();
        }

        /// <summary>
        /// Xóa một nhân viên
        /// </summary>
        /// <param name="employeeId">id nhân viên</param>
        /// <returns>
        /// 200 - Xóa thành công
        /// 204 - Xóa thất bại
        /// 400 - Lỗi client
        /// 500 - Lỗi server
        /// </returns>
        /// CreatedBy: dbhuan (09/05/2021)
        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(Guid employeeId)
        {
            var res = _employeeService.Delete(employeeId);
            if (res > 0)
            {
                return Ok(res);
            }
            return NoContent();
        }

        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            return Ok(_employeeService.GetNewEmployeeCode());
        }
    }
}
