using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IPrestamoRepository
    {
        Task<IEnumerable<Prestamo>> GetAllAsync();
        Task<Prestamo?> GetByIdAsync(int id);
        Task<IEnumerable<Prestamo>> GetByUsuarioAsync(int usuarioId);
        Task<Prestamo> AddAsync(Prestamo prestamo);
        Task UpdateAsync(Prestamo prestamo);
        Task DeleteAsync(int id);
    }
}
