import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueDevTools from 'vite-plugin-vue-devtools'

const HOST = '0.0.0.0'
const BACKEND = 'http://localhost:5085'
const PORT = 5173

// https://vite.dev/config/
export default defineConfig({
  build: {
    outDir: '../wwwroot/',
    sourcemap: false,
    target: 'esnext',
  },
  server: {
    host: HOST,
    port: PORT,
    proxy: {
      '^/api': {
        target: BACKEND,
        secure: false,
      },
    },
  },
  plugins: [vue(), vueDevTools()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url)),
    },
  },
})
