namespace contests_app.API.Models
{
    public class Case
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public User Owner { get; set; }
    }
}
