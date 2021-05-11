using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/employee-department")]
    [ApiController]
    public class EmployeeDepartmentController : ControllerBase
    {
        private IEmployeeDepartmentService _employeeDepartmentService;

        public EmployeeDepartmentController(IEmployeeDepartmentService employeeDepartmentService)
        {
            _employeeDepartmentService = employeeDepartmentService;
        }

        /// <summary>
        /// Lấy danh sách đơn vị nhân viên.
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu trả về.
        /// 500 - Lỗi server.
        /// </returns>
        [HttpGet]
        public IActionResult GetEmployeeDepartments()
        {
            var res = _employeeDepartmentService.GetEmployeeDepartments();
            return Ok(res);
        }
    }
}
