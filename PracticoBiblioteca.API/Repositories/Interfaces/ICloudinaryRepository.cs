namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface ICloudinaryRepository
    {
        Task<string> UploadImageAsync(Stream fileStream, string fileName);
    }
}
