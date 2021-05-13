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
    /// Base service.
    /// </summary>
    /// <typeparam name="T">Một thực thể.</typeparam>
    /// CreatedBy: dbhuan (28/04/2021)
    public class BaseService<T> : IBaseService<T> where T : class
    {
        /// <summary>
        /// Base repository.
        /// </summary>
        private IBaseRepository<T> _baseRepository;

        /// <summary>
        /// Phương thức khởi tạo.
        /// </summary>
        /// <param name="baseRepository">Base repository</param>
        /// CreatedBy: dbhuan (28/04/2021)
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        /// <summary>
        /// Phương thức xóa một thực thể.
        /// </summary>
        /// <param name="id">id của thực thể cần xóa.</param>
        /// <returns></returns>
        /// CreatedBy: dbhuan (28/04/2021)
        public int Delete(Guid id)
        {
            return _baseRepository.Delete(id);
        }

        /// <summary>
        /// Lấy thông tin dữ liệu của một thực thể.
        /// </summary>
        /// <param name="id">id của thực thể cần lấy.</param>
        /// <returns></returns>
        /// CreatedBy: dbhuan (28/04/2021)
        public T Get(Guid id)
        {
            return _baseRepository.Get(id);
        }

        /// <summary>
        /// Phương thức thêm mới một thực thể vào csdl.
        /// </summary>
        /// <param name="t">thông tin của thực thể.</param>
        /// <returns></returns>
        /// CreatedBy: dbhuan (28/04/2021)
        public int Insert(T t)
        {
            // Valid dữ liệu.
            Validate(t);
            CustomValidate(t);

            // Tiến hành thêm.
            return _baseRepository.Insert(t);
        }

        /// <summary>
        /// Cập nhật một thực thể.
        /// </summary>
        /// <param name="t">thông tin của thực thể</param>
        /// <returns></returns>
        /// CreatedBy: dbhuan (28/04/2021)
        public int Update(T t)
        {
            // Valid dữ liệu.
            Validate(t);
            CustomValidate(t, false);

            // Tiến hành cập nhật
            return _baseRepository.Update(t);
        }

        /// <summary>
        /// Phương thức valid dữ liệu
        /// </summary>
        /// <param name="t">Thông tin của thực thể.</param>
        /// CreatedBy: dbhuan (28/04/2021)
        private void Validate(T t)
        {
            // lấy ra tất cả các property của class.
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                // TODO: Phân chia valid.

                var requiredProperties = property.GetCustomAttributes(typeof(PropertyRequired), true);

                // check required.
                if (requiredProperties.Length > 0)
                {
                    // Lấy giá trị.
                    var propertyValue = property.GetValue(t);

                    // Kiểm tra giá trị.
                    if (propertyValue == null || string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var requiredProperty = requiredProperties[0] as PropertyRequired;
                        var msgError = requiredProperty.MsgError;

                        if (string.IsNullOrEmpty(msgError))
                        {
                            // lấy thông lỗi mặc định.
                            var msgErrorRequiredDefault = Properties.ValidationResource.MsgErrorPropertyRequired;

                            // Bind tên hiển thị cho thông báo lỗi. Mặc định là tên thuộc tính của thực thể.
                            var keyResource = !string.IsNullOrEmpty(requiredProperty.ErrorResourceName) ? requiredProperty.ErrorResourceName : property.Name;
                            var valueResource = new ResourceManager(requiredProperty.ErrorResourceType).GetString(keyResource);
                            var name = !string.IsNullOrEmpty(valueResource) ? valueResource : property.Name;

                            msgError = string.Format(msgErrorRequiredDefault, name);
                        }
                        throw new ClientException(msgError);
                    }
                }
            }
        }

        /// <summary>
        /// Phương thức dùng để cho valid của các trường hợp riêng biệt.
        /// </summary>
        /// <param name="t">Một thực thể</param>
        /// <param name="isInsert">Xác định insert hoặc update</param>
        /// CreatedBy: dbhuan (29/04/2021)
        protected virtual void CustomValidate(T t, bool isInsert = true)
        {

        }
    }

}