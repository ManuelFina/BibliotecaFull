using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http.Json;

namespace PracticoBiblioteca.Services.Implementaciones;

public class PrestamoService(HttpClient httpClient) : IPrestamoService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<List<Prestamo>> ObtenerTodosAsync() =>
        await _httpClient.GetFromJsonAsync<List<Prestamo>>("api/prestamos") ?? new();

    public async Task<List<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId) =>
        await _httpClient.GetFromJsonAsync<List<Prestamo>>($"api/prestamos/usuario/{usuarioId}") ?? new();

    public async Task<Prestamo?> ObtenerPorIdAsync(int id) =>
        await _httpClient.GetFromJsonAsync<Prestamo>($"api/prestamos/{id}");

    public async Task CrearAsync(PrestamoDTO dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/prestamos", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DevolverAsync(int id)
    {
        var response = await _httpClient.PutAsync($"api/prestamos/devolver/{id}", null);
        response.EnsureSuccessStatusCode();
    }
}
