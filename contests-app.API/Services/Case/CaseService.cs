using contests_app.API.Persistence;
using contests_app.API.Persistence.Entities;
using contests_app.API.Services.S3;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Services.Case
{
    public class CaseService : ICaseService
    {
        private readonly IS3Storage _s3Storage;
        private readonly ContestsDbContext _dbContext;

        public CaseService(IS3Storage s3Storage, ContestsDbContext dbContext)
        {
            _s3Storage = s3Storage;
            _dbContext = dbContext;
        }

        public async Task<Models.Case> CreateCase(string title, string description, string image, Guid userGuid)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userGuid);

            if (user == null)
            {
                throw new Exception("user not found");
            }

            var newCase = new CaseEntity
            {
                Id = Guid.NewGuid(),
                Owner = user,
                Description = description,
                Title = title,
            };

            if (string.IsNullOrWhiteSpace(image) == false)
            {
                var byteArray = Convert.FromBase64String(image);
                var fileName = $"case-{newCase.Id}.jpg";

                var imageSrc = await _s3Storage.UploadImageAsync(byteArray, fileName);
                newCase.ImageUrl = imageSrc;
            }

            await _dbContext.Cases.AddAsync(newCase);
            await _dbContext.SaveChangesAsync();

            var model = new Models.Case
            {
                Id = newCase.Id,
                Description = newCase.Description,
                ImageUrl = newCase.ImageUrl,
                Title = newCase.Title,
                Owner = new Models.User
                {
                    Id = newCase.Owner.Id,
                    Name = newCase.Owner.Name,
                    SurName = newCase.Owner.SurName,
                }
            };
            
            return model;
        }
    }
}
