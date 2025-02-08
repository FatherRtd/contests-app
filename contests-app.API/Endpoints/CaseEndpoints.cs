using contests_app.API.Models.Requests;
using contests_app.API.Services.Case;
using Microsoft.AspNetCore.Mvc;

namespace contests_app.API.Endpoints
{
    public static class CaseEndpoints
    {
        public static IEndpointRouteBuilder MapCaseEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder.MapGroup("case");
            endpoints.MapPost(nameof(Create), Create).RequireAuthorization();
            endpoints.MapGet(nameof(All), All).RequireAuthorization();
            endpoints.MapGet(nameof(My), My).RequireAuthorization();
            endpoints.MapGet(nameof(ById), ById).RequireAuthorization();

            return endpoints;
        }

        public static async Task<IResult> ById([FromQuery]Guid id, ICaseService caseService)
        {
            try
            {
                var result = await caseService.ById(id);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
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

        public static async Task<IResult> All(ICaseService caseService)
        {
            try
            {
                var result = await caseService.All();

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static async Task<IResult> My(ICaseService caseService, HttpContext context)
        {
            try
            {
                var userIdClaim = context.User.FindFirst("userId")?.Value;
                if (string.IsNullOrEmpty(userIdClaim))
                {
                    return Results.Unauthorized();
                }

                var userId = new Guid(userIdClaim);

                var result = await caseService.My(userId);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
