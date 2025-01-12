<script setup lang="ts">
import { computed, ref } from 'vue'
import type { Team } from '@/models/Team.ts'
import type { AddEvaluationRequest } from '@/services/team/models/AddEvaluationRequest.ts'
import { addEvaluation } from '@/services/team/teamService.ts'
import { storeToRefs } from 'pinia'
import { useUserStore } from '@/stores/useUserStore.ts'

const { team } = defineProps<{
  team: Team
}>()

const score = ref(0)
const colors = ref(['#99A9BF', '#F7BA2A', '#FF9900'])
const comment = ref<string>()

const saveEvaluation = async () => {
  const request: AddEvaluationRequest = {
    comment: comment.value,
    score: score.value,
    teamId: team.id,
  }

  await addEvaluation(request)
}

const { user } = storeToRefs(useUserStore())
const currentUserIsEvaluator = computed(() =>
  team.evaluations.some((x) => x.evaluator && user.value && x.evaluator.id == user.value.id),
)
const userEvaluation = computed(() =>
  team.evaluations.find((x) => x.evaluator && user.value && x.evaluator.id == user.value.id),
)
</script>

<template>
  <div v-if="currentUserIsEvaluator && userEvaluation">
    <el-rate v-model="userEvaluation.score" :colors="colors" :max="10" disabled />
    <div class="font-bold">Отзыв:</div>
    <div v-if="userEvaluation.comment">{{ userEvaluation.comment }}</div>
  </div>
  <div v-else>
    <el-form label-position="right" label-width="100">
      <el-form-item label="Отзыв">
        <el-input v-model="comment" class="!w-[500px]" />
      </el-form-item>
      <el-form-item label="Оценка">
        <el-rate v-model="score" :colors="colors" :max="10" />
      </el-form-item>
    </el-form>
    <el-button type="primary" @click="saveEvaluation">Сохранить</el-button>
  </div>
</template>

<style scoped></style>
