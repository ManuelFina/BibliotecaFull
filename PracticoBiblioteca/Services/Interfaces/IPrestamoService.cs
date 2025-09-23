using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.Services.Interfaces;

public interface IPrestamoService
{
    Task<List<Prestamo>> ObtenerTodos();
    Task<List<Prestamo>> ObtenerPorUsuario(int usuarioId);
    Task<Prestamo?> ObtenerPorId(int id);
    Task SolicitarPrestamo(int libroId, int usuarioId);
    Task AprobarPrestamo(int id);
    Task DevolverPrestamo(int id);
    Task Eliminar(int id);
}
