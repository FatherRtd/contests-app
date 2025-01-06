namespace contests_app.API.Persistence.Entities
{
    public class CaseEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public Guid OwnerId { get; set; }
        public UserEntity Owner { get; set; }
    }
}
