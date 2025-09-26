using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<Prestamo> CrearAsync(Prestamo prestamo);
        Task<List<Prestamo>> ObtenerTodosAsync();
        Task<Prestamo?> ObtenerPorIdAsync(int id);
        Task<List<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId);
        Task DevolverAsync(int prestamoId);
    }
}
