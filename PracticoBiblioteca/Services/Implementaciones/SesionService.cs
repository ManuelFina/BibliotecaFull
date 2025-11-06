using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using PracticoBiblioteca.Shared.Models;
using Microsoft.Extensions.Logging;

namespace PracticoBiblioteca.Services.Implementaciones
{
    public class SesionService : ISesionService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SesionService> _logger;
        private SesionDTO? _sesionActual;

        public SesionService(HttpClient httpClient, ILogger<SesionService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
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
            _sesionActual = sesion;
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
