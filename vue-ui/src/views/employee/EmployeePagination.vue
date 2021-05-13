<template>
  <div class="pagination">
    <div>
      Tổng số: <b>{{ totalRecord }}</b> bản ghi
    </div>
    <div class="pagination-right">
      <PageSizeAutocomplete
        :value="pageSize"
        :suggestions="[
          { value: 10, text: '10 bản ghi trên trang' },
          { value: 20, text: '20 bản ghi trên trang' },
          { value: 30, text: '30 bản ghi trên trang' },
          { value: 50, text: '50 bản ghi trên trang' },
          { value: 100, text: '100 bản ghi trên trang' },
        ]"
        @update:value="$emit('update:pageSize', $event)"
      />
      <div class="pager" v-if="totalPages > 1">
        <div
          class="page"
          :class="{ disable: page == 1 }"
          @click.prevent="$emit('onChangePage', page - 1)"
        >
          Trước
        </div>

        <div
          class="page"
          :class="{ active: page == 1 }"
          @click.prevent="$emit('onChangePage', 1)"
        >
          1
        </div>

        <div v-if="page > 3" class="page disable">...</div>

        <div
          v-for="p in pages"
          :key="p"
          class="page"
          :class="{ active: page == p }"
          @click.prevent="$emit('onChangePage', p)"
        >
          {{ p }}
        </div>

        <div v-if="page < totalPages - 3" class="page disable">...</div>

        <div
          class="page"
          :class="{ active: page == totalPages }"
          @click.prevent="$emit('onChangePage', totalPages)"
        >
          {{ totalPages }}
        </div>

        <div
          class="page"
          :class="{ disable: page == totalPages }"
          @click.prevent="$emit('onChangePage', page + 1)"
        >
          Sau
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import PageSizeAutocomplete from "./PageSizeAutcomplete.vue";
export default {
  components: {
    PageSizeAutocomplete,
  },
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
     * Tổng số bản ghi
     * CreatedBy: dbhuan (10/05/2021)
     */
    totalRecord: {
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

    /**
     * Tổng số bản ghi trên trang.
     * CreatedBy: dbhuan (11/05/2021)
     */
    pageSize: {
      type: Number,
      default: 1,
    },
  },

  computed: {
    pages: function () {
      let ps = [];
      let start = this.page > 3 ? this.page - 1 : 2;
      let end =
        this.page < this.totalPages - 3 ? this.page + 1 : this.totalPages - 1;
      for (let i = start; i <= end; i++) ps.push(i);
      return ps;
    },
  },
};
</script>