import axios from 'axios'
import { Team } from '@/models/Team.ts'
import type { CreateTeamRequest } from '@/services/team/models/CreateTeamRequest.ts'
import type { AddUserToTeamRequest } from '@/services/team/models/AddUserToTeamRequest.ts'
import type { SelectCaseRequest } from '@/services/team/models/SelectCaseRequest.ts'
import type { AddEvaluationRequest } from '@/services/team/models/AddEvaluationRequest.ts'

const deleteTeam = async (id: string) => {
  await axios.delete(`/api/team/delete?${id}`)
}
const all = async () => {
  const response = await axios.get<Team[]>('/api/team/all')

  return response.data.map((x) => new Team(x))
}
const create = async (request: CreateTeamRequest) => {
  const response = await axios.post<Team>('/api/team/create', request)

  return new Team(response.data)
}
const addUser = async (request: AddUserToTeamRequest) => {
  await axios.patch('/api/team/addUser', request)
}
const byId = async (id: string) => {
  const response = await axios.get<Team>(`/api/team/byId?${id}`)

  return new Team(response.data)
}
const byUser = async (id: string) => {
  const response = await axios.get<Team>(`/api/team/byUser?${id}`)

  return new Team(response.data)
}
const byCase = async (caseId: string) => {
  const response = await axios.get<Team[]>(`/api/team/byCase?caseId=${caseId}`)

  return response.data.map((x) => new Team(x))
}
const my = async () => {
  const response = await axios.get<Team>(`/api/team/my`)

  return response.data ? new Team(response.data) : undefined
}
const selectCase = async (request: SelectCaseRequest) => {
  await axios.patch('/api/team/selectCase', request)
}
const addEvaluation = async (request: AddEvaluationRequest) => {
  await axios.patch('/api/team/addEvaluation', request)
}

export { deleteTeam, all, create, addUser, byId, byUser, my, selectCase, addEvaluation, byCase }
