using contests_app.API;
using contests_app.API.Models.Auth;
using Microsoft.EntityFrameworkCore;
using contests_app.API.Persistence;
using contests_app.API.Services.Auth;
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

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddApiAuthentication(configuration);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(x => x.AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowAnyOrigin());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.AddMappedEndpoints();

app.Run();
