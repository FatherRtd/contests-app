<script setup lang="ts">
import AnimatedBackground from '@/components/ui/background/AnimatedBackground.vue'
import AppLayout from '@/components/layouts/AppLayout.vue'
import { onMounted } from 'vue'
import { useAuthentication } from '@/composables/auth/useAuthentication.ts'
import { useUserStore } from '@/stores/useUserStore.ts'

const { isAuthenticated } = useAuthentication()
const userStore = useUserStore()

onMounted(async () => {
  const authenticated = await isAuthenticated()
  if (authenticated) {
    await userStore.loadUser()
  }
})
</script>

<template>
  <AppLayout />

  <AnimatedBackground />
</template>

<style scoped></style>
