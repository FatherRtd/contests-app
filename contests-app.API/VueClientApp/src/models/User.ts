import { Team } from '@/models/Team.ts'

export class User {
  constructor(user?: Partial<User>) {
    this.id = user?.id ?? ''
    this.name = user?.name ?? ''
    this.surName = user?.surName ?? ''
    this.login = user?.login ?? ''
    this.avatar = user?.avatar ?? ''
    this.isAdmin = user?.isAdmin ?? false
    this.isMentor = user?.isMentor ?? false
    this.ownedTeam = user?.ownedTeam ? new Team(user.ownedTeam) : undefined
    this.team = user?.team ? new Team(user.ownedTeam) : undefined
  }

  id: string
  name: string
  surName: string
  login: string
  avatar: string
  isAdmin: boolean
  isMentor: boolean
  ownedTeam: Team | undefined
  team: Team | undefined

  get displayName() {
    return `${this.name} ${this.surName}`
  }
}
