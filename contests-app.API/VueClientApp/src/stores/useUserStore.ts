import { defineStore } from 'pinia'
import { computed, ref } from 'vue'
import type { User } from '@/models/User.ts'
import { currentUser } from '@/services/user/userService.ts'

export const useUserStore = defineStore('user', () => {
  const user = ref<User | undefined>()
  const isExists = computed(() => user.value != undefined)

  const idAdmin = computed(() => user.value?.isAdmin ?? false)
  const isMentor = computed(() => user.value?.isMentor ?? false)

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
    idAdmin,
    isMentor,
  }
})
