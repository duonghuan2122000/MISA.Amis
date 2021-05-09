<template>
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
</template>

<script>
export default {
  props: {
    /**
     * Prop tổng số trang.
     * CreatedBy: dbhuan (09/05/2021)
     */
    totalPages: {
      type: Number,
      default: 0,
    },

    /**
     * Prop trang hiện tại
     * CreatedBy: dbhuan (09/05/2021)
     */
    page: {
      type: Number,
      default: 1,
    },
  },

  computed: {},
};
</script>