<script setup lang="ts">
import { ElementPlus, UserFilled } from '@element-plus/icons-vue'
import { useRouter } from 'vue-router'
import { routeNames } from '@/router/routes.ts'
import { useUserStore } from '@/stores/useUserStore.ts'
import { useAuthentication } from '@/composables/auth/useAuthentication.ts'

const router = useRouter()

const goToLoginView = async () => {
  await router.push({ name: routeNames.login })
}

const goToRegisterView = async () => {
  await router.push({ name: routeNames.register })
}

const goToProfileView = async () => {
  await router.push({ name: routeNames.profile })
}

const userStore = useUserStore()
const { logout } = useAuthentication()

const onLogout = async () => {
  await logout()
  userStore.clear()

  await router.push({ name: routeNames.home })
}
</script>

<template>
  <div class="flex items-center justify-between h-12 bg-gray-200 py-2 px-8">
    <div class="flex items-center gap-x-4">
      <router-link :to="{ name: routeNames.home }">
        <el-icon size="32" color="gray">
          <ElementPlus />
        </el-icon>
      </router-link>

      <router-link :to="{ name: routeNames.cases }">
        <div class="font-medium text-blue-600 dark:text-blue-500 hover:underline">Кейсы</div>
      </router-link>

      <router-link v-if="userStore.idAdmin" :to="{ name: routeNames.userEditing }">
        <div class="font-medium text-blue-600 dark:text-blue-500 hover:underline">
          Управление пользователями
        </div>
      </router-link>
    </div>

    <el-dropdown>
      <div class="flex items-center gap-x-2">
        <el-avatar
          v-if="userStore.user?.avatar && userStore.user.avatar != ''"
          :size="32"
          :src="userStore.user.avatar"
        />
        <el-avatar v-else :size="32" :icon="UserFilled" />
        <div v-if="userStore.isExists">{{ userStore.user?.displayName }}</div>
      </div>

      <template #dropdown>
        <div v-if="userStore.isExists" class="p-4 flex items-center flex-col gap-y-2">
          <el-button class="w-28" @click="goToProfileView">Профиль</el-button>

          <el-button class="w-28" link @click="onLogout">Выход</el-button>
        </div>

        <div v-else class="p-4 flex items-center flex-col gap-y-2">
          <el-button class="w-28" @click="goToLoginView">Войти</el-button>

          <el-button class="w-28" link @click="goToRegisterView">Регистрация</el-button>
        </div>
      </template>
    </el-dropdown>
  </div>
</template>

<style scoped>
.el-button + .el-button {
  margin-left: 0;
}
</style>
