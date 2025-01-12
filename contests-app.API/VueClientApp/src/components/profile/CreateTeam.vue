<script setup lang="ts">
import { ref } from 'vue'
import type { CreateTeamRequest } from '@/services/team/models/CreateTeamRequest.ts'
import type { Team } from '@/models/Team.ts'
import { create } from '@/services/team/teamService.ts'

const team = defineModel<Team>()

const name = ref('')

const submit = async () => {
  if (name.value == '') {
    return
  }

  const request: CreateTeamRequest = {
    name: name.value,
  }

  team.value = await create(request)
}
</script>

<template>
  <div>
    <el-form>
      <el-form-item label-width="100" label="Название">
        <el-input v-model="name"></el-input>
      </el-form-item>
    </el-form>
    <el-button @click="submit">Сохранить</el-button>
  </div>
</template>

<style scoped></style>
