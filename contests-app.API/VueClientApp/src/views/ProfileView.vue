<script setup lang="ts">
import ProfileLayout from '@/components/layouts/ProfileLayout.vue'
import EditProfile from '@/components/profile/EditProfile.vue'
import ProfileTeam from '@/components/profile/ProfileTeam.vue'
import { useUserStore } from '@/stores/useUserStore.ts'
import { storeToRefs } from 'pinia'
import MyCases from '@/components/profile/MyCases.vue'

const { user } = storeToRefs(useUserStore())
</script>

<template>
  <ProfileLayout>
    <template #left>
      <EditProfile />
    </template>

    <template #right>
      <ProfileTeam v-if="user && !user.isMentor && !user.isAdmin" />
      <MyCases v-else />
    </template>
  </ProfileLayout>
</template>

<style scoped></style>
