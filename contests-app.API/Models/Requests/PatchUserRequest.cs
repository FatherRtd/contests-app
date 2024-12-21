namespace contests_app.API.Models.Requests
{
    public record PatchUserRequest(
        Guid Id,
         string Name,
         string SurName,
         bool IsAdmin,
         bool IsMentor);
}
