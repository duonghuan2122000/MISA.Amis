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

<style>
@font-face {
  font-family: NotoSans;
  src: url("assets/fonts/notosans-regular.2cb88a13.woff2") format("woff2");
}

.flex-row {
  display: flex;
  flex-direction: row;
}

.flex-row-align-center {
  display: flex;
  flex-direction: row;
  align-items: center;
}

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
  background-image: url("assets/img/Sprites.svg");
  background-repeat: no-repeat;
  display: inline-block;
}

.icon.icon-navbar-dashboard {
  background-position: -30px -1628px;
  height: 24px;
  width: 24px;
}

.icon.icon-navbar-cash {
  background-position: -73px -1628px;
  height: 24px;
  width: 24px;
}

.icon.icon-navbar-bank {
  background-position: -117px -1628px;
  height: 24px;
  width: 24px;
}

.icon.icon-navbar-pu {
  background-position: -161px -1628px;
  height: 24px;
  width: 24px;
}

.icon.icon-three-stripes {
  background-position: -843px -30px;
  height: 24px;
  width: 24px;
  margin-left: 10px;
  cursor: pointer;
}

.icon.icon-chevron-down {
  background-position: -80px -360px;
  height: 14px;
  width: 14px;
  transform: rotate(90deg);
  margin-left: 10px;
}

.icon.icon-notify {
  background-position: -788px -30px;
  height: 24px;
  width: 24px;
  margin-right: 8px;
}

.icon.icon-refresh {
  background-position: -423px -201px;
  height: 24px;
  width: 24px;
}

.icon.icon-refresh:hover {
  background-position: -1097px -88px;
  height: 24px;
  width: 24px;
}

.icon.icon-search {
  background-position: -992px -360px;
  height: 16px;
  width: 16px;
}

.icon.icon-excel {
  background-position: -704px -200px;
  height: 24px;
  width: 24px;
}

.icon.icon-excel:hover {
  background-position: -704px -256px;
  height: 24px;
  width: 24px;
}

.icon.icon-chevron-down-blue {
  background-position: -896px -359px;
  height: 16px;
  width: 16px;
}

.icon.icon-close {
  background-position: -144px -144px;
  height: 24px;
  width: 24px;
}

.icon.icon-warning-48 {
  background-position: -592px -456px;
  height: 48px;
  width: 48px;
}

.navbar {
  height: 100vh;
  width: 226px;
  background-color: #393a3d;
}

.navbar .logo-box {
  display: flex;
  flex-direction: row;
  padding: 24px;
  height: 48px;
  align-items: center;
}

.navbar .logo-box .toggle {
  background-image: url("assets/img/Sprites.svg");
  background-repeat: no-repeat;
  display: inline-block;
  background-position: -424px -86px;
  height: 24px;
  width: 24px;
  margin-right: 10px;
  cursor: pointer;
}

