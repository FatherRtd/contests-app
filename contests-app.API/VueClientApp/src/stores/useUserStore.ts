import { defineStore } from 'pinia'
import { computed, ref } from 'vue'
import type { User } from '@/models/User.ts'
import { currentUser } from '@/services/user/userService.ts'

export const useUserStore = defineStore('user', () => {
  const user = ref<User | undefined>()
  const isExists = computed(() => user.value != undefined)

  const loadUser = async () => {
    user.value = await currentUser()
  }

  const clear = () => {
    user.value = undefined
  }

  return {
    user,
    isExists,
    loadUser,
    clear,
  }
})
