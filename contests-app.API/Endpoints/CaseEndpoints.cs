using contests_app.API.Models.Requests;
using contests_app.API.Services.Case;

namespace contests_app.API.Endpoints
{
    public static class CaseEndpoints
    {
        public static IEndpointRouteBuilder MapCaseEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder.MapGroup("case");
            endpoints.MapPost(nameof(Create), Create).RequireAuthorization();

            return endpoints;
        }

        public static async Task<IResult> Create(CreateCaseRequest request, ICaseService caseService, HttpContext context)
        {
            try
            {
                var userIdClaim = context.User.FindFirst("userId")?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return Results.Unauthorized();
                }

                var userId = new Guid(userIdClaim);

                var result = await caseService.CreateCase(request.Title, request.Description, request.Image, userId);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
