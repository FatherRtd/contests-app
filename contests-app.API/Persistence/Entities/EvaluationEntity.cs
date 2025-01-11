namespace contests_app.API.Persistence.Entities
{
    public class EvaluationEntity
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }
        public TeamEntity Team { get; set; }

        public Guid EvaluatorId { get; set; }
        public UserEntity Evaluator { get; set; }

        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
