namespace contests_app.API.Models.Requests
{
    public record CreateTeamRequest(string Name, Guid UserId);
}
