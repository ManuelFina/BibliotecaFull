using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.Services.Interfaces;

public interface IPrestamoService
{
    Task<List<Prestamo>> ObtenerTodosAsync();
    Task<List<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId);
    Task<Prestamo?> ObtenerPorIdAsync(int id);
    Task CrearAsync(PrestamoDTO dto);
    Task DevolverAsync(int id);
}
