using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>
        /// 200 - Có dữ liệu trả về.
        /// 500 - Lỗi server.
        /// </returns>
        /// CreatedBy: dbhuan (10/05/2021)
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            return Ok(_employeeService.GetNewEmployeeCode());
        }

        /// <summary>
        /// Xuất excel
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc danh sách nhân viên.</param>
        /// <returns>
        /// 200 - thành công.
        /// 500 - lỗi server.
        /// </returns>
        [HttpGet("Export")]
        public IActionResult Export([FromQuery] EmployeeFilter employeeFilter)
        {
            var res = _employeeService.GetEmployees(employeeFilter);
            var list = res.Data.ToList();
            var stream = new MemoryStream();
            using var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 30;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 15;
            workSheet.Column(9).Width = 30;

            using(var range = workSheet.Cells["A1:I1"])
            {
                range.Merge = true;
                range.Value = "DANH SÁCH NHÂN VIÊN";
                range.Style.Font.Bold = true;
                range.Style.Font.Size = 16;
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }

            // style cho excel.
            workSheet.Cells[3, 1].Value = "STT";
            workSheet.Cells[3, 2].Value = "Mã nhân viên";
            workSheet.Cells[3, 3].Value = "Tên nhân viên";
            workSheet.Cells[3, 4].Value = "Giới tính";
            workSheet.Cells[3, 5].Value = "Ngày sinh";
            workSheet.Cells[3, 6].Value = "Chức danh";
            workSheet.Cells[3, 7].Value = "Tên đơn vị";
            workSheet.Cells[3, 8].Value = "Số tài khoản";
            workSheet.Cells[3, 9].Value = "Tên ngân hàng";

            using (var range = workSheet.Cells["A3:I3"])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                range.Style.Font.Bold = true;
                range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            }


            int i = 0;
            // đổ dữ liệu từ list vào.
            foreach(var e in list)
            {
                workSheet.Cells[i + 4, 1].Value = i + 1;
                workSheet.Cells[i + 4, 2].Value = e.EmployeeCode;
                workSheet.Cells[i + 4, 3].Value = e.EmployeeName;
                workSheet.Cells[i + 4, 4].Value = e.GenderName;
                workSheet.Cells[i + 4, 5].Value = e.DateOfBirth?.ToString("dd/MM/yyyy");
                workSheet.Cells[i + 4, 6].Value = e.EmployeePosition;
                workSheet.Cells[i + 4, 7].Value = e.EmployeeDepartmentName;
                workSheet.Cells[i + 4, 8].Value = e.BankAccountNumber;
                workSheet.Cells[i + 4, 9].Value = e.BankName;

                using(var range = workSheet.Cells[i + 4, 1, i + 4, 9])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                i++;
            }

            package.Save();
            stream.Position = 0;
            string excelName = $"Danh-sach-nhan-vien-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
    }
}
