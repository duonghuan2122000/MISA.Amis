<template>
  <div class="pagination">
    <div>
      Tổng số: <b>{{ totalRecord }}</b> bản ghi
    </div>
    <div class="pagination-right">
      <Autcomplete />
      <div class="pager">
        <router-link
          :to="{ name: 'employee', query: { page: page - 1 } }"
          class="page"
          :class="{ disable: page == 1 }"
          >Trước</router-link
        >

        <router-link
          :to="{ name: 'employee', query: { page: 1 } }"
          class="page"
          :class="{ active: page == 1 }"
          >1</router-link
        >

        <div v-if="page > 3" class="page disable">...</div>

        <router-link
          :to="{ name: 'employee', query: { page: p } }"
          v-for="p in pages"
          :key="p"
          class="page"
          :class="{ active: page == p }"
          >{{ p }}</router-link
        >

        <div v-if="page < totalPages - 3" class="page disable">...</div>

        <router-link
          :to="{ name: 'employee', query: { page: totalPages } }"
          class="page"
          :class="{ active: page == totalPages }"
        >
          {{ totalPages }}
        </router-link>

        <router-link
          :to="{ name: 'employee', query: { page: page + 1 } }"
          class="page"
          :class="{ disable: page == totalPages }"
          >Sau</router-link
        >
      </div>
    </div>
  </div>
</template>

<script>
import Autcomplete from "../../components/Autocomplete.vue";
export default {
  components: {
    Autcomplete,
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