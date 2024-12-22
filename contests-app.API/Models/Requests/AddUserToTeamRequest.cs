namespace contests_app.API.Models.Requests
{
    public record AddUserToTeamRequest(Guid TeamId, Guid UserId);
}
