using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PracticoBiblioteca.Services.Implementaciones;

public class PrestamoService : IPrestamoService
{
    private readonly HttpClient _httpClient;

    public PrestamoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Prestamo>> ObtenerTodos()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Prestamo>>("api/prestamos")
                   ?? new List<Prestamo>();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los préstamos", ex);
        }
    }

    public async Task<List<Prestamo>> ObtenerPorUsuario(int usuarioId)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Prestamo>>($"api/prestamos/usuario/{usuarioId}")
                   ?? new List<Prestamo>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener los préstamos del usuario {usuarioId}", ex);
        }
    }

    public async Task<Prestamo?> ObtenerPorId(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Prestamo>($"api/prestamos/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el préstamo con ID {id}", ex);
        }
    }

    public async Task SolicitarPrestamo(int libroId, int usuarioId)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/prestamos/solicitar", new { libroId, usuarioId });
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al solicitar el préstamo", ex);
        }
    }

    public async Task AprobarPrestamo(int id)
    {
        try
        {
            var response = await _httpClient.PutAsync($"api/prestamos/{id}/aprobar", null);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al aprobar el préstamo", ex);
        }
    }

    public async Task DevolverPrestamo(int id)
    {
        try
        {
            var response = await _httpClient.PutAsync($"api/prestamos/{id}/devolver", null);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al devolver el préstamo", ex);
        }
    }

    public async Task Eliminar(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/prestamos/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el préstamo", ex);
        }
    }
}
