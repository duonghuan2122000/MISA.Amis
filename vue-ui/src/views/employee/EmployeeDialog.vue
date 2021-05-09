<template>
  <div class="dialog" :class="{ hide: !isShow }">
    <div class="dialog-background" @click.prevent="closeDialog"></div>
    <div class="dialog-content">
      <div class="tooltip-box">
        <div class="btn-close-dialog" @click.prevent="closeDialog">
          <div class="icon icon-close"></div>
        </div>
      </div>

      <div class="dialog-header">
        <div class="dialog-title">Thông tin nhân viên</div>
        <div class="option">
          <input type="checkbox" class="checkbox" id="is-customer" />
          <label for="is-customer"></label>
          <label style="margin-left: 8px">Là khách hàng</label>
        </div>
        <div class="option">
          <input type="checkbox" class="checkbox" id="is-provider" />
          <label for="is-provider"></label>
          <label style="margin-left: 8px">Là nhà cung cấp</label>
        </div>
      </div>

      <div class="dialog-body">
        <div class="row">
          <div class="col-6" style="padding-right: 16px">
            <div class="row">
              <div class="col-5" style="padding-right: 8px">
                <div>
                  <label class="label-input"
                    >Mã <span style="color: #f20">*</span></label
                  >
                  <input type="text" class="input" />
                </div>
              </div>
              <div class="col-7">
                <div class="con-input">
                  <label class="label-input"
                    >Tên <span style="color: #f20">*</span></label
                  >
                  <input type="text" class="input has-error" />
                  <span class="text-error">Tên không được để trống.</span>
                </div>
              </div>
            </div>
          </div>

          <div class="col-6" style="padding-left: 16px">
            <div class="row">
              <div class="col-5" style="padding-right: 16px">
                <div>
                  <label class="label-input">Ngày sinh</label>
                  <input type="date" class="input" />
                </div>
              </div>
              <div class="col-7">
                <div>
                  <label class="label-input">Giới tính</label>
                  <div class="flex-row-align-center" style="height: 32px">
                    <div
                      class="flex-row-align-center"
                      style="margin-right: 16px"
                    >
                      <input type="radio" id="male" class="radio" />
                      <label for="male"></label>
                      <label style="margin-left: 8px">Nam</label>
                    </div>
                    <div
                      class="flex-row-align-center"
                      style="margin-right: 16px"
                    >
                      <input type="radio" id="female" class="radio" />
                      <label for="female"></label>
                      <label style="margin-left: 8px">Nữ</label>
                    </div>
                    <div
                      class="flex-row-align-center"
                      style="margin-right: 16px"
                    >
                      <input type="radio" id="other" class="radio" />
                      <label for="other"></label>
                      <label style="margin-left: 8px">Khác</label>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="col-6" style="padding-right: 16px">
            <div>
              <label class="label-input"
                >Đơn vị <span style="color: #f20">*</span></label
              >
              <input type="text" class="input" />
            </div>
          </div>

          <div class="col-6" style="padding-left: 16px">
            <div class="row">
              <div class="col-7" style="padding-right: 8px">
                <div>
                  <label class="label-input">Số CMND</label>
                  <input type="text" class="input" />
                </div>
              </div>

              <div class="col-5">
                <div>
                  <label class="label-input">Ngày cấp</label>
                  <input type="date" class="input" />
                </div>
              </div>
            </div>
          </div>

          <div class="col-6" style="padding-right: 16px">
            <div>
              <div>
                <label class="label-input">Chức danh</label>
                <input type="text" class="input" />
              </div>
            </div>
          </div>

          <div class="col-6" style="padding-left: 16px">
            <div>
              <label class="label-input">Nơi cấp</label>
              <input type="text" class="input" />
            </div>
          </div>

          <div class="col-12" style="margin-top: 30px">
            <div>
              <label class="label-input">Địa chỉ</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Điện thoại di động</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Điện thoại cố định</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Email</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px"></div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Tài khoản ngân hàng</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Tên ngân hàng</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px">
            <div>
              <label class="label-input">Chi nhánh</label>
              <input type="text" class="input" />
            </div>
          </div>
          <div class="col-3" style="padding-right: 8px"></div>
        </div>
      </div>

      <div class="dialog-footer">
        <div class="dialog-footer-left">
          <button class="btn btn-secondary" @click.prevent="closeDialog">Hủy</button>
        </div>
        <div class="dialog-footer-right">
          <button class="btn btn-secondary">Cất</button>
          <button class="btn btn-primary">Cất và thêm</button>
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
    closeDialog() {
      this.$emit("onClose");
    },
  },
};
</script>