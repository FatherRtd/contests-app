<script setup lang="ts">
import FileUploader from '@/components/ui/upload/FileUploader.vue'
import { ref } from 'vue'
import type { CreateCaseRequest } from '@/services/case/models/CreateCaseRequest.ts'
import { create } from '@/services/case/caseService.ts'

const title = ref('')
const description = ref('')
const avatarBase64 = ref<string>()

const emit = defineEmits<{
  update: []
}>()

const submit = async () => {
  if (
    title.value == '' ||
    description.value == '' ||
    avatarBase64.value == undefined ||
    avatarBase64.value == ''
  ) {
    return
  }
  const prepareAvatar = avatarBase64.value
    ? avatarBase64.value.replace('data:image/jpeg;base64,', '')
    : ''

  const request: CreateCaseRequest = {
    description: description.value,
    image: prepareAvatar,
    title: title.value,
  }
  await create(request)

  emit('update')

  title.value = ''
  description.value = ''
  avatarBase64.value = undefined
}
</script>

<template>
  <div>
    <el-form label-width="100" label-position="right">
      <el-form-item label="Изображение">
        <FileUploader v-model="avatarBase64" />
      </el-form-item>

      <el-form-item label="Название">
        <el-input v-model="title" />
      </el-form-item>

      <el-form-item label="Описание">
        <el-input v-model="description" />
      </el-form-item>
    </el-form>
    <el-button @click="submit" type="primary">Добавить</el-button>
  </div>
</template>

<style scoped></style>
