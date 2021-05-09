<template>
  <div class="table-option">
    <button class="btn">Sửa</button>
    <div class="dropdown">
      <div class="dropdown-btn" @click.prevent="toggleDropdown">
        <button class="btn icon icon-chevron-down-blue"></button>
      </div>
      <div class="dropdown-content right" :class="{ hide: !isShow }">
        <div class="dropdown-item">Nhân bản</div>
        <div class="dropdown-item">Xóa</div>
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
  }),

  methods: {
    /**
     * Phương thức toggle trạng thái dropdown.
     * CreatedBy: dbhuan (09/05/2021)
     */
    toggleDropdown() {
      this.isShow = !this.isShow;
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
  },

  mounted() {
    document.addEventListener("click", this.close);
  },
  beforeDestroy() {
    document.removeEventListener("click", this.close);
  },
};
</script>

<style scoped>
.dropdown-btn {
  height: 16px;
}
</style>