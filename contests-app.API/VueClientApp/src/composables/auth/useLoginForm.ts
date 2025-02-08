import { ElNotification } from 'element-plus'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useUserStore } from '@/stores/useUserStore.ts'
import type { LoginUserRequest } from '@/services/user/models/LoginUserRequest.ts'
import { login } from '@/services/user/userService.ts'
import { routeNames } from '@/router/routes.ts'

export function useLoginForm() {
  const router = useRouter()

  const userStore = useUserStore()

  const formData = reactive<LoginUserRequest>({
    login: '',
    password: '',
  })

  const submit = async () => {
    try {
      await login(formData)

      await router.push({ name: routeNames.home })

      await userStore.loadUser()
    } catch (e) {
      const error = e as Error

      ElNotification({
        title: 'Ошибка',
        message: error.message,
        type: 'error',
        zIndex: 999999,
      })
    }
  }

  return { formData, submit }
}
