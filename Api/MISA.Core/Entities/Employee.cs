using MISA.Core.Enums;
using MISA.Core.Properties;
using MISA.Core.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin nhân viên.
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [PropertyRequired(ErrorResourceType = typeof(EmployeeResource))]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [PropertyRequired(ErrorResourceType = typeof(EmployeeResource))]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính: 0 - Nam, 1 - Nữ, 2 - Khác
        /// </summary>
        public GenderEnum? Gender { get; set; }

        /// <summary>
        /// Id của đơn vị nhân viên.
        /// </summary>
        [PropertyRequired(ErrorResourceType = typeof(EmployeeResource))]
        public Guid? EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên đơn vị nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// Số CMND/ CCCD
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp CMND/ CCCD
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp CMND/ CCCD
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Chức danh nhân viên
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Địa chỉ nhân viên
        /// </summary>
        public string EmployeeAddress { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string TeleNumber { get; set; }

        /// <summary>
        /// Email của nhân viên
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public string GenderName
        {
            get
            {
                return Gender switch
                {
                    GenderEnum.MALE => Properties.Resources.MALE,
                    GenderEnum.FEMALE => Properties.Resources.FEMALE,
                    GenderEnum.OTHER => Properties.Resources.OTHER,
                    _ => Properties.Resources.UNKNOWN
                };
            }
        }
    }
}
