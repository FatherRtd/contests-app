using contests_app.API.Models.Requests;
using contests_app.API.Services.Team;

namespace contests_app.API.Endpoints
{
    public static class TeamEndpoints
    {
        public static IEndpointRouteBuilder MapTeamEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder.MapGroup("team");

            endpoints.MapPost(nameof(Create), Create).RequireAuthorization();
            endpoints.MapGet(nameof(All), All).RequireAuthorization();
            endpoints.MapGet(nameof(ById), ById).RequireAuthorization();
            endpoints.MapGet(nameof(ByUser), ByUser).RequireAuthorization();
            endpoints.MapPatch(nameof(AddUser), AddUser).RequireAuthorization();

            return endpoints;
        }

        public static async Task<IResult> All(ITeamService teamService)
        {
            var result = await teamService.GetTeams();

            return Results.Ok(result);
        }

        public static async Task<IResult> Create(CreateTeamRequest request, ITeamService teamService)
        {
            try
            {
                var result = await teamService.CreateTeam(request.Name, request.UserId);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static async Task<IResult> AddUser(AddUserToTeamRequest request, ITeamService teamService)
        {
            try
            {
                await teamService.AddUser(request.TeamId, request.UserId);

                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static async Task<IResult> ById(Guid id, ITeamService teamService)
        {
            try
            {
                var result = await teamService.GetTeamById(id);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        public static async Task<IResult> ByUser(Guid userId, ITeamService teamService)
        {
            try
            {
                var result = await teamService.GetTeamByUser(userId);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
