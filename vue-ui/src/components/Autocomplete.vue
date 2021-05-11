<template>
  <div class="dropdown autocomplete">
    <div class="dropdown-btn">
      <input type="text" />
    </div>
    <div class="dropdown-content">
      <div
        v-for="(suggestion, i) in suggestions"
        :key="i"
        class="dropdown-item"
      >
        {{ suggestion }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    suggestions: {
      type: Array,
      required: true,
    },
    value: {
      type: String,
    },
  },
  data: () => ({
    isShow: false,
    current: 0,
  }),
  methods: {
    enter() {
      this.$emit("update:value", this.suggestions[this.current]);
      this.isShow = false;
    },
    up(){
      if(this.current > 0) this.current--;
    },
    down(){
      if(this.current < this.suggestions.length - 1) this.current++;
    }
  },
};
</script>