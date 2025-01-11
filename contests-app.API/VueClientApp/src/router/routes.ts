import type { RouteRecordRaw } from 'vue-router'

const routeNames = {
  home: 'home',
  login: 'login',
  register: 'register',
  profile: 'profile',
  cases: 'cases',
  userEditing: 'userEditing',
}

const HomeView = () => import('@/views/HomeView.vue')
const ProfileView = () => import('@/views/ProfileView.vue')
const CasesView = () => import('@/views/CasesView.vue')
const UserEditView = () => import('@/views/UserEditView.vue')
const AuthView = () => import('@/views/AuthView.vue')
const LoginForm = () => import('@/components/auth/LoginForm.vue')
const RegisterForm = () => import('@/components/auth/RegisterForm.vue')

const routes: RouteRecordRaw[] = [
  {
    path: '/',
    name: routeNames.home,
    component: HomeView,
  },
  {
    path: '/profile',
    component: ProfileView,
    name: routeNames.profile,
  },
  {
    path: '/edit-users',
    component: UserEditView,
    name: routeNames.userEditing,
  },
  {
    path: '/cases',
    component: CasesView,
    name: routeNames.cases,
  },
  {
    path: '/auth',
    component: AuthView,
    children: [
      {
        path: '',
        redirect: { name: routeNames.login },
      },
      {
        name: routeNames.login,
        path: 'login',
        component: LoginForm,
      },
      {
        name: routeNames.register,
        path: 'register',
        component: RegisterForm,
      },
    ],
  },
]

export { routes, routeNames }
