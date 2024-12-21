using contests_app.API.Persistence;
using contests_app.API.Persistence.Entities;
using contests_app.API.Services.Auth;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Services.User
{
    public class UserService : IUserService
    {
        private readonly ContestsDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(ContestsDbContext dbContext, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<Models.User> UpdateUser(Guid id, string name, string surName, bool isAdmin, bool isMentor)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.Name = name;
            user.SurName = surName;
            user.IsAdmin = isAdmin;
            user.IsMentor = isMentor;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user.Adapt<Models.User>();
        }

        public async Task<Models.User> GetById(Guid id)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.Adapt<Models.User>();
        }

        public async Task Register(string name, string surName, string login, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => string.Equals(x.Login, login));

            if (user != null)
            {
                throw new Exception("Login exists");
            }

            var passwordHash = _passwordHasher.Generate(password);

            user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                SurName = surName,
                Login = login,
                PasswordHash = passwordHash,
                IsAdmin = false,
                IsMentor = false
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<string> Login(string login, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => string.Equals(x.Login, login));

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user.Adapt<Models.User>());

            return token;
        }
    }
}
