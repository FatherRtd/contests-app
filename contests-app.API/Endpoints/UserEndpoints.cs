using contests_app.API.Models.Requests;
using contests_app.API.Services.User;

namespace contests_app.API.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoints = builder.MapGroup("user");

            endpoints.MapGet(nameof(ById), ById).RequireAuthorization();
            endpoints.MapGet(nameof(CurrentUser), CurrentUser).RequireAuthorization();
            endpoints.MapPatch(nameof(UpdateUser), UpdateUser).RequireAuthorization();
            endpoints.MapGet(nameof(Logout), Logout).RequireAuthorization();

            endpoints.MapGet(nameof(IsAuthenticated), IsAuthenticated);
            endpoints.MapPost(nameof(Register), Register);
            endpoints.MapPost(nameof(Login), Login);

            return endpoints;
        }
        

        private static async Task<IResult> UpdateUser(PatchUserRequest request, IUserService userService)
        {
            try
            {
                var result = await userService.UpdateUser(request.Id, request.Name, request.SurName, request.IsAdmin, request.IsMentor);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        private static async Task<IResult> CurrentUser(HttpContext context, IUserService userService)
        {
            var userIdClaim = context.User.FindFirst("userId")?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                return Results.Unauthorized();
            }

            var userId = new Guid(userIdClaim);

            return await ById(userId, userService);
        }

        private static async Task<IResult> ById(Guid id, IUserService userService)
        {
            try
            {
                var result = await userService.GetById(id);

                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        private static async Task<IResult> Register(RegisterUserRequest request, IUserService userService)
        {
            try
            {
                await userService.Register(request.Name, request.SurName, request.Login, request.Password);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        private static async Task<IResult> Login(LoginUserRequest request, IUserService userService, HttpContext context)
        {
            try
            {
                var token = await userService.Login(request.Login, request.Password);

                context.Response.Cookies.Append("tasty-cookies", token);

                return Results.Ok(token);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        private static IResult Logout(HttpContext context)
        {
            context.Response.Cookies.Append("tasty-cookies", "", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(-1)
            });

            return Results.Ok();
        }

        private static IResult IsAuthenticated(HttpContext context)
        {
            if (context.User.Identity is { IsAuthenticated: true })
            {
                return Results.Ok(true);
            }

            return Results.Ok(false);
        }
    }
}
