import axios from 'axios'

const AxiosPlugin = {
  install() {
    axios.defaults.withCredentials = true

    axios.interceptors.request.use(
      (config) => {
        return config
      },
      (error) => {
        return Promise.reject(error)
      },
    )

    axios.interceptors.response.use(
      (response) => {
        return response
      },
      (error) => {
        console.error('Ошибка при выполнении запроса:', error)
        return Promise.reject(error)
      },
    )
  },
}

export default AxiosPlugin
