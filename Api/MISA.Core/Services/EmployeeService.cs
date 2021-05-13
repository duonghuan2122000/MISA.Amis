using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repositories;
using MISA.Core.Interfaces.Services;
using MISA.Core.Validations;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;

namespace MISA.Core.Services
{
    /// <summary>
    /// Dịch vụ nhân viên
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        /// <summary>
        /// kho chứa nhân viên
        /// </summary>
        private IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="employeeRepository">kho chứa nhân viên</param>
        public EmployeeService(IEmployeeRepository employeeRepository): base(employeeRepository)
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
        /// Tạo mã nhân viên mới.
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreatedBy: dbhuan (10/05/2021)
        public string GetNewEmployeeCode()
        {
            return _employeeRepository.GetNewEmployeeCode();
        }

        /// <summary>
        /// Export file excel danh sách nhân viên có bộ lọc
        /// </summary>
        /// <param name="employeeFilter">Bộ lọc</param>
        /// <returns>Stream</returns>
        /// CreatedBy: dbhuan (11/05/2021)
        public Stream ExportExcel(EmployeeFilter employeeFilter)
        {
            var res = _employeeRepository.GetEmployees(employeeFilter);
            var list = res.Data.ToList();
            var stream = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage(stream);
            var workSheet = package.Workbook.Worksheets.Add("DANH SÁCH NHÂN VIÊN");

            // set độ rộng col
            workSheet.Column(1).Width = 5;
            workSheet.Column(2).Width = 15;
            workSheet.Column(3).Width = 30;
            workSheet.Column(4).Width = 10;
            workSheet.Column(5).Width = 15;
            workSheet.Column(6).Width = 30;
            workSheet.Column(7).Width = 30;
            workSheet.Column(8).Width = 15;
            workSheet.Column(9).Width = 30;


            using (var range = workSheet.Cells["A1:I1"])
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
            foreach (var e in list)
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

                using (var range = workSheet.Cells[i + 4, 1, i + 4, 9])
                {
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                }
                i++;
            }

            package.Save();
            stream.Position = 0;
            return package.Stream;
        }


        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <param name="isInsert">Xác định insert hoặc update</param>
        /// CreatedBy: dbhuan (29/04/2021)
        protected override void CustomValidate(Employee employee, bool isInsert = true)
        {
            bool isExists;
            if(isInsert == true)
            {
                isExists = _employeeRepository.CheckEmployeeCodeExists(employee.EmployeeCode);
            } else
            {
                isExists = _employeeRepository.CheckEmployeeCodeExists(employee.EmployeeCode, employee.EmployeeId);
            }

            if(isExists == true)
            {
                throw new ClientException(Properties.ValidationResource.MsgErrorEmployeeCodeExists);
            }
        }

    }
}
