namespace contests_app.API.Services.Case
{
    public interface ICaseService
    {
        Task<Models.Case> CreateCase(string name, string description, string image, Guid userGuid);
    }
}
