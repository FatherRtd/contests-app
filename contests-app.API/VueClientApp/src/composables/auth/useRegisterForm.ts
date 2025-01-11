import { ElNotification } from 'element-plus'
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import type { RegisterUserRequest } from '@/services/user/models/RegisterUserRequest.ts'
import { register } from '@/services/user/userService.ts'
import { routeNames } from '@/router/routes.ts'

export function useRegisterForm() {
  const formData = reactive<RegisterUserRequest>({
    name: '',
    surName: '',
    login: '',
    password: '',
  })

  const router = useRouter()

  const submit = async () => {
    try {
      await register(formData)

      await router.push({ name: routeNames.login })
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
