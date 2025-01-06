namespace contests_app.API.Services.S3
{
    public interface IS3Storage
    {
        Task<string> UploadImageAsync(byte[] file, string name);
        Task DeleteImageAsync(string name);
    }
}
