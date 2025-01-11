import axios from 'axios'
import type { PatchUserRequest } from '@/services/user/models/PatchUserRequest.ts'
import { User } from '@/models/User.ts'
import type { LoginUserRequest } from '@/services/user/models/LoginUserRequest.ts'
import type { RegisterUserRequest } from '@/services/user/models/RegisterUserRequest.ts'

const updateUser = async (request: PatchUserRequest) => {
  const response = await axios.patch<User>('/api/user/updateUser', request)

  return new User(response.data)
}

const currentUser = async () => {
  const response = await axios.get<User>('/api/user/currentUser')

  return new User(response.data)
}

const byId = async (id: string) => {
  const response = await axios.get<User>(`/api/user/byId?${id}`)

  return new User(response.data)
}

const register = async (request: RegisterUserRequest) => {
  await axios.post('/api/user/register', request)
}

const login = async (request: LoginUserRequest) => {
  await axios.post('/api/user/login', request)
}

const logout = async () => {
  await axios.get('/api/user/logout')
}

const isAuthenticated = async () => {
  const response = await axios.get<boolean>('/api/user/isAuthenticated')

  return response.data
}

export { updateUser, currentUser, byId, register, login, logout, isAuthenticated }
