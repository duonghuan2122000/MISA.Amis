<template>
  <div>
    <Navbar />
    <Header />
    <Content />
  </div>
</template>

<script>
import Navbar from "./components/layout/Navbar.vue";
import Header from "./components/layout/Header.vue";
import Content from "./components/layout/Content.vue";
export default {
  components: {
    Navbar,
    Header,
    Content,
  },
};
</script>

<style lang="less">
//Stylesheet chung.
@font-face {
  font-family: NotoSans;
  src: url("./assets/fonts/notosans-regular.2cb88a13.woff2") format("woff2");
}

// Biến chung.
@navbar-width: 226px;

@header-height: 48px;

@icon-size: 24px;

@color-white: #fff;

// mixins
.flex-row {
  display: flex;
  flex-direction: row;
}

.flex-row-align-center {
  .flex-row();
  align-items: center;
}

.icon-bind(@position, @size: @icon-size) {
  background-position: @position;
  height: @size;
  width: @size;
}

// style chung
* {
  box-sizing: border-box;
  font-family: inherit;
  font-size: inherit;
}

html,
body {
  margin: 0;
  padding: 0;
  font-size: 13px;
  font-family: NotoSans;
  overflow-y: auto;
  scroll-behavior: smooth;
}

/* width */
::-webkit-scrollbar {
  width: 10px;
  height: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: #f1f1f1;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: #888;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: #555;
}

.icon {
  background-image: url("./assets/img/Sprites.svg");
  background-repeat: no-repeat;
  display: inline-block;

  // icon navbar.
  &.icon-navbar-dashboard {
    .icon-bind(-30px -1628px);
  }

  &.icon-navbar-cash {
    .icon-bind(-73px -1628px);
  }

  &.icon-navbar-bank {
    .icon-bind(-117px -1628px);
  }

  &.icon-navbar-pu {
    .icon-bind(-161px -1628px);
  }

  // icon header.
  &.icon-three-stripes {
    .icon-bind(-843px -30px);
    margin-left: 10px;
    cursor: pointer;
  }

  &.icon-chevron-down {
    .icon-bind(-80px -360px, 14px);
    transform: rotate(90deg);
    margin-left: 10px;
  }

  &.icon-notify {
    .icon-bind(-788px -30px);
    margin-right: 8px;
  }

  &.icon-refresh {
    .icon-bind(-423px -201px);

    &:hover {
      .icon-bind(-1097px -88px);
    }
  }

  &.icon-search {
    .icon-bind(-992px -360px, 16px);
  }

  &.icon-excel {
    .icon-bind(-704px -200px);

    &:hover {
      .icon-bind(-704px -256px);
    }
  }

  &.icon-chevron-down-blue {
    .icon-bind(-896px -359px, 16px);
  }

  &.icon-close {
    .icon-bind(-144px -144px);
  }

  &.icon-warning-48 {
    .icon-bind(-592px -456px, 48px);
  }

  &.icon-error {
    .icon-bind(-746px -456px, 48px);
  }
}

// Navbar
.navbar {
  height: 100vh;
  width: @navbar-width;
  background-color: #393a3d;

  //   Logo box
  .logo-box {
    .flex-row();
    padding: 24px;
    height: @header-height;
    align-items: center;

    .toggle {
      .icon();
      .icon-bind(-424px -86px);
      margin-right: 10px;
      cursor: pointer;
    }

    .logo-branch {
      .flex-row();
      align-items: center;

      .logo {
        background-image: url("./assets/img/Logo.svg");
        background-repeat: no-repeat;
        background-size: cover;
        height: 30px;
        width: 30px;
        margin-right: 4px;
      }

      .title {
        font-weight: bold;
        color: @color-white;
      }
    }
  }

  //   Navbar content
  &-content {
    .navbar-item {
      .flex-row();
      align-items: center;
      height: 42px;
      cursor: pointer;

      &:hover {
        background-color: rgba(255, 255, 255, 0.16);
      }

      &-icon {
        padding-left: 14px;
        margin-right: 8px;
      }

      &-text {
        color: @color-white;
      }
    }
  }
}

// Header
.header {
  position: fixed;
  left: @navbar-width;
  top: 0;
  right: 0;
  height: @header-height;
  .flex-row();
  justify-content: space-between;
  align-items: center;

  &-left {
    .flex-row();

    .header-branch {
      .flex-row();
      align-items: center;
      margin-left: 16px;
      cursor: pointer;

      .title {
        font-weight: bold;
      }
    }
  }

  &-right {
    .flex-row();
    align-items: center;
    margin-right: 30px;
  }
}

