<script setup lang="ts">
const imageData = defineModel<string>()

const handleFileUpload = (event: Event) => {
  const input = event.target as HTMLInputElement
  const file = input?.files?.[0]

  if (file) {
    const reader = new FileReader()
    reader.onloadend = () => {
      imageData.value = reader.result as string
    }
    reader.readAsDataURL(file)
  }
}
</script>

<template>
  <div class="flex flex-col">
    <input type="file" @change="handleFileUpload" accept="image/*" />
    <div v-if="imageData">
      <p>Изображение загружено:</p>
      <img class="w-8 h-8" :src="imageData" alt="Загрузить" />
    </div>
  </div>
</template>

<style scoped></style>
