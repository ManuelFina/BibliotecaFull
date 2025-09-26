using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.Services.Interfaces;
using PracticoBiblioteca.Shared.DTOs;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace PracticoBiblioteca.Services.Implementaciones;

public class UsuarioService : IUsuarioService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<UsuarioService> _logger;

    public UsuarioService(HttpClient httpClient, ILogger<UsuarioService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<SesionDTO?> AutenticacionAsync(LoginDTO login)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/usuarios/authenticate", login);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SesionDTO>();
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error en la autenticación");
            throw;
        }
    }
    public async Task<Usuario> RegistrarAsync(RegistroDTO dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/usuarios/register", dto);
        response.EnsureSuccessStatusCode();

        var usuario = await response.Content.ReadFromJsonAsync<Usuario>();
        return usuario!;
    }

    public async Task<List<Usuario>> ObtenerTodosAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("api/usuarios")
                   ?? new List<Usuario>();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los usuarios", ex);
        }
    }

    public async Task<Usuario?> ObtenerPorIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Usuario>($"api/usuarios/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el usuario con ID {id}", ex);
        }
    }

    public async Task AgregarAsync(Usuario usuario)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/usuarios", usuario);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar el usuario", ex);
        }
    }

    public async Task ActualizarAsync(Usuario usuario)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/usuarios/{usuario.Id}", usuario);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el usuario", ex);
        }
    }

    public async Task EliminarAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/usuarios/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el usuario", ex);
        }
    }
}

