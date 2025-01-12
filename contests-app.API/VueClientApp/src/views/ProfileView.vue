<script setup lang="ts">
import ProfileLayout from '@/components/layouts/ProfileLayout.vue'
import EditProfile from '@/components/profile/EditProfile.vue'
import ProfileTeam from '@/components/profile/ProfileTeam.vue'
</script>

<template>
  <ProfileLayout>
    <template #left>
      <EditProfile />
    </template>

    <template #right>
      <ProfileTeam />
    </template>
  </ProfileLayout>
</template>

<style scoped></style>
