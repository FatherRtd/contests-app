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
                })
            });

            return mappedResult;
        }

        public async Task<Models.Team> GetTeamById(Guid id)
        {
            var result = await _dbContext.Teams
                                         .Include(x => x.Owner)
                                         .Include(x => x.Members)
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
                })
            };
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
    }
}
