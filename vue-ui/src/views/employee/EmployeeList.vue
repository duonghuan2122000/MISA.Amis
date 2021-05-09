<template>
  <div class="content">
    <div class="title-box">
      <div class="title">Nhân viên</div>
      <div class="toolbar">
        <button class="btn btn-primary">Thêm mới nhân viên</button>
      </div>
    </div>

    <div class="toolbar-box">
      <div class="con-input">
        <input
          class="input has-icon"
          type="text"
          placeholder="Tìm theo mã, tên nhân viên"
          style="border-radius: 0"
        />
        <div class="icon-input icon icon-search"></div>
      </div>
      <div class="icon icon-refresh" style="margin-left: 8px"></div>
      <div class="icon icon-excel" style="margin-left: 8px"></div>
    </div>

    <div class="scroll">
      <table class="table">
        <thead>
          <tr>
            <th>#</th>
            <th>MÃ NHÂN VIÊN</th>
            <th>TÊN NHÂN VIÊN</th>
            <th>GIỚI TÍNH</th>
            <th>NGÀY SINH</th>
            <th>SỐ CMND</th>
            <th>CHỨC DANH</th>
            <th>TÊN ĐƠN VỊ</th>
            <th>SỐ TÀI KHOẢN</th>
            <th>TÊN NGÂN HÀNG</th>
            <th>CHI NHÁNH TK NGÂN HÀNG</th>
            <th>CHỨC NĂNG</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>
              <input type="checkbox" class="checkbox" id="checkbox1" />
              <label for="checkbox1"></label>
            </td>
            <td>NV001</td>
            <td>Dương Bằng Huân</td>
            <td>Nam</td>
            <td>02/12/2000</td>
            <td>123456789</td>
            <td>Tổng giám đốc</td>
            <td>Công ty Misa</td>
            <td>123456</td>
            <td>Techcombank</td>
            <td>Hà nội</td>
            <td>
              <div class="table-option">
                <button class="btn">Sửa</button>
                <div class="dropdown">
                  <div class="dropdown-btn">
                    <button class="btn icon icon-chevron-down-blue"></button>
                  </div>
                  <div class="dropdown-content right hide">
                    <div class="dropdown-item">Nhân bản</div>
                    <div class="dropdown-item">Xóa</div>
                    <div class="dropdown-item">Ngưng sử dụng</div>
                  </div>
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="divider"></div>

    <div class="pagination">
      <div>Tổng số: <b>100</b> bản ghi</div>
      <div class="pagination-right">
        <select>
          <option value="">20 bản ghi trên trang</option>
        </select>
        <div class="pager">
          <div class="page disable">Trước</div>
          <div class="page active">1</div>
          <div class="page">2</div>
          <div class="page">3</div>
          <div class="page disable">...</div>
          <div class="page">52</div>
          <div class="page">Sau</div>
        </div>
      </div>
    </div>
  </div>
</template>