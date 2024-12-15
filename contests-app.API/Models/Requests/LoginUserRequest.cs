using System.ComponentModel.DataAnnotations;

namespace contests_app.API.Models.Requests
{
    public record LoginUserRequest(
        [Required] string Login,
        [Required] string Password);
}
