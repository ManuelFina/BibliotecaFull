using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<SesionDTO?> AutenticacionAsync(LoginDTO login);
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);

    }
}
