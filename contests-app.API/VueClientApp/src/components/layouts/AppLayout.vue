<script setup lang="ts">
import AppHeader from '@/components/ui/header/AppHeader.vue'
</script>

<template>
  <section class="min-h-screen flex flex-col">
    <header class="sticky top-0 w-full z-[99999]">
      <AppHeader />
    </header>

    <main class="mx-8 my-4 flex-1 flex">
      <router-view />
    </main>
  </section>
</template>
