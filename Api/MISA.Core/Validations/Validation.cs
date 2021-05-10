using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Validations
{
    /// <summary>
    /// Attribute kiểm tra required.
    /// </summary>
    /// CreatedBy: dbhuan (10/05/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyRequired: Attribute
    {
        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        public string MsgError { get; set; }

        /// <summary>
        /// File resource
        /// </summary>
        public Type? ErrorResourceType { get; set; }

        /// <summary>
        /// Tên key resource
        /// </summary>
        public string ErrorResourceName { get; set; }
    }
}
