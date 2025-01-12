<script setup lang="ts"></script>

<template>
  <div class="flex w-full h-full space-x-2">
    <div class="bg-gray-300 border-gray-500 border rounded p-1 w-1/2">
      <slot name="left" />
    </div>

    <div class="bg-gray-300 border-gray-500 border rounded p-1 w-1/2">
      <slot name="right" />
    </div>
  </div>
</template>

<style scoped></style>
