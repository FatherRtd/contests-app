<script setup lang="ts">
import { Case } from '@/models/Case.ts'
import { onMounted, ref } from 'vue'
import { all } from '@/services/case/caseService.ts'
import CaseCard from '@/components/case/CaseCard.vue'

const cases = ref<Case[]>([])

onMounted(async () => {
  cases.value = await all()
})
</script>

<template>
  <div class="container mx-auto px-4">
    <div class="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5 gap-4">
      <div v-for="(caseItem, index) in cases" :key="index">
        <CaseCard :case-item="caseItem" />
      </div>
    </div>
  </div>
</template>

<style scoped></style>
