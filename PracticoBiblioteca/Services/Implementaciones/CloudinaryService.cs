using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http.Json;

namespace PracticoBiblioteca.Services.Implementaciones;

public class CloudinaryService : ICloudinaryService
{
    private readonly HttpClient _httpClient;

    public CloudinaryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CloudinaryResponseDTO?> SubirImagen(Stream fileStream, string fileName)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileStream), "file", fileName);

            var response = await _httpClient.PostAsync("api/upload/image", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<CloudinaryResponseDTO>();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al subir la imagen a Cloudinary", ex);
        }
    }
}
