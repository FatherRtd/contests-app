namespace contests_app.API.Models.Requests
{
    public record AddEvaluationRequest(Guid TeamId, int Score, string? Comment);
}
