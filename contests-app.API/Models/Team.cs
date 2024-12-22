namespace contests_app.API.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User Owner { get; set; }
    }
}
