import type { CreateCaseRequest } from '@/services/case/models/CreateCaseRequest.ts'
import axios from 'axios'
import { Case } from '@/models/Case.ts'

const create = async (request: CreateCaseRequest) => {
  const result = await axios.post<Case>('/api/case/create', request)

  return new Case(result.data)
}

const all = async () => {
  const result = await axios.get<Case[]>('/api/case/all')

  return result.data.map((x) => new Case(x))
}

const my = async () => {
  const result = await axios.get<Case[]>(`/api/case/my`)

  return result.data.map((x) => new Case(x))
}

const byId = async (id: string) => {
  const result = await axios.get<Case>(`/api/case/byId?id=${id}`)

  return new Case(result.data)
}

export { create, all, my, byId }
