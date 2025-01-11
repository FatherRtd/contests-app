import { User } from '@/models/User.ts'

export class Case {
  constructor(caseItem?: Partial<Case>) {
    this.id = caseItem?.id ?? ''
    this.title = caseItem?.title ?? ''
    this.description = caseItem?.description ?? ''
    this.imageUrl = caseItem?.imageUrl ?? ''
    this.owner = caseItem?.owner ? new User(caseItem.owner) : undefined
  }

  id: string
  title: string
  description: string
  imageUrl: string
  owner: User | undefined
}
