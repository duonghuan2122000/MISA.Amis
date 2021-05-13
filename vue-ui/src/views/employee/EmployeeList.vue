<template>
  <div>
    <div class="content">
      <div class="title-box">
        <div class="title">Nhân viên</div>
        <div class="toolbar">
          <button class="btn btn-primary" @click="showEmployeeDialog">
            Thêm mới nhân viên
          </button>
        </div>
      </div>

      <div class="toolbar-box">
        <div class="con-input">
          <input
            class="input has-icon"
            type="text"
            placeholder="Tìm theo mã, tên nhân viên"
            style="border-radius: 0"
            :value="filter"
            @input="onChangeInputEmployeeFilter"
          />
          <div class="icon-input icon icon-search"></div>
        </div>
        <div
          class="icon icon-refresh"
          style="margin-left: 8px"
          @click.prevent="onBtnClickRefresh"
        ></div>
        <div
          class="icon icon-excel"
          style="margin-left: 8px"
          @click.prevent="onBtnClickExportExcel"
        ></div>
      </div>

      <div class="data">
        <div class="flex-center" v-show="isLoading">
          <div class="loader"></div>
        </div>

        <div class="flex-center" v-if="isError">
          <div class="icon icon-error"></div>
          <div>Có lỗi xảy ra.</div>
        </div>

        <div class="scroll" v-if="!isError && employees.length > 0">
          <table class="table">
            <thead>
              <tr>
                <th>
                  <input type="checkbox" class="checkbox" id="checkbox-all" />
                  <label for="checkbox-all"></label>
                </th>
                <th style="min-width: 150px">MÃ NHÂN VIÊN</th>
                <th style="min-width: 150px">TÊN NHÂN VIÊN</th>
                <th style="min-width: 150px">GIỚI TÍNH</th>
                <th style="min-width: 150px">NGÀY SINH</th>
                <th style="min-width: 150px">SỐ CMND</th>
                <th style="min-width: 150px">CHỨC DANH</th>
                <th style="min-width: 150px">TÊN ĐƠN VỊ</th>
                <th style="min-width: 150px">SỐ TÀI KHOẢN</th>
                <th style="min-width: 150px">TÊN NGÂN HÀNG</th>
                <th style="min-width: 150px">CHI NHÁNH TK NGÂN HÀNG</th>
                <th style="min-width: 150px">CHỨC NĂNG</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="e in employees" :key="e.employeeId">
                <td>
                  <input
                    type="checkbox"
                    class="checkbox"
                    :id="e.employeeCode"
                  />
                  <label :for="e.employeeCode"></label>
                </td>
                <td>{{ e.employeeCode }}</td>
                <td>{{ e.employeeName }}</td>
                <td>{{ e.genderName }}</td>
                <td style="text-align: center">
                  {{ formatDateDDMMYYY(e.dateOfBirth) }}
                </td>
                <td>{{ e.identityNumber }}</td>
                <td>{{ e.employeePosition }}</td>
                <td>{{ e.employeeDepartmentName }}</td>
                <td>{{ e.bankAccountNumber }}</td>
                <td>{{ e.bankName }}</td>
                <td>{{ e.bankBranchName }}</td>
                <td>
                  <EmployeeDropdown
                    @onClickBtnEdit="onClickBtnEditEmployee(e.employeeId)"
                    @onClickBtnDel="onClickBtnDelEmployee(e)"
                  />
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div class="divider"></div>

      <EmployeePagination
        :page="page"
        :totalPages="totalPages"
        :totalRecord="totalRecord"
        :pageSize="pageSize"
        @update:pageSize="onChangePageSize"
        @onChangePage="onChangePage"
      />
    </div>

    <EmployeeDialog
      :isShow="isShowEmployeeDialog"
      :employee.sync="employeeModify"
      :employeeDepartments="employeeDepartments"
      @onClose="setStateEmployeeDialog(false)"
      @onPositive="saveEmployee"
    />

    <AlertDialog
      :isShow="isShowAlertDialog"
      :employeeCode="employeeDel && employeeDel.employeeCode"
      @onPositive="delEmployee"
      @onClose="setStateAlertDialog(false)"
    />

    <ErrorDialog
      :isShow="isShowErrorDialog"
      :employeeCode="employeeCodeExists"
      @onClose="isShowErrorDialog = false"
    />
  </div>
