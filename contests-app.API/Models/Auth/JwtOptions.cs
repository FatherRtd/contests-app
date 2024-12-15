namespace contests_app.API.Models.Auth
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = String.Empty;
        public int ExpireHours { get; set; }
    }
}
