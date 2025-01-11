<script setup lang="ts">
import { useRegisterForm } from '@/composables/auth/useRegisterForm.ts'

const { formData, submit } = useRegisterForm()
</script>

<template>
  <div class="flex flex-col w-full">
    <el-form label-position="top">
      <el-form-item label="Имя">
        <el-input v-model="formData.name" />
      </el-form-item>

      <el-form-item label="Фамилия">
        <el-input v-model="formData.surName" />
      </el-form-item>

      <el-form-item label="Логин">
        <el-input v-model="formData.login" />
      </el-form-item>

      <el-form-item label="Пароль">
        <el-input v-model="formData.password" />
      </el-form-item>
    </el-form>

    <el-button type="primary" @click="submit">Зарегистрироваться</el-button>
  </div>
</template>
