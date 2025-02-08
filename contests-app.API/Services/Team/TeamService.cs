using contests_app.API.Migrations;
using contests_app.API.Models;
using contests_app.API.Persistence;
using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ContestsDbContext _dbContext;

        public TeamService(ContestsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Models.Team>> GetTeams()
        {
            var result = await _dbContext.Teams
                                         .Include(x => x.Owner)
                                         .Include(x => x.Members)
                                         .Include(x => x.SelectedCase).ThenInclude(c => c.Owner)
                                         .Include(x => x.Evaluations).ThenInclude(x => x.Evaluator)
                                         .ToListAsync();

            var mappedResult = result.Select(x => new Models.Team
            {
                Id = x.Id,
                Name = x.Name,
                Owner = new Models.User
                {
                    Id = x.Owner.Id,
                    Name = x.Owner.Name,
                    SurName = x.Owner.SurName,
                },
                Users = x.Members.Select(m => new Models.User
                {
                    Id = m.Id,
                    Name = m.Name,
                    SurName = m.SurName,
                    Avatar = m.Avatar
                }),
                SelectedCase = x.SelectedCase == null ? null : new Models.Case
                {
                    Id = x.SelectedCase.Id,
                    Description = x.SelectedCase.Description,
                    ImageUrl = x.SelectedCase.ImageUrl,
                    Title = x.SelectedCase.Title,
                    Owner = new Models.User
                    {
                        Id = x.SelectedCase.Owner.Id,
                        Name = x.SelectedCase.Owner.Name,
                        SurName = x.SelectedCase.Owner.SurName,
                    }
                },
                Evaluations = x.Evaluations.Select(e => new Models.Evaluation
                {
                    Id = e.Id,
                    Evaluator = new Models.User
                    {
                        Id = e.Evaluator.Id,
                        Name = e.Evaluator.Name,
                        SurName = e.Evaluator.SurName,
                    },
                    Comment = e.Comment,
                    Score = e.Score
                })
            });

            return mappedResult;
        }

        public async Task<Models.Team> GetTeamById(Guid id)
        {
            var result = await _dbContext.Teams
                                         .Include(x => x.Owner)
                                         .Include(x => x.Members)
                                         .Include(x => x.SelectedCase).ThenInclude(c => c.Owner)
                                         .FirstOrDefaultAsync(x => x.Id == id);

            return new Models.Team
            {
                Id = result.Id,
                Name = result.Name,
                Owner = new Models.User
                {
                    Id = result.Owner.Id,
                    Name = result.Owner.Name,
                    SurName = result.Owner.SurName,
                },
                Users = result.Members.Select(m => new Models.User
                {
                    Id = m.Id,
                    Name = m.Name,
                    SurName = m.SurName,
                    Avatar = m.Avatar
                }),
                SelectedCase = result.SelectedCase == null ? null : new Models.Case
                {
                    Id = result.SelectedCase.Id,
                    Description = result.SelectedCase.Description,
                    ImageUrl = result.SelectedCase.ImageUrl,
                    Title = result.SelectedCase.Title,
                    Owner = new Models.User
                    {
                        Id = result.SelectedCase.Owner.Id,
                        Name = result.SelectedCase.Owner.Name,
                        SurName = result.SelectedCase.Owner.SurName,
                    }
                },
                Evaluations = result.Evaluations.Select(e => new Models.Evaluation
                {
                    Id = e.Id,
                    Evaluator = new Models.User
                    {
                        Id = e.Evaluator.Id,
                        Name = e.Evaluator.Name,
                        SurName = e.Evaluator.SurName,
                    },
                    Comment = e.Comment,
                    Score = e.Score
                })
            };
        }

        public async Task<IEnumerable<Models.Team>> GetTeamsByCase(Guid id)
        {
            var caseItem = await _dbContext.Cases.FirstOrDefaultAsync(x => x.Id == id);

            if (caseItem == null)
            {
                throw new Exception("Case not found");
            }

            var result = await _dbContext.Teams
                                         .Include(x => x.Owner)
                                         .Include(x => x.Members)
                                         .Include(x => x.SelectedCase).ThenInclude(c => c.Owner)
                                         .Include(x => x.Evaluations).ThenInclude(x => x.Evaluator)
                                         .Where(x => x.SelectedCaseId != null && x.SelectedCaseId == caseItem.Id)
                                         .ToListAsync();

            var mappedResult = result.Select(x => new Models.Team
            {
                Id = x.Id,
                Name = x.Name,
                Owner = new Models.User
                {
                    Id = x.Owner.Id,
                    Name = x.Owner.Name,
                    SurName = x.Owner.SurName,
                    Avatar = x.Owner.Avatar
                },
                Users = x.Members.Select(m => new Models.User
                {
                    Id = m.Id,
                    Name = m.Name,
                    SurName = m.SurName,
                    Avatar = m.Avatar
                }),
                SelectedCase = x.SelectedCase == null ? null : new Models.Case
                {
                    Id = x.SelectedCase.Id,
                    Description = x.SelectedCase.Description,
                    ImageUrl = x.SelectedCase.ImageUrl,
                    Title = x.SelectedCase.Title,
                    Owner = new Models.User
                    {
                        Id = x.SelectedCase.Owner.Id,
                        Name = x.SelectedCase.Owner.Name,
                        SurName = x.SelectedCase.Owner.SurName,
                        Avatar = x.SelectedCase.Owner.Avatar
                    }
                },
                Evaluations = x.Evaluations.Select(e => new Models.Evaluation
                {
                    Id = e.Id,
                    Evaluator = new Models.User
                    {
                        Id = e.Evaluator.Id,
                        Name = e.Evaluator.Name,
                        SurName = e.Evaluator.SurName,
                        Avatar = e.Evaluator.Avatar
                    },
                    Comment = e.Comment,
                    Score = e.Score
                })
            });

            return mappedResult;
        }

        public async Task<Models.Team?> GetTeamByUser(Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _dbContext.Teams
                                         .Include(x => x.Owner)
                                         .Include(x => x.Members)
                                         .Include(x => x.SelectedCase).ThenInclude(c => c.Owner)
                                         .Include(x => x.Evaluations).ThenInclude(c => c.Evaluator)
                                         .FirstOrDefaultAsync(x => x.Members.Contains(user));

            if (result == null)
            {
                return null;
            }

            return new Models.Team
            {
                Id = result.Id,
                Name = result.Name,
                Owner = new Models.User
                {
                    Id = result.Owner.Id,
                    Name = result.Owner.Name,
                    SurName = result.Owner.SurName,
                },
                Users = result.Members.Select(m => new Models.User
                {
                    Id = m.Id,
                    Name = m.Name,
                    SurName = m.SurName,
                    Avatar = m.Avatar
                }),
                SelectedCase = result.SelectedCase == null ? null : new Models.Case
                {
                    Id = result.SelectedCase.Id,
                    Description = result.SelectedCase.Description,
                    ImageUrl = result.SelectedCase.ImageUrl,
                    Title = result.SelectedCase.Title,
                    Owner = new Models.User
                    {
                        Id = result.SelectedCase.Owner.Id,
                        Name = result.SelectedCase.Owner.Name,
                        SurName = result.SelectedCase.Owner.SurName,
                    }
                },
                Evaluations = result.Evaluations == null ? new List<Evaluation>() : result.Evaluations.Select(e => new Models.Evaluation
                {
                    Id = e.Id,
                    Evaluator = new Models.User
                    {
                        Id = e.Evaluator.Id,
                        Name = e.Evaluator.Name,
                        SurName = e.Evaluator.SurName,
                    },
                    Comment = e.Comment,
                    Score = e.Score
                })
            };
        }

        public async Task<Models.Team> CreateTeam(string name, Guid userGuid)
        {
            var user = await _dbContext.Users.Include(x => x.OwnedTeam).FirstOrDefaultAsync(x => x.Id == userGuid);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (user.OwnedTeam != null)
            {
                throw new Exception("Error");
            }

            var newTeam = new TeamEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                OwnerId = userGuid,
                Owner = user,
                Members = new List<UserEntity>
                {
                    user
                }
            };

            await _dbContext.Teams.AddAsync(newTeam);
            await _dbContext.SaveChangesAsync();

            return new Models.Team
            {
                Id = newTeam.Id,
                Name = newTeam.Name,
                Owner = new Models.User
                {
                    Id = newTeam.Owner.Id,
                    Name = newTeam.Owner.Name,
                    SurName = newTeam.Owner.SurName,
                },
                Users = new List<Models.User>
                {
                    new() {
                        Id = newTeam.Owner.Id,
                        Name = newTeam.Owner.Name,
                        SurName = newTeam.Owner.SurName,
                    }
                }
            };
        }

        public async Task AddUser(Guid teamId, Guid userId)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var team = await _dbContext.Teams.Include(x => x.Members).FirstOrDefaultAsync(x => x.Id == teamId);

            if (user == null || team == null)
            {
                throw new Exception("User not found");
            }

            if (team.Members.Any(x => x.Id == userId))
            {
                throw new Exception("user now in team");
            }

            team.Members.Add(user);
            
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid teamId)
        {
            var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.Id == teamId);

            if ( team == null)
            {
                throw new Exception("Team not found");
            }

            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SelectCase(Guid teamGuid, Guid caseGuid)
        {
            var caseEntity = await _dbContext.Cases.SingleOrDefaultAsync(x => x.Id == caseGuid);
            var teamEntity = await _dbContext.Teams.SingleOrDefaultAsync(x => x.Id == teamGuid);

            if (caseEntity == null || teamEntity == null)
            {
                throw new Exception("not found");
            }

            teamEntity.SelectedCase = caseEntity;

            _dbContext.Teams.Update(teamEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddEvaluation(Guid teamId, Guid evaluatorId, int score, string? comment)
        {
            var teamEntity = await _dbContext.Teams
                                             .Include(t => t.SelectedCase)
                                             .Include(t => t.Evaluations)
                                             .FirstOrDefaultAsync(x => x.Id == teamId);

            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == evaluatorId);

            if (userEntity == null || teamEntity == null)
            {
                throw new Exception("not found");
            }

            if (teamEntity.SelectedCase == null)
            {
                throw new Exception("case not selected");
            }
            
            if (userEntity.IsAdmin == false && userEntity.IsMentor == false)
            {
                throw new Exception("you dont have permissions");
            }

            if (teamEntity.Evaluations.Any(e => e.EvaluatorId == evaluatorId))
            {
                throw new Exception("evaluation exists");
            }

            var evaluationEntity = new EvaluationEntity
            {
                Id = Guid.NewGuid(),
                TeamId = teamId,
                Team = teamEntity,
                EvaluatorId = evaluatorId,
                Evaluator = userEntity,
                Score = score,
                Comment = comment
            };

            await _dbContext.Evaluations.AddAsync(evaluationEntity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
