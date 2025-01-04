using System.ComponentModel.DataAnnotations.Schema;

namespace contests_app.API.Persistence.Entities
{
    [Table("User")]
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsMentor { get; set; }
        public string Avatar { get; set; }

        public Guid? TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public TeamEntity OwnedTeam { get; set; }
    }
}
