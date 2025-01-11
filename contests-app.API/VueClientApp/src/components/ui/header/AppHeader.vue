<script setup lang="ts">
import { ElementPlus } from '@element-plus/icons-vue'
import { routeNames } from '@/router/routes.ts'
</script>

<template>
  <div class="flex items-center justify-between h-12 bg-gray-200 py-2 px-8">
    <div class="flex items-center gap-x-4">
      <router-link :to="{ name: routeNames.home }">
        <el-icon size="32" color="gray">
          <ElementPlus />
        </el-icon>
      </router-link>
    </div>
  </div>
</template>

<style scoped>
.el-button + .el-button {
  margin-left: 0;
}
</style>
