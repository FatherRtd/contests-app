namespace contests_app.API.Models
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Team Team { get; set; }
        public User Evaluator { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
