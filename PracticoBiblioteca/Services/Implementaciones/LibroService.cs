using PracticoBiblioteca.Models;
using PracticoBiblioteca.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PracticoBiblioteca.Services.Implementaciones;

public class LibroService : ILibroService
{
    private readonly HttpClient _httpClient;

    public LibroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Libro>> ObtenerTodos()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<Libro>>("api/libros")
                   ?? new List<Libro>();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener los libros", ex);
        }
    }

    public async Task<Libro?> ObtenerPorId(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Libro>($"api/libros/{id}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Error al obtener el libro con ID {id}", ex);
        }
    }

    public async void Agregar(Libro libro)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/libros", libro);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar el libro", ex);
        }
    }

    public async void Actualizar(Libro libro)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/libros/{libro.Id}", libro);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el libro", ex);
        }
    }

    public async void Eliminar(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/libros/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el libro", ex);
        }
    }
}
