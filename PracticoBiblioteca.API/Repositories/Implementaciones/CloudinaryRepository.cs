using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using PracticoBiblioteca.API.Repositories.Interfaces;
using PracticoBiblioteca.API.CloudinaryConfig;

namespace PracticoBiblioteca.API.Repositories.Implementaciones
{
    public class CloudinaryRepository : ICloudinaryRepository
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryRepository(IOptions<CloudinarySettings> config)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(acc);
        }

        public async Task<string> UploadImageAsync(Stream fileStream, string fileName)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, fileStream),
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult.SecureUrl.ToString();
        }
    }
}
