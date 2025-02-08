<script setup lang="ts">
import { Case } from '@/models/Case.ts'
import { onMounted, ref } from 'vue'
import { my } from '@/services/case/caseService.ts'
import AddCaseForm from '@/components/profile/AddCaseForm.vue'
import CaseCard from '@/components/case/CaseCard.vue'
import { useRouter } from 'vue-router'
import { routeNames } from '@/router/routes.ts'

const cases = ref<Case[]>([])

onMounted(async () => {
  cases.value = await my()
})

const onCaseAdded = async () => {
  cases.value = await my()
}

const router = useRouter()
const goToCase = async (caseItem: Case) => {
  await router.push({ name: routeNames.caseItem, params: { id: caseItem.id } })
}
</script>

<template>
  <div>
    <div class="font-bold">Мои кейсы</div>

    <AddCaseForm @update="onCaseAdded()" />

    <div v-for="caseItem in cases" :key="caseItem.id" class="cursor-pointer">
      <CaseCard :case-item="caseItem" @click="goToCase(caseItem)" />
    </div>
  </div>
</template>

<style scoped></style>
