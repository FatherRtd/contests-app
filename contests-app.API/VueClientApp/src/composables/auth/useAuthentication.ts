import * as userService from '@/services/user/userService.ts'

export function useAuthentication() {
  const isAuthenticated = async () => {
    return await userService.isAuthenticated()
  }

  const logout = async () => {
    await userService.logout()
  }

  return { isAuthenticated, logout }
}
