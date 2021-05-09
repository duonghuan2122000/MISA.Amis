import Vue from 'vue'
import VueRouter from 'vue-router'
import EmployeeList from '../views/employee/EmployeeList.vue';

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'employee',
    component: EmployeeList
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
