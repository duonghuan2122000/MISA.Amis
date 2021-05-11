<template>
  <div class="dropdown autocomplete" @blur="isShow = false">
    <div class="dropdown-btn con-input">
      <input
        type="text"
        class="input has-icon"
        readonly
        :value="suggestions[current].text"
        @focus="showSuggestion"
        @keydown.up="up"
        @keydown.down="down"
        @keydown.enter="enter"
      />
      <div
        class="icon-input icon-dropdown-box"
        @click.prevent="toggleSuggestion"
      >
        <div class="icon icon-arrow-dropdown"></div>
      </div>
    </div>
    <div class="dropdown-content reserve" :class="{ hide: !isShow }">
      <div
        v-for="(suggestion, i) in suggestions"
        :key="i"
        class="dropdown-item"
        :class="{ active: current == i }"
        @click.prevent="clickSuggestion(suggestion, i)"
      >
        {{ suggestion.text }}
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
      type: Number,
      default: null,
    },
  },
  data: () => ({
    isShow: false,
    current: 0,
  }),
  methods: {
    toggleSuggestion() {
      if (this.isShow) {
        this.isShow = false;
      } else {
        this.showSuggestion();
      }
    },
    showSuggestion() {
      this.$el.querySelector("input").focus();
      this.isShow = true;
    },
    enter() {
      this.$emit("update:value", this.suggestions[this.current].value);
      this.isShow = false;
      this.$el.querySelector("input").blur();
    },
    up() {
      if (this.current > 0) this.current--;
    },
    down() {
      if (this.current < this.suggestions.length - 1) this.current++;
    },
    clickSuggestion(suggestion, index) {
      this.current = index;
      this.isShow = false;
      this.$emit("update:value", suggestion.value);
      this.$el.querySelector("input").blur();
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

  //   watch: {
  //     value: function () {
  //       console.log("watch");
  //       if (this.value) {
  //         let index = this.suggestions.findIndex(
  //           (suggestion) => suggestion.value == this.value
  //         );
  //         if (index != -1) {
  //           this.current = index;
  //           this.valueText = this.suggestions[this.current].text;
  //         } else {
  //           this.current = 0;
  //           this.valueText = "";
  //         }
  //       } else {
  //         this.current = 0;
  //         this.valueText = "";
  //       }
  //     },
  //   },

  mounted() {
    document.addEventListener("click", this.close);
  },

  beforeDestroy() {
    document.removeEventListener("click", this.close);
  },
};
</script>