.navbar .logo-box .toggle.icon-navbar-dashboard {
  background-position: -30px -1628px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-navbar-cash {
  background-position: -73px -1628px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-navbar-bank {
  background-position: -117px -1628px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-navbar-pu {
  background-position: -161px -1628px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-three-stripes {
  background-position: -843px -30px;
  height: 24px;
  width: 24px;
  margin-left: 10px;
  cursor: pointer;
}

.navbar .logo-box .toggle.icon-chevron-down {
  background-position: -80px -360px;
  height: 14px;
  width: 14px;
  transform: rotate(90deg);
  margin-left: 10px;
}

.navbar .logo-box .toggle.icon-notify {
  background-position: -788px -30px;
  height: 24px;
  width: 24px;
  margin-right: 8px;
}

.navbar .logo-box .toggle.icon-refresh {
  background-position: -423px -201px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-refresh:hover {
  background-position: -1097px -88px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-search {
  background-position: -992px -360px;
  height: 16px;
  width: 16px;
}

.navbar .logo-box .toggle.icon-excel {
  background-position: -704px -200px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-excel:hover {
  background-position: -704px -256px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-chevron-down-blue {
  background-position: -896px -359px;
  height: 16px;
  width: 16px;
}

.navbar .logo-box .toggle.icon-close {
  background-position: -144px -144px;
  height: 24px;
  width: 24px;
}

.navbar .logo-box .toggle.icon-warning-48 {
  background-position: -592px -456px;
  height: 48px;
  width: 48px;
}

.navbar .logo-box .logo-branch {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.navbar .logo-box .logo-branch .logo {
  background-image: url("assets/img/Logo.svg");
  background-repeat: no-repeat;
  background-size: cover;
  height: 30px;
  width: 30px;
  margin-right: 4px;
}

.navbar .logo-box .logo-branch .title {
  font-weight: bold;
  color: #fff;
}

.navbar-content .navbar-item {
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 42px;
  cursor: pointer;
}

.navbar-content .navbar-item:hover {
  background-color: rgba(255, 255, 255, 0.16);
}

.navbar-content .navbar-item-icon {
  padding-left: 14px;
  margin-right: 8px;
}

.navbar-content .navbar-item-text {
  color: #fff;
}

.header {
  position: fixed;
  left: 226px;
  top: 0;
  right: 0;
  height: 48px;
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.header-left {
  display: flex;
  flex-direction: row;
}

.header-left .header-branch {
  display: flex;
  flex-direction: row;
  align-items: center;
  margin-left: 16px;
  cursor: pointer;
}

.header-left .header-branch .title {
  font-weight: bold;
}

.header-right {
  display: flex;
  flex-direction: row;
  align-items: center;
  margin-right: 30px;
}

.content {
  position: fixed;
  left: 226px;
  top: 48px;
  right: 0;
  bottom: 0;
  background-color: #f4f5f6;
  display: flex;
  padding: 0 30px 16px 30px;
  flex-direction: column;
}

.content .title-box {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  height: 64px;
}

.content .title-box .title {
  font-size: 24px;
  font-weight: bold;
}

.content .toolbar-box {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: flex-end;
  background-color: #fff;
  padding: 16px;
  height: 64px;
}

.content .scroll {
  flex: 1;
  overflow: auto;
  background-color: #fff;
  padding: 0 16px 16px 16px;
}

.content .scroll .table-option {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.content .scroll .table-option .btn {
  padding-left: 8px;
  padding-right: 8px;
  color: #0075c0;
  font-weight: bold;
}

.content .divider {
  height: 4px;
  background-color: #f4f5f6;
  margin: 0 16px;
}

.content .pagination {
  display: flex;
  flex-direction: row;
  height: 42px;
  justify-content: space-between;
  align-items: center;
  background-color: #fff;
  padding: 16px;
}

.content .pagination .pagination-right {
  display: flex;
  flex-direction: row;
}

.content .pagination .pagination-right .pager {
  display: flex;
  flex-direction: row;
}

.content .pagination .pagination-right .pager .page {
  padding-left: 8px;
  padding-right: 8px;
  text-decoration: none;
  cursor: pointer;
}

.content .pagination .pagination-right .pager .page.active {
  border: 1px solid #ccc;
  padding-left: 4px;
  padding-right: 4px;
}

.content .pagination .pagination-right .pager .page.disable {
  cursor: not-allowed;
}

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
}

.btn.btn-primary {
  background-color: #2ca01c;
  color: #fff;
  font-weight: bold;
  border: 1px solid #ccc;
}

.btn.btn-primary:hover {
  background-color: #34aa24;
}

.btn.btn-secondary {
  background-color: transparent;
  border: 1px solid #ccc;
}

.btn.btn-secondary:hover {
  background-color: #f4f5f6;
}

.input {
  height: 32px;
  outline: none;
  border: 1px solid #ccc;
  padding-left: 12px;
  border-radius: 4px;
  width: 100%;
}

.input:focus {
  border-color: #2ca01c;
}

.input.has-icon {
  padding-right: 28px;
}

.input.has-error {
  border-color: #f20;
}

.input.has-error + .text-error {
  display: none;
}

.input.has-error:hover + .text-error {
  display: inline-block;
  position: absolute;
  top: 100%;
  left: 0;
  background-color: #38393d;
  color: #fff;
  padding: 8px;
}

.con-input {
  position: relative;
}

.con-input .icon-input {
  position: absolute;
  right: 8px;
  top: 8px;
}

.label-input {
  display: inline-block;
  margin-top: 8px;
  margin-bottom: 4px;
  font-weight: bold;
}

.checkbox {
  display: none;
}

.checkbox + label {
  background-color: #fafafa;
  border: 1px solid #cacece;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px -15px 10px -12px rgba(0, 0, 0, 0.05);
  height: 18px;
  width: 18px;
  border-radius: 3px;
  display: inline-block;
  position: relative;
}

.checkbox + label:active {
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px 1px 3px rgba(0, 0, 0, 0.1);
}

.checkbox:checked + label {
  border: 1px solid #adb8c0;
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px -15px 10px -12px rgba(0, 0, 0, 0.05),
    inset 15px 10px -12px rgba(255, 255, 255, 0.1);
  color: #99a1a7;
}

.checkbox:checked + label:active {
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px 1px 3px rgba(0, 0, 0, 0.1);
}

.checkbox:checked + label::after {
  background-image: url("assets/img/Sprites.svg");
  background-repeat: no-repeat;
  display: inline-block;
  background-position: -1224px -360px;
  height: 16px;
  width: 16px;
  content: "";
  font-size: 14px;
  position: absolute;
  top: 0;
  left: 0;
}

.checkbox:checked + label::after.icon-navbar-dashboard {
  background-position: -30px -1628px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-navbar-cash {
  background-position: -73px -1628px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-navbar-bank {
  background-position: -117px -1628px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-navbar-pu {
  background-position: -161px -1628px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-three-stripes {
  background-position: -843px -30px;
  height: 24px;
  width: 24px;
  margin-left: 10px;
  cursor: pointer;
}

.checkbox:checked + label::after.icon-chevron-down {
  background-position: -80px -360px;
  height: 14px;
  width: 14px;
  transform: rotate(90deg);
  margin-left: 10px;
}

.checkbox:checked + label::after.icon-notify {
  background-position: -788px -30px;
  height: 24px;
  width: 24px;
  margin-right: 8px;
}

.checkbox:checked + label::after.icon-refresh {
  background-position: -423px -201px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-refresh:hover {
  background-position: -1097px -88px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-search {
  background-position: -992px -360px;
  height: 16px;
  width: 16px;
}

.checkbox:checked + label::after.icon-excel {
  background-position: -704px -200px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-excel:hover {
  background-position: -704px -256px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-chevron-down-blue {
  background-position: -896px -359px;
  height: 16px;
  width: 16px;
}

.checkbox:checked + label::after.icon-close {
  background-position: -144px -144px;
  height: 24px;
  width: 24px;
}

.checkbox:checked + label::after.icon-warning-48 {
  background-position: -592px -456px;
  height: 48px;
  width: 48px;
}

.radio {
  display: none;
}

.radio + label {
  -webkit-appearance: none;
  background-color: #fafafa;
  border: 1px solid #cacece;
  height: 18px;
  width: 18px;
  border-radius: 50px;
  display: inline-block;
  position: relative;
}

.radio + label:active {
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px 1px 3px rgba(0, 0, 0, 0.1);
}

.radio:checked + label {
  border: 1px solid #2ca01c;
}

.radio:checked + label:after {
  content: " ";
  width: 10px;
  height: 10px;
  border-radius: 50px;
  position: absolute;
  top: 3px;
  background: #2ca01c;
  left: 3px;
}

.radio:checked + label:active {
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.05),
    inset 0px 1px 3px rgba(0, 0, 0, 0.1);
}

.table {
  width: 100%;
  border-collapse: collapse;
  background-color: #fff;
}

.table th,
.table td {
  border: 1px solid #ccc;
  text-align: left;
  padding: 0 16px;
}

.table thead tr {
  height: 32px;
}

.table thead tr th {
  background-color: #f4f5f6;
}

.table tbody tr {
  height: 48px;
}

.dialog {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

.dialog .dialog-background {
  position: absolute;
  height: 100%;
  width: 100%;
  background-color: rgba(0, 0, 0, 0.4);
}

.dialog .dialog-content {
  z-index: 1000;
  background-color: #fff;
  margin: 20px auto;
  width: 900px;
  position: relative;
}

.dialog .dialog-content .tooltip-box {
  display: inline-block;
  position: absolute;
  right: 0;
  top: 0;
}

.dialog .dialog-content .tooltip-box .btn-close-dialog {
  height: 40px;
  width: 40px;
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
}

.dialog .dialog-content .dialog-header {
  display: flex;
  flex-direction: row;
  align-items: center;
  height: 52px;
  padding-left: 32px;
  padding-right: 32px;
}

.dialog .dialog-content .dialog-header .dialog-title {
  font-size: 24px;
  font-weight: bold;
}

.dialog .dialog-content .dialog-header .option {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding-left: 16px;
  padding-right: 16px;
}

.dialog .dialog-content .dialog-body {
  padding-left: 32px;
  padding-right: 32px;
  padding-bottom: 32px;
}

.dialog .dialog-content .dialog-footer {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  height: 72px;
  margin-left: 32px;
  margin-right: 32px;
  border-top: 1px solid #ccc;
}

.dialog.hide {
  display: none;
}

.dropdown {
  position: relative;
}

.dropdown .dropdown-content {
  position: absolute;
  background-color: #fff;
  border: 1px solid #ccc;
  white-space: nowrap;
  z-index: 20;
}

.dropdown .dropdown-content.hide {
  display: none;
}

.dropdown .dropdown-content.right {
  right: 0;
}

.dropdown .dropdown-content .dropdown-item {
  height: 32px;
  line-height: 32px;
  padding-left: 12px;
  padding-right: 12px;
}

.dropdown .dropdown-content .dropdown-item:hover {
  background-color: #f4f5f6;
  color: #2ca01c;
  cursor: pointer;
}

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
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}
</style>