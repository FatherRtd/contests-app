namespace contests_app.API.Services.Case
{
    public interface ICaseService
    {
        Task<Models.Case> CreateCase(string name, string description, string image, Guid userGuid);
        Task<IEnumerable<Models.Case>> My(Guid userId);
        Task<IEnumerable<Models.Case>> All();
        Task<Models.Case> ById(Guid id);
    }
}