// Content
.content {
  position: fixed;
  left: @navbar-width;
  top: @header-height;
  right: 0;
  bottom: 0;
  background-color: #f4f5f6;
  display: flex;
  padding: 0 30px 16px 30px;
  flex-direction: column;

  // title box
  .title-box {
    .flex-row();
    align-items: center;
    justify-content: space-between;
    height: 64px;
    flex-shrink: 0;

    .title {
      font-size: 24px;
      font-weight: bold;
    }
  }

  .toolbar-box {
    .flex-row();
    align-items: center;
    justify-content: flex-end;
    background-color: @color-white;
    padding: 16px;
    height: 64px;
    flex-shrink: 0;
  }

  .data {
    flex: 1;
    background-color: @color-white;
    padding-bottom: 16px;
    overflow: hidden;

    .scroll {
      padding: 0 16px;
      height: 100%;
      overflow: auto;
    }

    .table-option {
      .flex-row();
      align-items: center;

      .btn {
        padding-left: 8px;
        padding-right: 8px;
        color: #0075c0;
        font-weight: bold;
      }
    }
  }

  .divider {
    height: 4px;
    background-color: #f4f5f6;
  }

  .pagination {
    .flex-row();
    height: 42px;
    justify-content: space-between;
    align-items: center;
    background-color: @color-white;
    padding: 16px;

    .pagination-right {
      .flex-row();

      .pager {
        .flex-row();

        .page {
          padding-left: 8px;
          padding-right: 8px;
          text-decoration: none;
          cursor: pointer;
          color: #000;

          &.active {
            border: 1px solid #ccc;
            padding-left: 4px;
            padding-right: 4px;
            font-weight: bold;
          }

          &.disable {
            cursor: not-allowed;
          }
        }
      }
    }
  }

  .flex-center {
    height: 100%;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: center;
    position: absolute;
    top: 0;
    left: 0;
    bottom: 0;
    right: 0;
    z-index: 2000;

    .loader {
      background-image: url("./assets/loading.svg");
      background-position: center;
      background-size: contain;
      background-repeat: no-repeat;
      height: 32px;
      width: 32px;
      transform: rotate(45 16 16);
    }
  }
}

// components.

// button.
.btn {
  height: 40px;
  padding-left: 24px;
  padding-right: 24px;
  line-height: 40px;
  outline: none;
  background-color: transparent;
  cursor: pointer;
  font-weight: bold;
  border: none;
  border-radius: 4px;

  &.btn-primary {
    background-color: #2ca01c;
    color: @color-white;
    font-weight: bold;
    border: 1px solid #ccc;

    &:hover {
      background-color: #34aa24;
    }
  }

  &.btn-secondary {
    background-color: transparent;
    border: 1px solid #ccc;

    &:hover {
      background-color: #f4f5f6;
    }
  }
}

// input
.input {
  height: 32px;
  outline: none;
  border: 1px solid #ccc;
  padding-left: 12px;
  border-radius: 4px;
  width: 100%;

  &:focus {
    border-color: #2ca01c;
  }

  &.has-icon {
    padding-right: 28px;
  }

  &.has-error {
    border-color: #f20;

    & + .text-error {
      display: none;
    }

    &:hover + .text-error {
      display: inline-block;
      position: absolute;
      top: 100%;
      left: 0;
      background-color: #38393d;
      color: @color-white;
      padding: 8px;
      z-index: 10;
    }
  }
}

.con-input {
  position: relative;

  .icon-input {
    position: absolute;
    right: 8px;
    top: 8px;
  }
}

.label-input {
  display: inline-block;
  margin-top: 8px;
  margin-bottom: 4px;
  font-weight: bold;
}

// checkbox
.checkbox {
  display: none;

  & + label {
    background-color: #fafafa;
    border: 1px solid #cacece;
    box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
      inset 0px -15px 10px -12px rgba(0, 0, 0, 0.05);
    height: 18px;
    width: 18px;
    border-radius: 3px;
    display: inline-block;
    position: relative;

    &:active {
      box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
        inset 0px 1px 3px rgba(0, 0, 0, 0.1);
    }
  }

  &:checked + label {
    border: 1px solid #adb8c0;
    box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
      inset 0px -15px 10px -12px rgba(0, 0, 0, 0.05),
      inset 15px 10px -12px rgba(255, 255, 255, 0.1);
    color: #99a1a7;

    &:active {
      box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
        inset 0px 1px 3px rgba(0, 0, 0, 0.1);
    }

    &::after {
      .icon();
      .icon-bind(-1224px -360px, 16px);
      content: "";
      font-size: 14px;
      position: absolute;
      top: 0;
      left: 0;
    }
  }
}

