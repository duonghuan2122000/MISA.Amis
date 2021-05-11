<template>
  <div class="table-option">
    <button class="btn" @click.prevent="onClickBtnEdit">Sửa</button>
    <div class="dropdown">
      <div class="dropdown-btn" @click.prevent="toggleDropdown">
        <button class="btn icon icon-chevron-down-blue"></button>
      </div>
      <div
        class="dropdown-content right"
        :class="{ hide: !isShow, reserve: reserve }"
      >
        <div class="dropdown-item">Nhân bản</div>
        <div class="dropdown-item" @click.prevent="onClickBtnDel">Xóa</div>
        <div class="dropdown-item">Ngưng sử dụng</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data: () => ({
    /**
     * Biến xác định trạng thái show dropdown.
     * CreatedBy: dbhuan (09/05/2021)
     */
    isShow: false,

    /**
     * Đảo ngược dropdown content.
     * CreatedBy: dbhuan (11/05/2021)
     */
    reserve: false,
  }),

  methods: {
    /**
     * Phương thức toggle trạng thái dropdown.
     * CreatedBy: dbhuan (09/05/2021)
     */
    toggleDropdown() {
      this.isShow = !this.isShow;
      if (this.isShow) {
        this.reserveDropdown();
      }
    },

    /**
     * Phương thức close dropdown.
     * CreatedBy: dbhuan (09/05/2021)
     */
    close(e) {
      if (!this.$el.contains(e.target)) {
        this.isShow = false;
      }
    },

    reserveDropdown() {
      let scrollTop = document.querySelector(".data .scroll").scrollTop;
      let topOffset = this.$el.querySelector(".dropdown").offsetTop;
      let relativeOffset = topOffset - scrollTop;
      let windowHeight = window.innerHeight;

      if (relativeOffset > windowHeight / 2) {
        this.reserve = true;
      } else {
        this.reserve = false;
      }
    },

    /**
     * click button edit.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onClickBtnEdit() {
      this.$emit("onClickBtnEdit");
    },

    /**
     * Click button xóa.
     * CreatedBy: dbhuan (10/05/2021)
     */
    onClickBtnDel() {
      this.toggleDropdown();
      this.$emit("onClickBtnDel");
    },
  },

  mounted() {
    document.addEventListener("click", this.close);
    document.querySelector('.data .scroll').addEventListener("scroll", this.reserveDropdown);
  },
  beforeDestroy() {
    document.removeEventListener("click", this.close);
    document.querySelector('.data .scroll').removeEventListener("scroll", this.reserveDropdown);
  },
};
</script>

<style scoped>
.dropdown-btn {
  height: 16px;
}
</style>