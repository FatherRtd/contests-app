<script setup lang="ts">
import type { Team } from '@/models/Team.ts'
import { computed, onMounted, ref } from 'vue'
import type { User } from '@/models/User.ts'
import { allWithoutTeam } from '@/services/user/userService.ts'
import { addUser } from '@/services/team/teamService.ts'
import type { AddUserToTeamRequest } from '@/services/team/models/AddUserToTeamRequest.ts'
import { storeToRefs } from 'pinia'
import { useUserStore } from '@/stores/useUserStore.ts'

const users = ref<User[]>([])
const selectedUserId = ref<string>()

const team = defineModel<Team>({ required: true })

const { user } = storeToRefs(useUserStore())
const currentUserIsOwner = computed(() => user.value && user.value.id == team.value.owner.id)

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

onMounted(async () => {
  users.value = await allWithoutTeam()
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