.radio {
  display: none;

  & + label {
    -webkit-appearance: none;
    background-color: #fafafa;
    border: 1px solid #cacece;
    height: 18px;
    width: 18px;
    border-radius: 50px;
    display: inline-block;
    position: relative;

    &:active {
      box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
        inset 0px 1px 3px rgba(0, 0, 0, 0.1);
    }
  }

  &:checked {
    & + label {
      border: 1px solid #2ca01c;

      &:after {
        content: " ";
        width: 10px;
        height: 10px;
        border-radius: 50px;
        position: absolute;
        top: 3px;
        background: #2ca01c;
        left: 3px;
      }

      &:active {
        box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
          inset 0px 1px 3px rgba(0, 0, 0, 0.1);
      }
    }
  }
}

// table
.table {
  width: 100%;
  border-collapse: collapse;
  // background-color: @color-white;

  th,
  td {
    border: 1px solid #ccc;
    text-align: left;
    padding: 0 16px;
  }

  thead {
    tr {
      height: 32px;
      th {
        background-color: #f4f5f6;
      }
    }
  }

  tbody {
    tr {
      height: 48px;
    }
  }
}

// dialog
.dialog {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  align-items: center;
  .dialog-background {
    position: absolute;
    height: 100%;
    width: 100%;
    background-color: rgba(0, 0, 0, 0.4);
  }

  .dialog-content {
    z-index: 1000;
    background-color: @color-white;
    margin: 20px auto;
    width: 900px;
    position: relative;

    .tooltip-box {
      display: inline-block;
      position: absolute;
      right: 0;
      top: 0;

      .btn-close-dialog {
        height: 40px;
        width: 40px;
        display: flex;
        justify-content: center;
        align-items: center;
        cursor: pointer;
      }
    }

    .dialog-header {
      .flex-row();
      align-items: center;
      height: 52px;
      padding-left: 32px;
      padding-right: 32px;

      .dialog-title {
        font-size: 24px;
        font-weight: bold;
      }

      .option {
        .flex-row();
        align-items: center;
        padding-left: 16px;
        padding-right: 16px;
      }
    }

    .dialog-body {
      padding-left: 32px;
      padding-right: 32px;
      padding-bottom: 32px;
    }

    .dialog-footer {
      .flex-row();
      justify-content: space-between;
      align-items: center;
      height: 72px;
      margin-left: 32px;
      margin-right: 32px;
      border-top: 1px solid #ccc;
    }
  }

  &.hide {
    display: none;
  }
}

// dropdown
.dropdown {
  position: relative;

  .dropdown-btn {
  }

  .dropdown-content {
    position: absolute;
    background-color: @color-white;
    border: 1px solid #ccc;
    white-space: nowrap;
    z-index: 20;

    &.hide {
      display: none;
    }

    &.right {
      right: 0;
    }

    .dropdown-item {
      height: 32px;
      line-height: 32px;
      padding-left: 12px;
      padding-right: 12px;

      &:hover {
        background-color: #f4f5f6;
        color: #2ca01c;
        cursor: pointer;
      }
    }
  }
}

// grid view
.col-1 {
  width: 8.33%;
  flex: none;
}
.col-2 {
  width: 16.66%;
  flex: none;
}
.col-3 {
  width: 25%;
  flex: none;
}
.col-4 {
  width: 33.33%;
  flex: none;
}
.col-5 {
  width: 41.66%;
  flex: none;
}
.col-6 {
  width: 50%;
  flex: none;
}
.col-7 {
  width: 58.33%;
  flex: none;
}
.col-8 {
  width: 66.66%;
  flex: none;
}
.col-9 {
  width: 75%;
  flex: none;
}
.col-10 {
  width: 83.33%;
  flex: none;
}
.col-11 {
  width: 91.66%;
  flex: none;
}
.col-12 {
  width: 100%;
  flex: none;
}

.row {
  .flex-row();
  flex-wrap: wrap;
}
</style>
