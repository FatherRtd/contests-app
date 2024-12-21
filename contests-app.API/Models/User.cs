namespace contests_app.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsMentor { get; set; }
    }
}
