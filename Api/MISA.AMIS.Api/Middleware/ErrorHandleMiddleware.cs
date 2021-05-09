using Microsoft.AspNetCore.Http;
using MISA.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.AMIS.Api.Middleware
{
    /// <summary>
    /// ErrorHandleMiddleware
    /// </summary>
    /// CreatedBy: dbhuan (09/05/2021)
    public class ErrorHandleMiddleware
    {
        /// <summary>
        /// Luồng request.
        /// </summary>
        private RequestDelegate _next;

        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="next"></param>
        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Hàm call của middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ErrorHandle(context, ex);
            }
        }

        /// <summary>
        /// Xử lý lỗi.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private Task ErrorHandle(HttpContext context, Exception ex)
        {
            int statusCode = 500;
            if(ex is ClientException)
            {
                statusCode = 400;
            }

            var res = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xảy ra"
            };

            var result = JsonSerializer.Serialize(res);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
