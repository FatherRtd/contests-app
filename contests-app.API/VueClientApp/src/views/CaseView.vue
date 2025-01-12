<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { Case } from '@/models/Case.ts'
import { byId } from '@/services/case/caseService.ts'
import { Team } from '@/models/Team.ts'
import { byCase } from '@/services/team/teamService.ts'
import AddTeamEvaluation from '@/components/case/AddTeamEvaluation.vue'

const { id } = defineProps<{
  id: string
}>()

const caseItem = ref<Case>()
const teams = ref<Team[]>([])

onMounted(async () => {
  caseItem.value = await byId(id)
  teams.value = await byCase(id)
})
</script>

<template>
  <div v-if="caseItem" class="w-full">
    <div class="bg-gray-300 border rounded p-1 w-full">
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
    <div class="font-bold">Команды</div>
    <div v-for="team in teams" :key="team.id" class="border rounded p-1 w-full">
      <div>{{ team.name }}</div>
      <AddTeamEvaluation :team="team" />
    </div>
  </div>
</template>

<style scoped></style>
