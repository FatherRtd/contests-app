<script setup lang="ts">
import { User } from '@/models/User.ts'
import { UserFilled } from '@element-plus/icons-vue'
import { onMounted, ref } from 'vue'
import { all, updateUser } from '@/services/user/userService.ts'
import type { PatchUserRequest } from '@/services/user/models/PatchUserRequest.ts'

const users = ref<User[]>([])

onMounted(async () => {
  users.value = await all(0, 10)
})

const saveUser = async (index: number) => {
  const userToEdit = users.value[index]

  const request: PatchUserRequest = {
    id: userToEdit.id,
    isMentor: userToEdit.isMentor,
    isAdmin: userToEdit.isAdmin,
    avatar: '',
    surName: userToEdit.surName,
    name: userToEdit.name,
  }

  users.value[index] = await updateUser(request)
}

const page = ref(0)
const onLoad = async () => {
  page.value++
  const result = await all(page.value, 10)
  result.forEach((x) => users.value.push(x))
}
</script>

<template>
  <div v-infinite-scroll="onLoad" class="w-full !h-[500px]">
    <div v-for="(user, index) in users" :key="user.id" class="mb-2">
      <div class="flex justify-between p-2 bg-gray-200 rounded w-full items-center">
        <div class="flex items-center space-x-2">
          <el-avatar v-if="user.avatar != ''" :size="32" :src="user.avatar" />
          <el-avatar v-else :size="32" :icon="UserFilled" />
          <div>{{ user.displayName }}</div>
        </div>
        <div>
          <el-checkbox label="Админ" v-model="user.isAdmin" />
        </div>
        <div>
          <el-checkbox label="Ментор" v-model="user.isMentor" />
        </div>
        <div>
          <el-button @click="saveUser(index)">Сохранить</el-button>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
