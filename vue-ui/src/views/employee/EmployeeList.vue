<template>
  <div>
    <div class="content" v-if="isLoading">
      <div class="loading">
        <div class="loader"></div>
      </div>
    </div>

    <div class="content" v-else-if="isSuccess">
      <div class="title-box">
        <div class="title">Nhân viên</div>
        <div class="toolbar">
          <button class="btn btn-primary" @click="setStateEmployeeDialog(true)">
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
          <div
            class="icon-input icon icon-search"
            @click="onBtnClickRefresh"
          ></div>
        </div>
        <div class="icon icon-refresh" style="margin-left: 8px"></div>
        <div class="icon icon-excel" style="margin-left: 8px"></div>
      </div>

      <div class="data">
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
                <td>{{ formatDateDDMMYYY(e.dateOfBirth) }}</td>
                <td>{{ e.identityNumber }}</td>
                <td>{{ e.employeePosition }}</td>
                <td>{{ e.employeeDepartmentName }}</td>
                <td></td>
                <td></td>
                <td></td>
                <td>
                  <EmployeeDropdown
                    @onClickBtnEdit="onClickBtnEditEmployee(e.employeeId)"
                  />
                </td>
              </tr>
            </tbody>
          </table>
        </div>

        <div class="divider"></div>

        <EmployeePagination
          :page="page"
          :totalPages="totalPages"
          :totalRecord="totalRecord"
        />
      </div>
    </div>

    <EmployeeDialog
      :isShow="isShowEmployeeDialog"
      :employee.sync="employeeModify"
      @onClose="setStateEmployeeDialog(false)"
    />

    <AlertDialog
      :isShow="isShowAlertDialog"
      @onClose="setStateEmployeeDialog(false)"
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
export default {
  components: {
    EmployeePagination,
    EmployeeDropdown,
    EmployeeDialog,
    AlertDialog,
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
     * Thông tin nhân viên cần thêm hoặc sửa.
     * CreatedBy: dbhuan (10/05/2021)
     */
    employeeModify: null,

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

    timeOut: null,
  }),

  computed: {
    isLoading: function () {
      return this.state == StateEnum.LOADING;
    },
    isSuccess: function () {
      return this.state == StateEnum.SUCCESS;
    },
  },

  methods: {
    /**
     * Phương thức khởi tạo giá trị.
     * CreatedBy: dbhuan (10/05/2021)
     */
    initialData() {
      if (this.$route.query && this.$route.query.page) {
        this.page = parseInt(this.$route.query.page);
      }
    },

    /**
     * Lấy dữ liệu từ api.
     * CreatedBy: dbhuan (10/05/2021)
     */
    fetchEmployees() {
      this.state = StateEnum.LOADING;
      req(
        `api/v1/employees?page=${this.page}&pageSize=${this.pageSize}&filter=${this.filter}`
      )
        .then((res) => res.data)
        .then((data) => {
          this.employees = data.data;
          this.totalPages = data.totalPages;
          this.totalRecord = data.totalRecord;
          this.state = StateEnum.SUCCESS;
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
        this.fetchEmployees();
      }, 1000);
    },

    /**
     * Phương thức click button refresh.
     * CreatedBy: dbhuan (09/05/2021)
     */
    onBtnClickRefresh() {
      this.filter = "";
      this.$router.push({ query: { ...this.$route.query, page: 1 } });
    },

    /**
     * Phương thức set trạng thái employee dialog
     * @param {Boolean} state
     * CreatedBy: dbhuan (09/05/2021)
     */
    setStateEmployeeDialog(state) {
      this.isShowEmployeeDialog = state;
    },

    /**
     * Phương thức click button sửa nhân viên.
     * CreatedBy: dbhuan (09/05/2021)
     */
    onClickBtnEditEmployee(employeeId) {
      this.setStateEmployeeDialog(true);
      req(`api/v1/employees/${employeeId}`)
        .then((res) => res.data)
        .then((data) => {
          this.employeeModify = data;
        });
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

  watch: {
    "$route.query.page": function () {
      this.initialData();
      this.fetchEmployees();
    },
  },

  mounted() {
    this.initialData();
    this.fetchEmployees();
  },
};
</script>