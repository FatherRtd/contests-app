using AspNetCore.Yandex.ObjectStorage.Extensions;
using contests_app.API;
using contests_app.API.Models.Auth;
using Microsoft.EntityFrameworkCore;
using contests_app.API.Persistence;
using contests_app.API.Services.Auth;
using contests_app.API.Services.S3;
using contests_app.API.Services.Team;
using contests_app.API.Services.User;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<ContestsDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(ContestsDbContext)));
});

builder.Services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddYandexObjectStorage(options =>
{
    var config = configuration.GetSection("S3Options");
    options.BucketName = config["BucketName"];
    options.AccessKey = config["AccessKey"];
    options.SecretKey = config["SecretKey"];
    options.Location = "ru-central1";
});

builder.Services.AddScoped<IS3Storage, S3Storage>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITeamService, TeamService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddApiAuthentication(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.AddMappedEndpoints();

if (app.Environment.IsProduction())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ContestsDbContext>();
    db.Database.Migrate();
}

app.Run();
