using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> ObtenerTodosAsync();
        Task<Prestamo?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Prestamo>> ObtenerPorUsuarioAsync(int usuarioId);
        Task<Prestamo> AgregarAsync(Prestamo prestamo);
        Task EditarAsync(Prestamo prestamo);
        Task EliminarAsync(int id);
    }
}
