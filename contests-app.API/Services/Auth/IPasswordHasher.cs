namespace contests_app.API.Services.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string password);
        bool Verify(string password, string passwordHash);

    }
}
