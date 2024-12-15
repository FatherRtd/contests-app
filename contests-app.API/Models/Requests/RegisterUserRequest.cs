using System.ComponentModel.DataAnnotations;

namespace contests_app.API.Models.Requests
{
    public record RegisterUserRequest(
        [Required] string Name,
        [Required] string SurName,
        [Required] string Login,
        [Required] string Password);
}
