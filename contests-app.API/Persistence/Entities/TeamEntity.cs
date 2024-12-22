namespace contests_app.API.Persistence.Entities
{
    public class TeamEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid OwnerId { get; set; }
        public UserEntity Owner { get; set; }

        public ICollection<UserEntity> Members { get; set; }
    }
}
