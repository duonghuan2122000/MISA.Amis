using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Exceptions
{
    /// <summary>
    /// ClientException
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class ClientException: Exception
    {
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="msg">Thông báo lỗi</param>
        public ClientException(string msg): base(msg)
        {

        }
    }
}
