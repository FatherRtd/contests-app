namespace contests_app.API.Models
{
    public class Team
    {
        public Team()
        {
            Evaluations = new List<Evaluation>();
            Users = new List<User>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
        public User Owner { get; set; }
        public Case? SelectedCase { get; set; }
        public IEnumerable<Evaluation> Evaluations { get; set; }

        public double? AverageScore
        {
            get
            {
                if (Evaluations.Any() == false)
                {
                    return null;
                }

                return Evaluations.Select(x => x.Score).Sum() / Evaluations.Count();
            }
        }
    }
}
