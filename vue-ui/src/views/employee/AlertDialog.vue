<template>
  <div class="dialog" :class="{ hide: !isShow }">
    <div class="dialog-background"></div>
    <div class="dialog-content" style="width: 444px">
      <div class="dialog-body">
        <div class="flex-row-align-center" style="padding-top: 32px">
          <div class="icon icon-warning-48"></div>
          <div style="margin-left: 16px">
            Bạn có thực sự muốn xóa nhân viên &lt;123&gt; không ?
          </div>
        </div>
      </div>
      <div class="dialog-footer">
        <div class="dialog-footer-left">
          <button class="btn btn-secondary" @click.prevent="closeDialog">
            Không
          </button>
        </div>
        <div class="dialog-footer-right">
          <button class="btn btn-primary">Có</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    /**
     * Prop xác định trạng thái dialog.
     * CreatedBy: dbhuan (09/05/2021)
     */
    isShow: {
      type: Boolean,
      default: false,
    },
  },

  methods: {
    /**
     * Phương thức đóng dialog.
     * CreatedBy: dbhuan (09/05/2021)
     */
    closeDialog() {
      this.$emit("onClose");
    },
  },
};
</script>