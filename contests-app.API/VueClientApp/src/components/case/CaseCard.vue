<script setup lang="ts">
import type { Case } from '@/models/Case.ts'
import { useRouter } from 'vue-router'
import { routeNames } from '@/router/routes.ts'

const { caseItem } = defineProps<{
  caseItem: Case
}>()

const router = useRouter()
const goToCase = async (caseItem: Case) => {
  await router.push({ name: routeNames.caseItem, params: { id: caseItem.id } })
}
</script>

<template>
  <div
    @click="goToCase(caseItem)"
    class="my-1 bg-gray-300 border-gray-500 border rounded p-1 w-full hover:cursor-pointer"
  >
    <div class="flex justify-center items-center">
      <el-image class="h-[160px]" :src="caseItem.imageUrl" alt="ttt"></el-image>
    </div>
    <div class="grid grid-cols-[100px_auto]">
      <div>Название:</div>
      <div>{{ caseItem.title }}</div>
    </div>

    <div class="grid grid-cols-[100px_auto]">
      <div>Описание:</div>
      <div>{{ caseItem.description }}</div>
    </div>
  </div>
</template>

<style scoped></style>
