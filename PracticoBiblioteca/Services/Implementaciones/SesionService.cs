using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using PracticoBiblioteca.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;



namespace PracticoBiblioteca.Services.Implementaciones
{
    public class SesionService : ISesionService
    {
        private readonly HttpClient _httpClient;
        private SesionDTO? _sesionActual;
        private SesionDTO? _sesionCache;

        public SesionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<SesionDTO?> AutenticacionAsync(LoginDTO login)
        {
            var response = await _httpClient.PostAsJsonAsync("api/usuarios/autenticacion", login);
            response.EnsureSuccessStatusCode();

            var contenido = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<SesionDTO>(
                contenido,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }

        public async Task<Usuario?> RegistrarAsync(RegistroDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/usuarios/register", dto);

            if (!response.IsSuccessStatusCode)
                return null;

            try
            {
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            catch
            {
               
                return null;
            }
        }

        public void GuardarSesion(SesionDTO sesion)
        {
            _sesionCache = sesion;
        }

        public Task<SesionDTO?> ObtenerSesionAsync()
        {
            return Task.FromResult(_sesionActual);
        }

        public void CerrarSesion()
        {
            _sesionActual = null;
        }
    }
}
