import { User } from '@/models/User.ts'
import { Evaluation } from '@/models/Evaluation.ts'
import { Case } from '@/models/Case.ts'

export class Team {
  constructor(team?: Partial<Team>) {
    this.id = team?.id ?? ''
    this.name = team?.name ?? ''
    this.users = team?.users ? team.users.map((x) => new User(x)) : []
    this.owner = team?.owner ? new User(team.owner) : undefined
    this.selectedCase = team?.selectedCase ? new Case(team.selectedCase) : undefined
    this.evaluations = team?.evaluations ? team.evaluations.map((x) => new Evaluation(x)) : []
    this.averageScore = team?.averageScore
  }

  id: string
  name: string
  users: User[]
  owner: User | undefined
  selectedCase: Case | undefined
  evaluations: Evaluation[]
  averageScore: number | undefined
}
