import { createRouter, createWebHistory } from 'vue-router'
import { routes } from '@/router/routes.ts'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

router.beforeEach((to, from, next) => {
  if (to.matched.length === 0) {
    next(from.fullPath)
  } else {
    next()
  }
})

export default router
