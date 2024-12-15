namespace contests_app.API.Services.Auth
{
    public interface IJwtProvider
    {
        string Generate(Models.User user);
    }
}
