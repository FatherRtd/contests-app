<script setup lang="ts">
import { useLoginForm } from '@/composables/auth/useLoginForm.ts'

const { formData, submit } = useLoginForm()
</script>

<template>
  <div class="flex flex-col w-full">
    <el-form label-position="top">
      <el-form-item label="Логин">
        <el-input v-model="formData.login" />
      </el-form-item>

      <el-form-item label="Пароль">
        <el-input v-model="formData.password" />
      </el-form-item>
    </el-form>

    <el-button type="primary" @click="submit">Войти</el-button>
  </div>
</template>
