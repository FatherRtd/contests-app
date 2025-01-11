import type { RouteRecordRaw } from 'vue-router'

const routeNames = {
  home: 'home',
}

const HomeView = import('@/views/HomeView.vue')

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    name: routeNames.home,
    component: HomeView,
  },
]

export { routes, routeNames }
