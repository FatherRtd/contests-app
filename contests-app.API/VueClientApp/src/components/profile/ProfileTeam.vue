<script setup lang="ts">
import type { Team } from '@/models/Team.ts'
import { onMounted, ref } from 'vue'
import CreateTeam from '@/components/profile/CreateTeam.vue'
import TeamInfo from '@/components/profile/TeamInfo.vue'
import { my } from '@/services/team/teamService.ts'

const team = ref<Team | undefined>()

onMounted(async () => {
  team.value = await my()
})
</script>

<template>
  <div>
    <div class="font-bold">Команда</div>

    <TeamInfo v-if="team" v-model="team" />

    <CreateTeam v-else v-model="team" />
  </div>
</template>

<style scoped></style>
