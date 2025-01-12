<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { storeToRefs } from 'pinia'
import { useUserStore } from '@/stores/useUserStore.ts'
import FileUploader from '@/components/ui/upload/FileUploader.vue'
import type { PatchUserRequest } from '@/services/user/models/PatchUserRequest.ts'
import { updateUser } from '@/services/user/userService.ts'

const { user } = storeToRefs(useUserStore())

const name = ref('')
const surName = ref('')
const avatarBase64 = ref<string>()

onMounted(() => {
  name.value = user.value?.name ?? ''
  surName.value = user.value?.surName ?? ''
  avatarBase64.value = user.value?.avatar ?? undefined
})

const submit = async () => {
  if (!user.value) {
    return
  }

  const prepareAvatar = avatarBase64.value
    ? avatarBase64.value.replace('data:image/jpeg;base64,', '')
    : ''

  const request: PatchUserRequest = {
    name: name.value,
    surName: surName.value,
    avatar: prepareAvatar,
    isAdmin: user.value.isAdmin,
    id: user.value.id,
    isMentor: user.value.isMentor,
  }

  user.value = await updateUser(request)
}
</script>

<template>
  <div>
    <div class="font-bold">Редактирование профиля</div>
    <el-form label-position="right" label-width="100">
      <el-config-provider :value-on-clear="() => undefined" :empty-values="[undefined]">
        <el-form-item label="Аватар">
          <FileUploader v-model="avatarBase64" />
        </el-form-item>
        <el-form-item label="Имя">
          <el-input v-model="name" />
        </el-form-item>
        <el-form-item label="Фамилия">
          <el-input v-model="surName" />
        </el-form-item>
      </el-config-provider>
    </el-form>
    <el-button type="primary" @click="submit">Сохранить</el-button>
  </div>
</template>

<style scoped></style>
