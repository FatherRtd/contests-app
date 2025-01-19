<script setup lang="ts">
import type { Team } from '@/models/Team.ts'
import { computed, onMounted, ref } from 'vue'
import type { User } from '@/models/User.ts'
import { allWithoutTeam } from '@/services/user/userService.ts'
import { addUser, selectCase } from '@/services/team/teamService.ts'
import type { AddUserToTeamRequest } from '@/services/team/models/AddUserToTeamRequest.ts'
import { storeToRefs } from 'pinia'
import { useUserStore } from '@/stores/useUserStore.ts'
import { Case } from '@/models/Case.ts'
import type { SelectCaseRequest } from '@/services/team/models/SelectCaseRequest.ts'
import { all } from '@/services/case/caseService.ts'

const users = ref<User[]>([])
const selectedUserId = ref<string>()

const cases = ref<Case[]>([])
const selectedCaseId = ref<string>()

const team = defineModel<Team>({ required: true })

const { user } = storeToRefs(useUserStore())
const currentUserIsOwner = computed(() => user.value && user.value.id == team.value?.owner?.id)

const addToTeam = async () => {
  if (selectedUserId.value == undefined) {
    return
  }

  const index = users.value.findIndex((x) => x.id == selectedUserId.value)
  const selectedUser = users.value[index]

  team.value.users.push(selectedUser)
  const request: AddUserToTeamRequest = {
    teamId: team.value.id,
    userId: selectedUserId.value,
  }
  await addUser(request)
}

const selectCaseToTeam = async () => {
  if (selectedCaseId.value == undefined) {
    return
  }

  const index = cases.value.findIndex((x) => x.id == selectedCaseId.value)
  const selectedCase = cases.value[index]

  team.value.selectedCase = selectedCase
  const request: SelectCaseRequest = {
    teamId: team.value.id,
    caseId: selectedCase.id,
  }
  await selectCase(request)
}

onMounted(async () => {
  users.value = await allWithoutTeam()
  cases.value = await all()
})
</script>

<template>
  <div class="p-2">
    <div class="grid grid-cols-[100px_auto]">
      <div>Название:</div>
      <div>{{ team.name }}</div>
    </div>

    <div class="grid grid-cols-[100px_auto]">
      <div>Владелец:</div>
      <div>{{ team.owner?.displayName }}</div>
    </div>
    <div class="grid grid-cols-[100px_auto]">
      <div>Кейс:</div>
      <div v-if="team.selectedCase">
        <div>{{ team.selectedCase.title }}</div>
      </div>
      <div v-else-if="!currentUserIsOwner">Не выбран</div>
      <div v-else class="flex items-center space-x-1 mb-2">
        <el-select
          v-model="selectedCaseId"
          placeholder="Выбрать кейс"
          clearable
          :value-on-clear="undefined"
        >
          <el-option
            v-for="caseItem in cases"
            :key="caseItem.id"
            :label="caseItem.title"
            :value="caseItem.id"
          />
        </el-select>
        <el-button type="primary" @click="selectCaseToTeam">Выбрать</el-button>
      </div>
    </div>

    <div v-if="team.selectedCase" class="grid grid-cols-[100px_auto] mb-2">
      <div>Оценка:</div>

      <div v-if="team.evaluations.length > 0">
        <div>Средняя оценка - {{ team.averageScore }}</div>
        <div
          v-for="evaluation in team.evaluations"
          :key="evaluation.id"
          class="border border-gray-500 p-1 mb-1 rounded"
        >
          <div class="flex items-center space-x-2">
            <div>{{ evaluation.evaluator?.displayName }}</div>
            <div>Оценка - {{ evaluation.score }}</div>
          </div>
          <div>Отзыв: {{ evaluation.comment }}</div>
        </div>
      </div>
      <div v-else>Нет оценок</div>
    </div>

    <div class="grid grid-cols-[100px_auto]">
      <div>Участники:</div>
      <div>
        <div v-if="currentUserIsOwner" class="flex items-center space-x-1 mb-2">
          <el-select
            v-model="selectedUserId"
            placeholder="Выбрать пользователя"
            clearable
            :value-on-clear="undefined"
          >
            <el-option
              v-for="user in users"
              :key="user.id"
              :label="user.displayName"
              :value="user.id"
            />
          </el-select>
          <el-button type="primary" @click="addToTeam">Добавить</el-button>
        </div>

        <div v-for="user in team.users" :key="user.id" class="mb-1">
          <div class="flex items-center space-x-1">
            <el-avatar :size="32" :src="user.avatar" />
            <div>{{ user.displayName }}</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
