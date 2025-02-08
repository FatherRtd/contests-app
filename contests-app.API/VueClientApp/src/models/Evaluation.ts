import { Team } from '@/models/Team.ts'
import { User } from '@/models/User.ts'

export class Evaluation {
  constructor(evaluation?: Partial<Evaluation>) {
    this.id = evaluation?.id ?? ''
    this.team = evaluation?.team ? new Team(evaluation.team) : undefined
    this.evaluator = evaluation?.evaluator ? new User(evaluation.evaluator) : undefined
    this.score = evaluation?.score ?? 0
    this.comment = evaluation?.comment
  }

  id: string
  team: Team | undefined
  evaluator: User | undefined
  score: number
  comment: string | undefined
}
