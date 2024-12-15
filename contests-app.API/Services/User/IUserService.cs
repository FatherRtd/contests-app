namespace contests_app.API.Services.User
{
    public interface IUserService
    {
        Task<Models.User> GetById(Guid id);
        Task Register(string name, string surName, string login, string password);
        Task<string> Login(string login, string password);

    }
}
