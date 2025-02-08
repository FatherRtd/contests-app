<script setup lang="ts">
import { useRouter } from 'vue-router'

import { routeNames } from '@/router/routes.ts'
import { computed } from 'vue'

const { currentRoute, push } = useRouter()

const onChange = async (routeName: string) => {
  await push({ name: routeName })
}

const authRoute = computed({
  get(): string {
    return currentRoute.value.name?.toString() ?? ''
  },
  set(value: string) {
    currentRoute.value.name = value
  },
})
</script>

<template>
  <div class="flex justify-center w-full">
    <div
      class="flex flex-col items-center bg-gray-200 rounded border-gray-300 border-2 p-6 min-w-80"
    >
      <el-radio-group v-model="authRoute" @change="(x) => onChange(x as string)">
        <el-radio-button label="Вход" :value="routeNames.login" />
        <el-radio-button label="Регистрация" :value="routeNames.register" />
      </el-radio-group>

      <router-view />
    </div>
  </div>
</template>