</template>

<script>
import req from "../../utils/axios.js";
import dayjs from "dayjs";

import StateEnum from "../../enums/StateEnum.js";

import EmployeePagination from "./EmployeePagination.vue";
import EmployeeDropdown from "./EmployeeDropdown.vue";
import EmployeeDialog from "./EmployeeDialog.vue";
import AlertDialog from "./AlertDialog.vue";
import ErrorDialog from "./ErrorDialog.vue";
export default {
  components: {
    EmployeePagination,
    EmployeeDropdown,
    EmployeeDialog,
    AlertDialog,
    ErrorDialog,
  },
  data: () => ({
    state: StateEnum.LOADING,

    /**
     * trang hiện tại.
     * CreatedBy: dbhuan (09/05/2021)
     */
    page: 1,

    /**
     * Số bản ghi trên một trang
     * CreatedBy: dbhuan (09/05/2021)
     */
    pageSize: 20,

    /**
     * Bộ lọc filter nhân viên
     * CreatedBy: dbhuan (09/05/2021)
     */
    filter: "",

    /**
     * Tổng số trang.
     * CreatedBy: dbhuan (10/05/2021)
     */
    totalPages: 0,

    /**
     * Tổng số bản ghi
     * CreatedBy: dbhuan (10/05/2021)
     */
    totalRecord: 0,

    /**
     * Danh sách nhân viên
     * CreatedBy: dbhuan (09/05/2021)
     */
    employees: [],

    /**
     * Danh sách đơn vị nhân viên.
     * CreatedBy: dbhuan (11/05/2021)
     */
    employeeDepartments: [],

    /**
     * Thông tin nhân viên cần thêm hoặc sửa.
     * CreatedBy: dbhuan (10/05/2021)
     */
    employeeModify: null,

    /**
     * Mã nhân viên trung.
     * CreatedBy: dbhuan (13/05/2021)
     */
    employeeCodeExists: null,

    /**
     * Thông tin nhân viên cần xóa.
     * CreatedBy: dbhuan (10/05/2021)
     */
    employeeDel: null,

    /**
     * Biến xác định trạng thái employee dialog.
     * CreatedBy: dbhuan (09/05/2021)
     */
    isShowEmployeeDialog: false,

    /**
     * Biến xác định trạng thái alert dialog.
     * CreatedBy: dbhuan (09/05/2021)
     */
    isShowAlertDialog: false,

    /**
     * Biến xác định trạng thái error dialog.
     * CreatedBy: dbhuan (09/05/2021)
     */
    isShowErrorDialog: false,

    timeOut: null,
  }),

  computed: {
    isLoading: function () {
      return this.state == StateEnum.LOADING;
    },
    isError: function () {
      return this.state == StateEnum.ERROR;
    },
  },

  methods: {
    /**
     * Lấy dữ liệu từ api.
     * CreatedBy: dbhuan (10/05/2021)
     */
    fetchEmployees() {
      this.state = StateEnum.LOADING;
      req
        .get(
          `api/v1/employees?page=${this.page}&pageSize=${this.pageSize}&filter=${this.filter}`
        )
        .then((res) => res.data)
        .then((data) => {
          this.employees = data.data;
          this.totalPages = data.totalPages;
          this.totalRecord = data.totalRecord;
          this.state = StateEnum.SUCCESS;
        })
        .catch(() => {
          this.state = StateEnum.ERROR;
        });
    },

    /**
     * Phương thức được gọi khi thay đổi input filter nhân viên.
     * @param {Element} e
     * CreatedBy: dbhuan (09/05/2021)
     */
    onChangeInputEmployeeFilter(e) {
      let val = e.target.value;
      clearTimeout(this.timeOut);
      this.timeOut = setTimeout(() => {
        this.filter = val;
        this.page = 1;
        this.fetchEmployees();
      }, 1000);
    },

    /**
     * Phương thức click button refresh.
     * CreatedBy: dbhuan (09/05/2021)
     */
    onBtnClickRefresh() {
      this.filter = "";
      this.page = 1;
      this.fetchEmployees();
    },

    /**
     * click button xuất excel.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onBtnClickExportExcel() {
      window.open(
        `https://localhost:44319/api/v1/employees/Export?page=${this.page}&pageSize=${this.pageSize}&filter=${this.filter}`,
        "_blank"
      );
    },

    /**
     * Lưu thông tin nhân viên.
     * CreatedBy: dbhuan (10/05/2021)
     */
    saveEmployee() {
      this.state = StateEnum.LOADING;
      this.employeeCodeExists = null;
      var reqConfig = {
        url: "api/v1/employees",
        method: "POST",
        data: this.employeeModify,
      };
      if (this.employeeModify.employeeId) {
        // update
        reqConfig.method = "PUT";
      }

      req(reqConfig)
        .then((res) => {
          if (res.status != 204) {
            this.setStateEmployeeDialog(false);
            this.fetchEmployees();
          }
        })
        .catch(() => {
          this.isShowErrorDialog = true;
          this.employeeCodeExists = this.employeeModify.employeeCode;
        })
        .finally(() => {
          this.state = StateEnum.SUCCESS;
        });
    },

    /**
     * Phương thức xóa nhân viên.
     * CreatedBy: dbhuan (10/05/2021)
     */
    delEmployee() {
      this.state = StateEnum.LOADING;
      this.setStateAlertDialog(false);
      req
        .delete(`api/v1/employees/${this.employeeDel.employeeId}`)
        .then((res) => {
          if (res.status == 200) {
            this.fetchEmployees();
          }
        });
    },

    /**
     * Sự kiện thay đổi trang trong phân trang.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onChangePage(page) {
      this.page = page;
      this.fetchEmployees();
    },

    /**
     * Sự kiện thay đổi số bản ghi trên trang.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onChangePageSize(pageSize) {
      this.pageSize = pageSize;
      this.fetchEmployees();
    },

    /**
     * Phương thức set trạng thái employee dialog
     * @param {Boolean} state
     * CreatedBy: dbhuan (09/05/2021)
     */
    setStateEmployeeDialog(state) {
      this.isShowEmployeeDialog = state;
    },

    showEmployeeDialog() {
      this.employeeModify = null;
      req("api/v1/employees/NewEmployeeCode")
        .then((res) => res.data)
        .then((data) => {
          this.employeeModify = {
            employeeCode: data,
          };
          this.setStateEmployeeDialog(true);
        });
      req("api/v1/employee-department")
        .then((res) => res.data)
        .then((data) => {
          this.employeeDepartments = data;
        });
    },

    /**
     * Phương thức click button sửa nhân viên.
     * CreatedBy: dbhuan (09/05/2021)
     */
    onClickBtnEditEmployee(employeeId) {
      this.employeeModify = null;
      this.setStateEmployeeDialog(true);
      req(`api/v1/employees/${employeeId}`)
        .then((res) => res.data)
        .then((data) => {
          this.employeeModify = data;
        });
      req("api/v1/employee-department")
        .then((res) => res.data)
        .then((data) => {
          this.employeeDepartments = data;
        });
    },

    /**
     * Phương thức click button xóa nhân viên.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onClickBtnDelEmployee(employee) {
      this.employeeDel = employee;
      this.setStateAlertDialog(true);
    },

    /**
     * Phương thức set trạng thái employee dialog
     * @param {Boolean} state
     * CreatedBy: dbhuan (09/05/2021)
     */
    setStateAlertDialog(state) {
      this.isShowAlertDialog = state;
    },

    formatDateDDMMYYY(dateStr) {
      return dateStr ? dayjs(dateStr).format("DD/MM/YYYY") : "Không xác định";
    },
  },

  mounted() {
    this.fetchEmployees();
  },
};
</script>
