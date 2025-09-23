using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

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
        public async Task<SesionDTO?> IniciarSesionAsync(LoginDTO login)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuarios/authenticate", login);
                if (!response.IsSuccessStatusCode) return null;

                _sesionActual = await response.Content.ReadFromJsonAsync<SesionDTO>();
                return _sesionActual;
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
