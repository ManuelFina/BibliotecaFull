using PracticoBiblioteca.Shared.DTOs;
using PracticoBiblioteca.Shared.Models;

namespace PracticoBiblioteca.API.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<SesionDTO?> AutenticacionAsync(LoginDTO login);
        Task<Usuario> RegistrarAsync(RegistroDTO registro);
        Task<bool> ExistePorEmailAsync(string email);
        Task<List<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Usuario usuario);
        Task ActualizarAsync(Usuario usuario);
        Task EliminarAsync(int id);
    }
}
