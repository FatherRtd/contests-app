using AspNetCore.Yandex.ObjectStorage;

namespace contests_app.API.Services.S3
{
    public class S3Storage : IS3Storage
    {
        private readonly YandexStorageService _storageService;

        public S3Storage(YandexStorageService storageService)
        {
            _storageService = storageService;
        }

        public async Task<string> UploadImageAsync(byte[] file, string name)
        {
            try
            {
                var response = await _storageService.ObjectService.PutAsync(file, name);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("Не удалось сохранить изображение");
                }

                var result = await response.ReadResultAsStringAsync();

                return result.Value;
            } 
            catch
            {
                throw new Exception("Ошибка при сохранении");
            }
        }

        public async Task DeleteImageAsync(string name)
        {
            try
            {
                var response = await _storageService.ObjectService.DeleteAsync(name);

                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception("Не удалось удалить изображение");
                }

                var result = await response.ReadResultAsStringAsync();

                return result.Value;
            }
            catch
            {
                throw new Exception("Ошибка при удалении");
            }
        }
    }
}
