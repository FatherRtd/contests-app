namespace contests_app.API.Services.Team
{
    public interface ITeamService
    {
        Task<IEnumerable<Models.Team>> GetTeams();
        Task<Models.Team> GetTeamById(Guid id);
        Task<IEnumerable<Models.Team>> GetTeamsByCase(Guid id);
        Task<Models.Team?> GetTeamByUser(Guid userId);
        Task<Models.Team> CreateTeam(string name, Guid userGuid);
        Task AddUser(Guid teamId, Guid userId);
        Task Delete(Guid teamId);
        Task SelectCase(Guid teamGuid, Guid caseGuid);
        Task AddEvaluation(Guid teamId, Guid evaluatorId, int score, string? comment);
    }
}
